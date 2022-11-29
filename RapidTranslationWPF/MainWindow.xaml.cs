using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;


//using WinFormsApp1;
using Form1 = WinFormsApp1.Form1;
using OCR = WinFormsApp1.OCR;
using Form = System.Windows.Forms.Form;

//using Stitcher = OpenCvSharp.Stitcher;
using FormApplication = System.Windows.Forms.Application;
//using Button = System.Windows.Controls.Button;
//using TextBox = System.Windows.Controls.TextBox;

namespace RapidTranslationWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            //webView.Source = new Uri("https://translate.google.com/?sl=en&tl=vi");


        }

        private void recap_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
            Form form1 = new Form1();
            FormApplication.Run(form1);
            //Bitmap img;
            //if (!form1.Created)
            //    FormApplication.Run(form1);
            //else
            //{
            //    form1.Show();
            //}

            string ans = OCR.ImageToText(Form1.capture, 0);
            string[] listSentence = ans.Split('\n');
            areaResult.Children.Clear();
            int count = 0;
            foreach (string line in listSentence)
            {
                if (count <= 1)
                {
                    count++;
                    continue;
                }
                foreach (string word in line.Split())
                {
                    //string savedButton = XamlWriter.Save(textButton);
                    //savedButton = savedButton.Replace("x:Name=\"textButton\"", "");
                    //savedButton = savedButton.Replace("We're", word);
                    //StringReader stringReader = new StringReader(savedButton);
                    //XmlReader xmlReader = XmlReader.Create(stringReader);
                    //Border readerLoadButton = (Border)XamlReader.Load(xmlReader);
                    //areaResult.Children.Add(readerLoadButton);

                    Border border = CreateWordBorderButton(word);
                    areaResult.Children.Add(border);
                }
            }
            firstText.Text = OCR.ImageToText(Form1.capture, 0).Replace("\n", System.Environment.NewLine);
            ScreenShot.Source = loadBitmap(Form1.capture);

            //form1.Hide();
            this.Show();
            WindowState = WindowState.Normal;
        }

        public static BitmapSource loadBitmap(System.Drawing.Bitmap source)
        {
            IntPtr ip = source.GetHbitmap();
            BitmapSource bs = null;
            {
                bs = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(ip,
                   IntPtr.Zero, Int32Rect.Empty,
                   System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
            }

            return bs;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender != null)
            {
                Button btn = sender as Button;
                btn.Background = Brushes.White;

            }
        }

        private Border CreateWordBorderButton(string word)
        {
            Button button = new Button();
            TextBlock textBlock = new TextBlock();
            button.Content = textBlock;

            button.Style = FindResource("wordButton") as Style;
            button.Click += Button_Click;

            Border border = new Border();
            border.Style = FindResource("roundedBorderButton") as Style;
            //button.Template = FindResource("wordButton") as ControlTemplate;
            border.Child = button;

            //TextBox textBox = button.Template.FindName("wordTextButton", button) as TextBox;
            //button.OnApplyTemplate();
            button.DataContext = word;
            return border;
        }
    }
}
