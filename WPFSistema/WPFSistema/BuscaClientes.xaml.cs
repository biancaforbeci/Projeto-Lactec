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
            //Desabilitando campos da parte busca por nome para usuário não mexer.
            checkNome.IsEnabled = false;
            txtCampo.IsEnabled = false;
            btnPesquisaNome.IsEnabled = false;
            gridMostrar.IsEnabled = false;
        }

        private void checkNome_Checked(object sender, RoutedEventArgs e)
        {
            //Desabilitando campos da parte busca por ID para usuário não mexer.
            checkID.IsEnabled = false;
            txtCampoID.IsEnabled = false;
            btnPesquisaID.IsEnabled = false;
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            //fechando tela de busca e voltando a tela principal.
            MainWindow telaPrincipal = new MainWindow();
            this.Close();
            telaPrincipal.ShowDialog();
        }

        private void btnPesquisaNome_Click(object sender, RoutedEventArgs e)
        {
            List<Cliente> cli = ClienteController.PesquisarPorNome(txtCampo.Text);  //Enviando para controller o nome para pesquisar e retorna cliente. 

            if (cli.Count > 0)
            {
                gridMostrar.ItemsSource = cli;  // se a lista de cliente existe, mostra no datagrid.
            }else
            {
                MensagemErro();
            }
        }

        private void btnPesquisaID_Click(object sender, RoutedEventArgs e)
        {
            Cliente cli = ClienteController.PesquisarPorID(int.Parse(txtCampoID.Text));  // envia o ID digitado para a controller retornar um cliente.
            
            if (cli!=null)
           {
                txtIDResult.Text= cli.ClienteID.ToString();  //Se cliente existe é passado cada conteúdo do cliente para as textbox.
                txtNomeResult.Text = cli.Nome;
                txtIdadeResult.Text = cli.Idade.ToString();
                txtTelefoneResult.Text = cli.Telefone;
            }else
            {
                MensagemErro();
            }
        }

        private void MensagemErro()
        {
            MessageBox.Show("Cliente não encontrado !");   // se não existir nada na lista é mostrado mensagem .
            this.Close();
            MainWindow telaPrincipal = new MainWindow();  //volta para página principal.
            telaPrincipal.ShowDialog();
        }

        private void btnInicializar_Click(object sender, RoutedEventArgs e)
        {
            BuscaClientes bc= new BuscaClientes();
            this.Close();
            bc.ShowDialog(); //abre nova janela para nova busca.
        }
    }       
}

