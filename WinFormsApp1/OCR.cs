﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using Tesseract;
using System.Drawing;


namespace WinFormsApp1

{
    internal class OCR
    {
        public static string ImageToText(Bitmap bmp)
        {
            //for (int y = 0; (y <= (bmp.Height - 1)); y++)
            //{
            //    for (int x = 0; (x <= (bmp.Width - 1)); x++)
            //    {
            //        Color inv = bmp.GetPixel(x, y);
            //        inv = Color.FromArgb(255, (255 - inv.R), (255 - inv.G), (255 - inv.B));
            //        bmp.SetPixel(x, y, inv);
            //    }
            //}
            string output = "";

            Pix img = PixConverter.ToPix(bmp);
            var testImagePath = "G:/1000-bai-tap/IT008/OCR/image.png";
            //string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            //Console.WriteLine(sCurrentDirectory);
            //var appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //Console.WriteLine(appPath);
            try
            {
                using (var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default))
                {
                    using (var imgg = Pix.LoadFromFile(testImagePath))
                    {
                        using (var page = engine.Process(img))
                        {
                            //Console.OutputEncoding = Encoding.Unicode;
                            var text = page.GetText();
                            Console.WriteLine("Mean confidence: {0}", page.GetMeanConfidence());

                            Console.WriteLine("Text (GetText): \r\n{0}", text);
                            Console.WriteLine("Text (iterator):");

                            output += $"Mean confidence: {page.GetMeanConfidence()}\n";
                            output += $"Text (GetText): \r\n{text.ToString()}";

                            using (var iter = page.GetIterator())
                            {
                                iter.Begin();

                                do
                                {
                                    do
                                    {
                                        do
                                        {
                                            do
                                            {
                                                if (iter.IsAtBeginningOf(PageIteratorLevel.Block))
                                                {
                                                    Console.WriteLine("<BLOCK>");
                                                }

                                                Console.Write(iter.GetText(PageIteratorLevel.Word));
                                                Console.Write(" ");

                                                if (iter.IsAtFinalOf(PageIteratorLevel.TextLine, PageIteratorLevel.Word))
                                                {
                                                    Console.WriteLine();
                                                }
                                            } while (iter.Next(PageIteratorLevel.TextLine, PageIteratorLevel.Word));

                                            if (iter.IsAtFinalOf(PageIteratorLevel.Para, PageIteratorLevel.TextLine))
                                            {
                                                Console.WriteLine();
                                            }
                                        } while (iter.Next(PageIteratorLevel.Para, PageIteratorLevel.TextLine));
                                    } while (iter.Next(PageIteratorLevel.Block, PageIteratorLevel.Para));
                                } while (iter.Next(PageIteratorLevel.Block));
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Trace.TraceError(e.ToString());
                Console.WriteLine("Unexpected Error: " + e.Message);
                Console.WriteLine("Details: ");
                Console.WriteLine(e.ToString());

                output += "Unexpected Error: " + e.Message + "\n";
                output += "Details: \n";
                output += e.ToString();
            }
            Console.Write("Press any key to continue . . . ");
            return output;
        }

    }
}