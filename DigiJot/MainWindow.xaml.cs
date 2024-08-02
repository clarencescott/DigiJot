using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Documents.DocumentStructures;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DigiJot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            loadList();
        }

        private void Add_BTN(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(jotTitle.Text))
            {
                jotBox.Items.Add(jotTitle.Text);
                jotTitle.Clear();
            }
        }

        private void DEL_BTN(object sender, RoutedEventArgs e)
        {
            if (jotBox.SelectedItem != null)
            {
                jotBox.Items.Remove(jotBox.SelectedItem);
            }
        }
        //Saving the list for upload in future
        private void SaveList()
        {
            using (StreamWriter writer = new StreamWriter("list.txt"))
            {
                foreach (var item in jotBox.Items)
                {
                    writer.WriteLine(item.ToString());
                }
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            SaveList();
            base.OnClosing(e);
        }

        private void loadList()
        {
            if (File.Exists("list.txt"))
            {
                using (StreamReader reader = new StreamReader("list.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        jotBox.Items.Add(line);
                    }
                }
            }
        }
    }
}