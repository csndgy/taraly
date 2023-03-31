using Osztályok;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        List<Tartaly> tartalyok = new List<Tartaly>();
        Tartaly ujTest;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnFelvesz_Click(object sender, RoutedEventArgs e)
        {

            Tartaly ujTest;
            if (rdoKocka.IsChecked == true)
            {
                ujTest = new Tartaly(txtNev.Text);
            }
            else { ujTest = new Tartaly(txtNev.Text, Convert.ToInt32(txtAel.Text), Convert.ToInt32(txtBel.Text), Convert.ToInt32(txtCel.Text)); }
            lbTartalyok.Items.Add(ujTest.Info());
            tartalyok.Add(ujTest);
        }

        private void btnRogzit_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter("tartalyok.txt", append: true);
            foreach (Tartaly aktElem in tartalyok)
            {
                String csvsor = $"{aktElem.Nev};{aktElem.aEl};{aktElem.bEl};{aktElem.cEl},{aktElem.AktLiter}";
                sw.WriteLine(csvsor);
            }
            sw.Close();
        }

        private void btnDuplaz_Click(object sender, RoutedEventArgs e)
        {
            if (lbTartalyok.SelectedIndex == -1)
            {
                MessageBox.Show("Nincs kiválasztva semmi!", "hiba :(", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                tartalyok[lbTartalyok.SelectedIndex].DuplazMeretet();
                lbTartalyok.Items[lbTartalyok.SelectedIndex] = tartalyok[lbTartalyok.SelectedIndex].Info();
            }   
        }

        private void btnLeenged_Click(object sender, RoutedEventArgs e)
        {
            if (lbTartalyok.SelectedIndex == -1)
            {
                MessageBox.Show("nem valasztottad ki", "valami nem oksi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                tartalyok[lbTartalyok.SelectedIndex].TeljesLeengedes();
                lbTartalyok.Items[lbTartalyok.SelectedIndex] = tartalyok[lbTartalyok.SelectedIndex].Info();
            }
        }

        private void btntolt_Click(object sender, RoutedEventArgs e)
        {
            if (lbTartalyok.SelectedIndex == -1)
            {
                MessageBox.Show("nem joxd", "hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                tartalyok[lbTartalyok.SelectedIndex].Tolt(Convert.ToDouble(txtMennyitTolt.Text));
                lbTartalyok.Items[lbTartalyok.SelectedIndex] = tartalyok[lbTartalyok.SelectedIndex].Info();
                

            }
        } 

        private void rdoTeglatest_Checked(object sender, RoutedEventArgs e)
        {
            if (rdoTeglatest.IsChecked == true)
            {
                txtAel.IsEnabled = true;
                txtAel.Text = "";
                txtBel.IsEnabled = true;
                txtBel.Text = "";
                txtCel.IsEnabled = true;
                txtCel.Text = "";
            }
        }

        private void rdoKocka_Checked(object sender, RoutedEventArgs e)
        {
            ujTest = new Tartaly("Kocka");

            if (rdoKocka.IsChecked == true)
            {
                txtAel.IsEnabled = false;
                txtAel.Text = "10";
                txtBel.IsEnabled = false;
                txtBel.Text = "10";
                txtCel.IsEnabled = false;
                txtCel.Text = "10";
            }
        }
    }
}
