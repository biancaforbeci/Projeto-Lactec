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

namespace WPFSistema
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ItemCadastrar_Click(object sender, RoutedEventArgs e)
        {
            //abrindo tela de cadastro de clientes e fechando a tela atual.
            CadastroCliente telaCadastro = new CadastroCliente();
            this.Close();
            telaCadastro.ShowDialog();
        }

        private void ItemExcluir_Click(object sender, RoutedEventArgs e)
        {
            //abrindo tela de cadastro de clientes e fechando a tela atual.
            ExcluirCliente telaExcluir = new ExcluirCliente();
            this.Close();
            telaExcluir.ShowDialog();
        }

        private void ItemBuscaClientes_Click(object sender, RoutedEventArgs e)
        {
            //abrindo tela de busca por ID de clientes e fechando a tela atual.
            BuscaClientes telaBusca = new BuscaClientes();
            this.Close();
            telaBusca.ShowDialog();
        }

        private void ItemListasClientes_Click(object sender, RoutedEventArgs e)
        {
            //abrindo tela de listagem de clientes e fechando a tela atual.
            ListagemClientes telaListas = new ListagemClientes();
            this.Close();
            telaListas.ShowDialog();
        }
    }
}
