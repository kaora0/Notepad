using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
//using System.Drawing;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using System.Diagnostics;

namespace Блокнот
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _openFile;

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Arial_Click(object sender, RoutedEventArgs e)
        {
            rTB1.Selection.ApplyPropertyValue(TextElement.FontFamilyProperty, new FontFamily("Arial"));
        }
        private void Times_New_Roman_Click(object sender, RoutedEventArgs e)
        {
            rTB1.Selection.ApplyPropertyValue(TextElement.FontFamilyProperty, new FontFamily("Times New Roman"));
        }
        private void Courier_New_Click(object sender, RoutedEventArgs e)
        {
            rTB1.Selection.ApplyPropertyValue(TextElement.FontFamilyProperty, new FontFamily("Courier New"));
        }

        private void DataTime_Click(object sender, RoutedEventArgs e)
        {
            rTB1.CaretPosition = rTB1.Document.ContentEnd;
            rTB1.Selection.Text += " ";
            rTB1.Selection.Text += DateTime.Now.ToString();
        }

        private void NewWind_Click(object sender, RoutedEventArgs e)
        {
            //rTB1.Selection.Text = "";
           rTB1.Document.Blocks.Clear();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string richText = new TextRange(rTB1.Document.ContentStart, rTB1.Document.ContentEnd).Text;

                File.WriteAllText(_openFile, richText);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("save error");
            }
        }

        private void SaveHow_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog Sdialog = new SaveFileDialog();
            Sdialog.Filter = "all (*.*) |*.*";
            if (Sdialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string richText = new TextRange(rTB1.Document.ContentStart, rTB1.Document.ContentEnd).Text;

                File.WriteAllText(Sdialog.FileName, richText);
                _openFile = Sdialog.FileName;
            }
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog Fdialog = new OpenFileDialog();
            Fdialog.Filter = "all (*.*) |*.*";
            if (Fdialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                rTB1.Document.Blocks.Clear();
                rTB1.Selection.Text = File.ReadAllText(Fdialog.FileName);
                _openFile = Fdialog.FileName;
            }
        }
    }
}
