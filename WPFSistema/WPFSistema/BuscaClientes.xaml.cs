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
    /// Interaction logic for BuscaClientes.xaml
    /// </summary>
    public partial class BuscaClientes : Window
    {
        public BuscaClientes()
        {
            InitializeComponent();
            btnPesquisa.IsEnabled = false;
            txtCampo.IsEnabled = false;
        }

        private void checkID_Checked(object sender, RoutedEventArgs e)
        {
            //Desabilitando campos da parte busca por nome para usuário não mexer.
            checkNome.IsEnabled = false;
            txtCampo.IsEnabled = true;
            btnPesquisa.IsEnabled = true;
        }

        private void checkNome_Checked(object sender, RoutedEventArgs e)
        {
            //Desabilitando campo da parte busca por ID para usuário não mexer.
            checkID.IsEnabled = false;
            txtCampo.IsEnabled = true;
            btnPesquisa.IsEnabled = true;
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            //fechando tela de busca e voltando a tela principal.
            MainWindow telaPrincipal = new MainWindow();
            this.Close();
            telaPrincipal.ShowDialog();
        }

        private void btnPesquisa_Click(object sender, RoutedEventArgs e)
        {
            string caracter = txtCampo.Text.Substring(0, 1);
            string verifica = "^[0-9]";

            if (checkNome.IsEnabled==true)
            {
               if((!Regex.IsMatch(txtCampo.Text, @"^[a-zA-Z]+$")))
               {
                    MessageBox.Show("Só podem existir caracteres.");
               }
                else
               {
                   List<Cliente> cli = ClienteController.PesquisarPorNome(txtCampo.Text);  //Enviando para controller o nome para pesquisar e retorna cliente. 
                   VerificaLista(cli); //envia para verificação a lista
               }          
                
            }else if (Regex.IsMatch(caracter, verifica) == true)
            {
                List<Cliente> cli = ClienteController.ClienteListaID(int.Parse(txtCampo.Text));  //Enviando para controller o nome para pesquisar e retorna cliente. 
                VerificaLista(cli); //envia para verificação a lista
            }
            else
            {
                MessageBox.Show("Só podem existir números.");
            }                       
        }        

        private void MensagemErro()
        {
            MessageBox.Show("Cliente não encontrado !");  // se não existir nada na lista é mostrado mensagem .
            MainWindow telaPrincipal = new MainWindow();  //volta para página principal.
            this.Close();
            telaPrincipal.ShowDialog();
        }

        private void btnInicializar_Click(object sender, RoutedEventArgs e)
        {
            BuscaClientes bc= new BuscaClientes();
            this.Close();
            bc.ShowDialog(); //abre nova janela para nova busca.
        }

        private void VerificaLista(List<Cliente> cli)
        {
            if (cli.Count > 0)  //verifica se lista está vazia.
            {
                gridMostrar.ItemsSource = cli;
            }
            else
            {
                MensagemErro();
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
    }       
}

