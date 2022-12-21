using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;


//using WinFormsApp1;
using Form1 = WinFormsApp1.Form1;
using OCR = WinFormsApp1.OCR;
using Form = System.Windows.Forms.Form;

//using Stitcher = OpenCvSharp.Stitcher;
using FormApplication = System.Windows.Forms.Application;
using Bitmap = System.Drawing.Bitmap;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Button = System.Windows.Controls.Button;
//using TextBox = System.Windows.Controls.TextBox;
using MessageBox = System.Windows.MessageBox;
using TextBox = System.Windows.Controls.TextBox;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;


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



        public void CaptureScreen(Bitmap localImage = null)
        {
            if (localImage == null)
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
                if (form1.Capture == null)
                {
                    this.Show();
                    return;
                }

                string ans = OCR.ImageToText(Form1.capture, 0);
                string[] listSentence = ans.Split('\n');

                areaResult.Children.Clear();
                int count = 0;
                foreach (string line_ in listSentence)
                {
                    string line = String.Join(" ", line_.Split());
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
            else
            {
                string ans = OCR.ImageToText(localImage, 0);
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
                firstText.Text = OCR.ImageToText(localImage, 0).Replace("\n", System.Environment.NewLine);
                ScreenShot.Source = loadBitmap(localImage);

                //form1.Hide();
                this.Show();
                WindowState = WindowState.Normal;

            }

        }

        private void recap_Click(object sender, RoutedEventArgs e)
        {
            CaptureScreen();
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
                if (btn.Background == Brushes.White)
                {
                    BrushConverter brushConverter = new BrushConverter();
                    btn.Background = (Brush)brushConverter.ConvertFrom("#0F9D58");
                }
                else
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


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            VocabularyWindow vocabWindow = new VocabularyWindow();
            this.Content = vocabWindow;

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            FormApplication.Exit();
        }

        bool clicked = false;
        private void done_Click(object sender, RoutedEventArgs e)
        {
            if (clicked)
            {
                MessageBox.Show("open translate window.");
            }
            TextBox textBox = new TextBox();
            List<string> words = new List<string>();
            foreach (Button tb in FindVisualChilds<Button>(gridResultRegion))
            {
                if (tb.Background != Brushes.White)
                words.Add(tb.DataContext.ToString());
            }
            textBox.Text = string.Join(" ", words.ToArray());

            textBox.FontSize = 14;
            
            textBox.Margin = new Thickness(1, 1, 1, 1);
            textBox.Width = 800;
            textBox.Height = 250;


            areaResult.Children.Clear();
            areaResult.Children.Add(textBox);
            clicked = !clicked;
        }


        public static IEnumerable<T> FindVisualChilds<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) yield return (T)Enumerable.Empty<T>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject ithChild = VisualTreeHelper.GetChild(depObj, i);
                if (ithChild == null) continue;
                if (ithChild is T t) yield return t;
                foreach (T childOfChild in FindVisualChilds<T>(ithChild)) yield return childOfChild;
            }

        }
    }
}
