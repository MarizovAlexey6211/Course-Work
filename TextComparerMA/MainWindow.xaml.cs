using Microsoft.Win32;
using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using TextComparerMA.ViewModel;

namespace TextComparerMA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            MouseDown += Window_MouseDown;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = System.Windows.WindowState.Minimized;
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void WindowStateButton_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == System.Windows.WindowState.Normal)
            {
                WindowState = System.Windows.WindowState.Maximized;
            }
            else
                WindowState = System.Windows.WindowState.Normal;
        }


        private void Button_download_new_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "RichText Files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                TextRange doc = new TextRange(TextNew.Document.ContentStart, TextNew.Document.ContentEnd);
                using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open))
                {
                    if (System.IO.Path.GetExtension(openFileDialog.FileName).ToLower() == ".rtf")
                        doc.Load(fs, DataFormats.Rtf);
                    else if (Path.GetExtension(openFileDialog.FileName).ToLower() == ".txt")
                        doc.Load(fs, DataFormats.Text);
                    else
                        doc.Load(fs, DataFormats.Xaml);
                }
            }
        }

        private void Button_download_old_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "RichText Files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                TextRange doc = new TextRange(TextOld.Document.ContentStart, TextOld.Document.ContentEnd);
                using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open))
                {
                    if (Path.GetExtension(openFileDialog.FileName).ToLower() == ".rtf")
                        doc.Load(fs, DataFormats.Rtf);
                    else if (Path.GetExtension(openFileDialog.FileName).ToLower() == ".txt")
                        doc.Load(fs, DataFormats.Text);
                    else
                        doc.Load(fs, DataFormats.Xaml);
                }
            }
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Files (*.txt)|*.txt|RichText Files (*.rtf)|*.rtf|XAML Files (*.xaml)|*.xaml|All files (*.*)|*.*";
            if (sfd.ShowDialog() == true)
            {
                TextRange doc = new TextRange(TextNew.Document.ContentStart, TextNew.Document.ContentEnd);
                using (FileStream fs = File.Create(sfd.FileName))
                {
                    if (Path.GetExtension(sfd.FileName).ToLower() == ".rtf")
                        doc.Save(fs, DataFormats.Rtf);
                    else if (Path.GetExtension(sfd.FileName).ToLower() == ".txt")
                        doc.Save(fs, DataFormats.Text);
                    else
                        doc.Save(fs, DataFormats.Xaml);
                }
            }
        }

        static string LongestCommonSubstring(string a, string b)
        {
            var n = a.Length;
            var m = b.Length;
            var array = new int[n, m];
            var maxValue = 0;
            var maxI = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (a[i] == b[j])
                    {
                        array[i, j] = (i == 0 || j == 0)
                            ? 1
                            : array[i - 1, j - 1] + 1;
                        if (array[i, j] > maxValue)
                        {
                            maxValue = array[i, j];
                            maxI = i;
                        }
                    }
                }
            }
            return a.Substring(maxI + 1 - maxValue, maxValue);
        }

        private Tuple<string, TextPointer> GetTextFromRTF(System.Windows.Controls.RichTextBox box)
        {
            TextPointer? start = box.Document.ContentStart;
            while (start.GetPointerContext(LogicalDirection.Forward) != TextPointerContext.Text)
            {
                start = start.GetNextContextPosition(LogicalDirection.Forward);
                if (start == null) return Tuple.Create("", start);
            }
            String s1 = new TextRange(start, box.Document.ContentEnd).Text;
            return Tuple.Create(s1, start);
        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tuple<string, TextPointer> tupleOld = GetTextFromRTF(TextOld);
            Tuple<string, TextPointer> tupleNew = GetTextFromRTF(TextNew);

            String s1 = tupleOld.Item1;
            String s2 = tupleNew.Item1;

            TextPointer start_old = tupleOld.Item2;
            TextPointer start_new = tupleNew.Item2;


            //String s1 = TextOld.Text;
            //String s2 = TextNew.Text;
            //int aboba = s1.Length;

            String s3 = LongestCommonSubstring(s1, s2);
            while (s3.Length > 4)
            {
                s2 = s2.Replace(s3, "|");
                s1 = s1.Replace(s3, "|");


                var a = TextNew.Text;
                start_new.GetOffsetToPosition(TextNew.Document.ContentEnd);
                var text = new TextRange(TextNew.Document.ContentStart, TextNew.Document.ContentEnd).Text;
                var x = text.IndexOf(s3);
                var y = x + s3.Length;
                var range = new TextRange(TextNew.Document.ContentStart.GetPositionAtOffset(x), TextNew.Document.ContentStart.GetPositionAtOffset(y));
                range.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Green);

                var text2 = new TextRange(TextOld.Document.ContentStart, TextOld.Document.ContentEnd).Text;
                var x2 = text2.IndexOf(s3);
                var y2 = x2 + s3.Length;
                var range2 = new TextRange(TextOld.Document.ContentStart.GetPositionAtOffset(x2), TextOld.Document.ContentStart.GetPositionAtOffset(y2));
                range2.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Green);



                /*После правильного выделения, все станетт хорошо и ретурн убрать*/
                return;

                /*
                var text = new TextRange(start_new, TextNew.Document.ContentEnd).Text;
                var x = text.IndexOf(s3);
                var y = x + s3.Length;
                var range = new TextRange(start_new.GetPositionAtOffset(x), start_new.GetPositionAtOffset(y));
                range.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Green);

                var text2 = new TextRange(start_old, TextOld.Document.ContentEnd).Text;
                var x2 = text2.IndexOf(s3);
                var y2 = x2 + s3.Length;
                var range2 = new TextRange(start_old.GetPositionAtOffset(x2), start_old.GetPositionAtOffset(y2));
                range2.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Green);
                */
                s3 = LongestCommonSubstring(s1, s2);
                s3 = s3.TrimEnd();
            }

            /*
            var lstRed = s2.Split('|');
            foreach ( var line in lstRed ) {
                var text = new TextRange(start_new, TextNew.Document.ContentEnd).Text;
                var x = text.IndexOf(line);
                var y = x + line.Length;
                var range = new TextRange(start_new.GetPositionAtOffset(x), start_new.GetPositionAtOffset(y));
                range.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Red);
            }
            */
            /*
            var lst2Red = s1.Split('|');
            foreach (var line in lst2Red)
            {
                var text2 = new TextRange(start_old, TextOld.Document.ContentEnd).Text;
                var x2 = text2.IndexOf(line);
                var y2 = x2 + line.Length;
                var range2 = new TextRange(start_old.GetPositionAtOffset(x2), start_old.GetPositionAtOffset(y2));
                range2.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Red);
            }
            */
        }


        private void TextNew_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            var text = new TextRange(TextNew.Document.ContentStart, TextNew.Document.ContentEnd).Text;
            SetUpLines(text, TextBoxLineNumbersTwo);
        }
        private void TextOld_TextChanged(object sender, TextChangedEventArgs e)
        {
            var text = new TextRange(TextOld.Document.ContentStart, TextOld.Document.ContentEnd).Text;
            SetUpLines(text, TextBoxLineNumbers);
        }
        private void TextNew_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
            TextBoxLineNumbersTwo.ScrollToVerticalOffset(TextNew.VerticalOffset);
            TextOld.ScrollToVerticalOffset(TextNew.VerticalOffset);
            TextBoxLineNumbers.ScrollToVerticalOffset(TextNew.VerticalOffset);
            TextOld.UpdateLayout();
            TextBoxLineNumbersTwo.UpdateLayout();
            TextBoxLineNumbers.UpdateLayout();
        }

        private void TextOld_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
            TextBoxLineNumbers.ScrollToVerticalOffset(TextOld.VerticalOffset);
            TextNew.ScrollToVerticalOffset(TextOld.VerticalOffset);
            TextBoxLineNumbersTwo.ScrollToVerticalOffset(TextOld.VerticalOffset);
            TextNew.UpdateLayout();
            TextBoxLineNumbers.UpdateLayout();
            TextBoxLineNumbersTwo.UpdateLayout();
        }


        private void SetUpLines(string data, TextBox tb)
        {
            int noLines = string.IsNullOrEmpty(data) ? 0 : data.Split('\n').Length;
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= noLines; i++)
            {
                sb.AppendLine(i.ToString());
            }

            tb.Text = sb.ToString();
            //TextOld.Text = data ?? "";
        }

    }
}


