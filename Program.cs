using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Lab8_CRUD;

static class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        ApplicationConfiguration.Initialize();

        if (args.Length >= 2 && args[0] == "--capture")
        {
            RunCapture(args[1]);
            return;
        }

        Application.Run(new Form1());
    }

    private static void RunCapture(string outDir)
    {
        Directory.CreateDirectory(outDir);

        using var form = new Form1();
        form.StartPosition = FormStartPosition.Manual;
        form.Location = new Point(-32000, -32000);
        form.ShowInTaskbar = false;
        form.Show();
        Application.DoEvents();

        void SaveScreen(string fileName)
        {
            Application.DoEvents();
            using var bmp = new Bitmap(form.Width, form.Height);
            form.DrawToBitmap(bmp, new Rectangle(0, 0, form.Width, form.Height));
            bmp.Save(Path.Combine(outDir, fileName), ImageFormat.Png);
        }

        SaveScreen("lab8_main.png");
        form.Close();
    }
}
