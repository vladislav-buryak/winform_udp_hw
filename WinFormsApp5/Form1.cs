using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp5;
public partial class Form1 : Form
{
    private TcpClient? _client;
    private StreamReader? _reader;
    private StreamWriter? _writer;
    private CancellationTokenSource? _cts;

    public Form1()
    {
        InitializeComponent();
        txtLog.Multiline = true;
        txtLog.ScrollBars = ScrollBars.Vertical;
        txtLog.ReadOnly = true;
    }

    protected override async void OnShown(EventArgs e)
    {
        base.OnShown(e);
        await ConnectAsync();
    }

    private async Task ConnectAsync()
    {
        try
        {
            _client = new TcpClient();
            await _client.ConnectAsync("127.0.0.1", 5002);

            var stream = _client.GetStream();
            _reader = new StreamReader(stream, Encoding.UTF8, leaveOpen: true);
            _writer = new StreamWriter(stream, Encoding.UTF8, leaveOpen: true) { AutoFlush = true };

            Log("Connected to server.");

            _cts = new CancellationTokenSource();
            _ = Task.Run(() => ListenAsync(_cts.Token));
        }
        catch (Exception ex)
        {
            Log("Connect ERROR: " + ex.Message);
            btnSend.Enabled = false;
        }
    }

    private async Task ListenAsync(CancellationToken ct)
    {
        try
        {
            while (!ct.IsCancellationRequested)
            {
                if (_reader == null) break;
                string? line = await _reader.ReadLineAsync();
                if (line == null) break;

                // UI thread
                BeginInvoke(new Action(() =>
                {
                    if (line.StartsWith("WIN|"))
                    {
                        string msg = line.Substring("WIN|".Length);
                        Log(msg);
                        btnSend.Enabled = false;
                    }
                    else if (line == "LOW") Log("Занадто мало");
                    else if (line == "HIGH") Log("Занадто багато");
                    else if (line == "CORRECT") Log("Вгадав! (чекай оголошення переможця)");
                    else Log(line);
                }));
            }
        }
        catch (Exception ex)
        {
            BeginInvoke(new Action(() => Log("Listen ERROR: " + ex.Message)));
        }
        finally
        {
            BeginInvoke(new Action(() =>
            {
                Log("Disconnected.");
                btnSend.Enabled = false;
            }));
        }
    }

    private async void btnSend_Click(object sender, EventArgs e)
    {
        if (_writer == null) return;

        if (!int.TryParse(txtGuess.Text.Trim(), out int guess))
        {
            Log("Введи число 1..100");
            return;
        }

        try
        {
            await _writer.WriteLineAsync("GUESS|" + guess);
        }
        catch (Exception ex)
        {
            Log("Send ERROR: " + ex.Message);
        }
    }

    private void Log(string text)
    {
        txtLog.AppendText(text + Environment.NewLine);
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        try { _cts?.Cancel(); } catch { }
        try { _client?.Close(); } catch { }
        base.OnFormClosed(e);
    }
}
