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
    /// Interaction logic for CadastroCliente.xaml
    /// </summary>
    public partial class CadastroCliente : Window
    {
        public CadastroCliente()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            //Criando novo cliente e chamando o método de salvar
            Cliente cliente = SalvaCliente();
            ClienteController.SalvarCliente(cliente);            
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            //fechando tela de cadastro e voltando a tela principal.
            MainWindow telaPrincipal = new MainWindow();
            this.Close();
            telaPrincipal.ShowDialog();
        }

        private Cliente SalvaCliente()
        {
            //Criando novo cliente e adicionando cada TextBox aos atributos.
            Cliente cli = new Cliente();
            cli.Nome = txtNome.Text;
            cli.Idade = int.Parse(txtIdade.Text);
            cli.Telefone = txtTelefone.Text;
            return cli;
        }

    }
}
