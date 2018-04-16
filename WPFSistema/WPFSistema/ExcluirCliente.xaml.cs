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
    /// Essa classe é referente a tela de exclusão de clientes com os eventos dos cliques nos botões.
    /// </summary>
    public partial class ExcluirCliente : Window
    {
        /// <summary>
        /// Construtor que inicializa componentes.
        /// </summary>
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
            //quando é marcado a exclusão por ID, o botão procurar e textbox é ativado e botão de check por nome é desativado.
            checkNome.IsEnabled = false;
            txtCampo.IsEnabled = true;
            btnProcurar.IsEnabled = true;
        }

        private void checkNome_Checked(object sender, RoutedEventArgs e)
        {
            //quando é marcado a exclusão por nome, o botão procurar e textbox é ativado e botão de check por ID é desativado.
            checkID.IsEnabled = false;
            txtCampo.IsEnabled = true;
            btnProcurar.IsEnabled = true;
        }

        private void VerificaExistencia(List<Cliente> cli)
        {
            if (cli.Count > 0)
            {
                gridMostrar.ItemsSource = cli;  // se lista está com itens é mostrado no datagrid.
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
              List<Cliente> cli = ClienteController.PesquisarPorNome(txtCampo.Text); //Envia para controler o campo digitado.
              VerificaExistencia(cli); //verifica se lista contém resultado
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
                MessageBoxResult result = MessageBox.Show("Confirma a exclusão do cliente " + ((Cliente)gridMostrar.SelectedItem).Nome + " ?", "Exclusão", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {      //Se confirmado a exclusão é pego o ID do cliente da linha selecionada.
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
            if ((checkNome.IsEnabled == true) && (Regex.IsMatch(txtCampo.Text, @"^[a-zA-Z]+$"))) //verifica se o check por nome está ativo e vê se campo é caracter.
            {
                return true;
           }else if((Regex.IsMatch(caracter, verifica)  && checkID.IsEnabled==true)) //verifica se o check por ID está ativo e vê se campo é número.
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
