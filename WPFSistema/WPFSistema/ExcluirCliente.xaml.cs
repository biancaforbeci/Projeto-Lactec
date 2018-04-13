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
    /// Interaction logic for ExcluirCliente.xaml
    /// </summary>
    public partial class ExcluirCliente : Window
    {
        public ExcluirCliente()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            //fechando tela de exclusão e voltando a tela principal.
            MainWindow telaPrincipal = new MainWindow();
            this.Close();
            telaPrincipal.ShowDialog();
        }

        private void checkID_Checked(object sender, RoutedEventArgs e)
        {
            checkNome.IsEnabled = false;
        }

        private void checkNome_Checked(object sender, RoutedEventArgs e)
        {
            checkID.IsEnabled = false;           
        }

        private void VerificaExistencia(List<Cliente> cli)
        {
            if(cli.Count > 0)
            {
                gridMostrar.ItemsSource = cli;
            }
            else
            {
                MessageBox.Show("Cliente não encontrado !");
                this.Close();
                MainWindow telaPrincipal = new MainWindow();
                telaPrincipal.ShowDialog();
            }

        }

        private void btnProcurar_Click(object sender, RoutedEventArgs e)
        {
            if (checkNome.IsEnabled == true)
            {
                List<Cliente> cli = ClienteController.PesquisarPorNome(txtCampo.Text);
                VerificaExistencia(cli);
            }
            else
            {
             //   List<Cliente> cli = ClienteController.PesquisarPorID(int.Parse(txtCampo.Text));
             //   VerificaExistencia(cli);
            }
            
        }

        private void gridMostrar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (gridMostrar.SelectedItem != null)
            {
                
                ClienteController.ExcluirCliente(g)
            }
        }
    }
}
