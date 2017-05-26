using System;
using System.Windows.Forms;

namespace Elisi01
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var presenter = new Presenter(new Project(), new MainForm());
            presenter.Run();
        }
    }
}
