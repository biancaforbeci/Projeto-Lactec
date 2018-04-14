using Controllers;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                btnProcurar.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Cliente não encontrado !");
                MainWindow telaPrincipal = new MainWindow();
                this.Close();
                telaPrincipal.ShowDialog();
            }
        }

        private void btnProcurar_Click(object sender, RoutedEventArgs e)
        {
            
            if ((checkNome.IsEnabled == true) && (VerificaCampos()==true))
            {
              List<Cliente> cli = ClienteController.PesquisarPorNome(txtCampo.Text);
              VerificaExistencia(cli);
            }
            else if((checkID.IsEnabled==true) && (VerificaCampos()==true))
            {
              List<Cliente> cli = ClienteController.ClienteListaID(int.Parse(txtCampo.Text));
              VerificaExistencia(cli);
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
            txtCampo.IsEnabled = false;
        }

        private void checkNome_Unchecked(object sender, RoutedEventArgs e)
        {
            checkID.IsEnabled = true;
            txtCampo.IsEnabled = false;
        }

        private bool VerificaCampos()
        {
            string caracter = txtCampo.Text.Substring(0, 1);
            string verifica = "^[0-9]";
            if ((checkNome.IsEnabled == true) && (Regex.IsMatch(txtCampo.Text, @"^[a-zA-Z]+$")))
           {
                return true;
           }else if((Regex.IsMatch(caracter, verifica) == true) && checkID.IsEnabled==true)
           {
                return true;
           }else
           {
                MessageBox.Show("ERRO, verifique se está correto o que foi digitado.");
                return false;    
           }                     

        }
    }
}
