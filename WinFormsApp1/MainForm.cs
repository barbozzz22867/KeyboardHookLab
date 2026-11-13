namespace KeyboardHookLab;

public sealed class MainForm : Form
{
    private readonly TextBox _logTextBox;

    public MainForm()
    {
        Text = "Keyboard Events (П1)";
        Width = 700;
        Height = 450;
        StartPosition = FormStartPosition.CenterScreen;

        // Задание 5: KeyPreview позволяет форме получать события 
        // до того, как их обработает дочерний элемент (например, TextBox).
        KeyPreview = true;

        _logTextBox = new TextBox
        {
            Multiline = true,
            ReadOnly = true,
            Dock = DockStyle.Fill,
            ScrollBars = ScrollBars.Vertical
        };

        Controls.Add(_logTextBox);

        KeyDown += OnKeyDown;
        KeyUp += OnKeyUp; // Задание 1: Добавили KeyUp
    }

    private void OnKeyDown(object? sender, KeyEventArgs e)
    {
        // Задание 3: Escape очищает журнал
        if (e.KeyCode == Keys.Escape)
        {
            _logTextBox.Clear();
            return;
        }

        // Задание 2: Выводим нажатие
        _logTextBox.AppendText(
            $"[KeyDown] {e.KeyCode}{Environment.NewLine}");
    }

    private void OnKeyUp(object? sender, KeyEventArgs e)
    {
        // Задание 2: Выводим отпускание
        _logTextBox.AppendText(
            $"[KeyUp]   {e.KeyCode}{Environment.NewLine}");
    }
}