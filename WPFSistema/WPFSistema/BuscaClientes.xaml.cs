using Controllers;
using Models;
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
using System.Windows.Shapes;

namespace WPFSistema
{
    /// <summary>
    /// Interaction logic for BuscaClientes.xaml
    /// </summary>
    public partial class BuscaClientes : Window
    {
        public BuscaClientes()
        {
            InitializeComponent();
        }

        private void checkID_Checked(object sender, RoutedEventArgs e)
        {
            checkNome.IsEnabled = false;
            //Cliente cli =ClienteController.PesquisarPorID(int.Parse(txtCampo.Text));

           // if (cli != null)
            //{
                
            //}
            //else
            //{
              //  MessageBox.Show("Cliente não encontrado !");
                //this.Close();
             //   MainWindow telaPrincipal = new MainWindow();
               // telaPrincipal.ShowDialog();
           // }

        }

        private void checkNome_Checked(object sender, RoutedEventArgs e)
        {
            checkID.IsEnabled = false;
            List<Cliente> cli = ClienteController.PesquisarPorNome(txtCampo.Text);

            if (cli != null)
            {

            }
            else
            {
                MessageBox.Show("Cliente não encontrado !");
                this.Close();
                MainWindow telaPrincipal = new MainWindow();
                telaPrincipal.ShowDialog();
            }
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            //fechando tela de busca e voltando a tela principal.
            MainWindow telaPrincipal = new MainWindow();
            this.Close();
            telaPrincipal.ShowDialog();
        }
    }
}
