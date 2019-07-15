using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
        string originalText;
        string currentText;
        bool flag;

        public MainWindow()
        {
            dlg.FileName = "Document";
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";
            flag = false;
            InitializeComponent();      
        }
        private void File_clicked(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();

            if (ofd.ShowDialog() == true)
            {
                StreamReader sr = new StreamReader(ofd.FileName, Encoding.Default);
                originalText = sr.ReadToEnd();          
                RichTextBox1.Document.Blocks.Clear();
                RichTextBox1.AppendText(originalText);
            }

        }

        private void Filter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {           
                if (TextBox.Text == string.Empty)
                {
                    flag = false;
                    RichTextBox1.Document.Blocks.Clear();
                    RichTextBox1.AppendText(currentText);
                }
                else
                {                    
                    if (!flag)
                        currentText = GetText(RichTextBox1);
                    Start(currentText);
                    flag = true;
                }
            }         
        }

        public  void Start(string Current_text)
        {
            string without_spaces = RemoveWhitespace(TextBox.Text);           
            string[] mas = without_spaces.Split('|');
            string[] lines = Current_text.Split('.', '?', '!');
            string result = "";

            for (int i = 0; i < lines.Length; i++)
            {
                if(check_str_condition(lines[i], mas) == 1)               
                    result = result + lines[i] + ".\n";
            }
            GC.Collect();
            RichTextBox1.Document.Blocks.Clear();
            RichTextBox1.AppendText(result);
        }

        public int check_str_condition(string str, string[] cond)
        {
            int check;

            for(int i = 0; i < cond.Length; i++)
            {
                string[] temp = cond[i].Split('&');
                check = 0;
                for (int j = 0; j < temp.Length; j++)
                {
                    if (str.Contains(temp[j]))
                        check++;
                }             
                if (check == temp.Length )
                    return 1;
                GC.Collect();
            }
            return 0;
        }

        public static string GetText(RichTextBox rtb)
        {
            TextRange textRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);

            string text = textRange.Text;
            return (text);
        }

        public string RemoveWhitespace(string str) 
        {
            return (string.Join("", str.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries)));
        }

        private void FileDrop(object sender, DragEventArgs e)
        {
                string[] docPath = (string[])e.Data.GetData(DataFormats.FileDrop);
                StreamReader sr = new StreamReader(docPath[0], Encoding.Default);

                originalText = sr.ReadToEnd();
                RichTextBox1.Document.Blocks.Clear();
                RichTextBox1.AppendText(originalText);
        }

        private void Dragging(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effects = DragDropEffects.Copy;
            else
                e.Effects = DragDropEffects.None;
            e.Handled = true;
        }
    }
}
