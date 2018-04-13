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
            txtCampo.IsEnabled = false;
            btnProcurar.IsEnabled = false;
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
            txtCampo.IsEnabled = true;
            btnProcurar.IsEnabled = true;
        }

        private void checkNome_Checked(object sender, RoutedEventArgs e)
        {
            checkID.IsEnabled = false;
            txtCampo.IsEnabled = true;
            btnProcurar.IsEnabled = true;
        }

        private void VerificaExistencia(List<Cliente> cli)
        {
            if (cli.Count > 0)
            {
                gridMostrar.ItemsSource = cli;
            }
            else
            {
                MessageBox.Show("Cliente não encontrado !");
                MainWindow telaPrincipal = new MainWindow();
                telaPrincipal.ShowDialog();
                this.Close();
            }
        }

        private void btnProcurar_Click(object sender, RoutedEventArgs e)
        {
            if (txtCampo.Text != null)
            {
                if (checkNome.IsEnabled == true)
                {
                    List<Cliente> cli = ClienteController.PesquisarPorNome(txtCampo.Text);
                    VerificaExistencia(cli);
                }
                else
                {
                    List<Cliente> listaID = ClienteController.ClienteListaID(int.Parse(txtCampo.Text));
                    VerificaExistencia(listaID);
                }
            }
            else
            {
                MessageBox.Show("Erro, campo em branco !", "ERRO");
            }
        }

        private void gridMostrar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (gridMostrar.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Confirma a exclusão do item " + ((Cliente)gridMostrar.SelectedItem).Nome + " ?", "Exclusão", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        int id = ((Cliente)gridMostrar.SelectedItem).ClienteID;
                        ClienteController.ExcluirCliente(id);
                        MessageBox.Show("Cliente excluído com sucesso");
                    }
                    catch(Exception erro)
                    {
                        MessageBox.Show("ERRO: " + erro);
                    }
                }
            }
        }

        private void checkID_Unchecked(object sender, RoutedEventArgs e)
        {
            checkNome.IsEnabled = true;
        }

        private void checkNome_Unchecked(object sender, RoutedEventArgs e)
        {
            checkID.IsEnabled = true;
        }
    }
}
