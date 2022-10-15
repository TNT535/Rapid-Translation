namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Form form1 = new Form1();
            //Bitmap img;
            Application.Run(form1);

            //form1.Close();
            Form form2 = new Form2();
            Application.Run(form2);
        }
    }
}