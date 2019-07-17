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
        int index = 1000;

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
                LoadFile(ofd.FileName);
        }
     
        public  void Start(string Current_text, string conditions)
        {
          //  string without_spaces = RemoveWhitespace(TextBox.Text);           
            string[] mas = conditions.Split('|');
            string[] lines = Current_text.Split('.', '?', '!', '\n');
            string result = "";

            for (int i = 0; i < lines.Length; i++)
            {
                if(check_str_condition(lines[i], mas) == 1)               
                    result = result + lines[i] + "\n";
            }
           // GC.Collect();
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
                    if(temp[j] != string.Empty)
                        if (str.Contains(temp[j]))
                            check++;
                }             
                if (check == temp.Length )
                    return 1;
               // GC.Collect();
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
            LoadFile(docPath[0]);                         
        }

        private void Dragging(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effects = DragDropEffects.Copy;
            else
                e.Effects = DragDropEffects.None;
            e.Handled = true;
        }

        private void Apply_filters(object sender, RoutedEventArgs e)
        {          
            originalText = GetText(RichTextBox1);
            string cond = TextBox2.Text;
            if (TextBox3.Text != string.Empty)
                 cond += GetComboboxChar(ComboBox2) + TextBox3.Text;
            if (TextBox4.Text != string.Empty)
                 cond += GetComboboxChar(ComboBox3) + TextBox4.Text;
            if (TextBox5.Text != string.Empty)
                 cond += GetComboboxChar(ComboBox4) + TextBox5.Text;
            cond = RemoveWhitespace(cond);
            currentText = GetText(RichTextBox1);
            Start(currentText, cond);
            flag = true;
            
        }

        private  string GetComboboxChar(ComboBox Box)
        {
            string str = Box.SelectedValue.ToString();
            if (str.Equals("System.Windows.Controls.ComboBoxItem: И"))          
                return "&"; 
            return "|";

        }
        private void LoadFile(string Filename)
        {
            flag = false;
            StreamReader sr = new StreamReader(Filename, Encoding.Default);
            originalText = sr.ReadToEnd();
            string temp = originalText.Substring(0, 1000);
            RichTextBox1.AppendText(temp);
            index += 1000;
        }

        private void Scrolling(object sender, MouseWheelEventArgs e)
        {
            if (flag == false)
            {
                if (e.Delta < 0)
                {
                    if (index <= originalText.Length)
                    {
                        RichTextBox1.AppendText(originalText.Substring(index - 1000, index));
                        index += 1000;
                    }
                }
            }
        }
    }
}
