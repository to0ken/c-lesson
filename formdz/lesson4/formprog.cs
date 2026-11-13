using System;
using System.Diagnostics;
using System.Windows.Forms;

class Program
{
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new MainForm());
    }
}

class MainForm1 : Form
{
    public MainForm()
    {
        Text = "Родительское приложение";
        Width = 400;
        Height = 220;

        Label lblPath = new Label();
        lblPath.Text = "Путь к файлу:";
        lblPath.SetBounds(20, 20, 100, 25);

        TextBox txtPath = new TextBox();
        txtPath.SetBounds(120, 20, 240, 25);
        txtPath.Text = "test.txt";

        Label lblWord = new Label();
        lblWord.Text = "Слово для поиска:";
        lblWord.SetBounds(20, 60, 100, 25);

        TextBox txtWord = new TextBox();
        txtWord.SetBounds(120, 60, 240, 25);
        txtWord.Text = "bicycle";

        Button butnRun = new Button();
        butnRun.Text = "Запустить поиск";
        butnRun.SetBounds(120, 100, 150, 35);
        butnRun.Click += BtnRun_Click;

        Controls.Add(lblPath);
        Controls.Add(txtPath);
        Controls.Add(lblWord);
        Controls.Add(txtWord);
        Controls.Add(btnRun);
    }

    void ButnRun_Click(object sender, EventArgs e)
    {
        string childExePath = "ChildApp.exe";

        try
        {
            Process.Start(childExePath, $"\"{txtPath.Text}\" \"{txtWord.Text}\"");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка запуска:\n" + ex.Message);
        }
    }
}
