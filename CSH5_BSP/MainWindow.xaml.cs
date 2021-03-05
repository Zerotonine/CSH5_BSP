using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CSH5_BSP
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCheckString_Click(object sender, RoutedEventArgs e)
        {
            if (CheckTextBoxes())
            {
                RegExinator regExinator5000 = new RegExinator(txtText.Text, txtRegEx.Text.Trim());

                if (regExinator5000.IsMatch())
                {
                    lstResults.Items.Clear();
                    int i = 1;
                    foreach (string s in regExinator5000)
                    {
                        lstResults.Items.Add($"Treffer {i++} Inhalt = {s}");
                    }
                }
                else
                {
                    MessageBox.Show("RegEx ergab keine Treffer!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        bool CheckTextBoxes()
        {
            if (String.IsNullOrEmpty(txtText.Text))
            {
                MessageBox.Show("Kein String zum Durchsuchen angebeben!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (String.IsNullOrEmpty(txtRegEx.Text))
            {
                MessageBox.Show("Kein RegEx angebeben!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtText.Text = "";
            txtRegEx.Text = "";
            lstResults.Items.Clear();
        }
    }
}
