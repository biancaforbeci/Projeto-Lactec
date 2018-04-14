using Controllers;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
    /// Essa classe é referente a tela de Listagem de clientes com os eventos dos cliques nos botões.
    /// </summary>
    public partial class ListagemClientes : Window
    {
        /// <summary>
        /// Construtor que inicializa componentes.
        /// </summary>
        public ListagemClientes()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            //Voltando a tela principal e fechando a tela de listagem.
            MainWindow telaPrincipal = new MainWindow();
            this.Close();
            telaPrincipal.ShowDialog();
        }

        private void btnListarSimples_Click(object sender, RoutedEventArgs e)
        {
            btnListarPorIdade.IsEnabled = false; // desabilita botão de lista ordenada.
            List<Cliente> lista =ClienteController.RetornaItens();// instanciando lista com o retorno de uma lista de clientes com ID e nome do banco 
            gridMostrar.Columns.RemoveAt(3); //removendo coluna de telefone
            gridMostrar.Columns.RemoveAt(2); //removendo coluna de idade.
            gridMostrar.ItemsSource = lista; //enviando lista para datagrid.
        }

        private void btnListarPorIdade_Click(object sender, RoutedEventArgs e)
        {
            btnListarSimples.IsEnabled = false; //desabilita botão de lista simples.
            List<Cliente> lista = ClienteController.ListarPorOrdenacao();   // instanciando lista com o retorno de uma lista de clientes com ID e nome do banco 
            gridMostrar.ItemsSource = lista; //enviando lista para datagrid.
        }

        private void btnNovaListagem_Click(object sender, RoutedEventArgs e)
        {
            ListagemClientes lc = new ListagemClientes();
            this.Close();
            lc.ShowDialog(); //abre nova janela para nova busca.
        }
    }
}
