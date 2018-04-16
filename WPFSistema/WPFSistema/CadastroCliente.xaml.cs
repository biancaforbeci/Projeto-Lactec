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
    /// Essa classe é referente a tela de cadastro de clientes com os eventos dos cliques nos botões.
    /// </summary>
    public partial class CadastroCliente : Window
    {
        /// <summary>
        /// Construtor que inicializa componentes.
        /// </summary>
        public CadastroCliente()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            //Criando novo cliente e chamando o método de salvar
            if (VerificandoCampos() == true)
            {
                Cliente cliente = SalvaCliente();
                ClienteController.SalvarCliente(cliente);
            }    
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

        private bool VerificandoCampos()
        {
            string caracterIdade = txtIdade.Text.Substring(0, 1);
            string caracterTelefone = txtTelefone.Text.Substring(0, 1);
            string verifica = "^[0-9]";

            if ((!Regex.IsMatch(txtNome.Text, @"^[a-zA-Z]+$") || (txtNome.Text.Trim().Equals(""))))
            {
                MessageBox.Show("Só podem existir caracteres e não pode estar vazio.");
                return false;
            }
            else if (!Regex.IsMatch(caracterIdade, verifica) || (txtIdade.Text.Trim().Equals("")))
            {
                MessageBox.Show("Só podem existir números no campo idade e não pode estar vazio.");
                return false;
            }
            else if (!Regex.IsMatch(caracterTelefone, verifica) || (txtTelefone.Text.Trim().Equals("")))
            {
                MessageBox.Show("Só podem existir números no campo telefone e não pode estar vazio.");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
