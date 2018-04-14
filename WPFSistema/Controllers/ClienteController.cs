using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    /// <summary>
    /// Essa classe serve para intermediar a Model com as Views, realizando processos como salvar, excluir, pesquisar e retornar resultados das buscas no DB.  
    /// </summary>
    public class ClienteController
    {
        /// <summary>
        /// Método que salva um cliente no banco de dados.
        /// </summary>
        /// <param name="cliente"></param>
        public static void SalvarCliente(Cliente cliente)
        {            
            ContextoSingleton.Instancia.Clientes.Add(cliente);
            ContextoSingleton.Instancia.SaveChanges();
        }

        /// <summary>
        /// Método que pesquisa no banco de dados, na tabela de clientes, um nome passado por parâmetro. 
        /// </summary>
        /// <param name="nome"></param>
        /// <returns>Se é encontrado esse cliente pelo nome passado por parâmetro, retorna-se esse numa lista do tipo cliente cadastrado.</returns>
        public static List<Cliente> PesquisarPorNome(string nome)
        {
            var c = from x in ContextoSingleton.Instancia.Clientes
                    where x.Nome.ToLower().Contains(nome.Trim().ToLower())
                    select x;

            if (c != null)
                return c.ToList();
            else
                return null;
        }

        /// <summary>
        /// Método que exclui cliente no banco de dados a partir do ID passado por parâmetro.
        /// </summary>
        /// <param name="idCliente"></param>
        public static void ExcluirCliente(int idCliente)
        {

            Cliente c = ContextoSingleton.Instancia.Clientes.Find(idCliente);

            ContextoSingleton.Instancia.Entry(c).State =
                System.Data.Entity.EntityState.Deleted;

            ContextoSingleton.Instancia.SaveChanges();
        }

        /// <summary>
        /// Método que lista ordenadamente por idade os clientes cadastrados no banco de dados.
        /// </summary>
        /// <returns>Retorna uma lista do tipo clientes cadastrados ordenados por idade.</returns>
        public static List<Cliente> ListarPorOrdenacao()
        {
            var clientes = (from x in ContextoSingleton.Instancia.Clientes
                           orderby x.Idade
                           select x).ToList();

            return clientes;
        }

        /// <summary>
        /// Método que retorna todos os clientes cadastrados no banco de dados.
        /// </summary>
        /// <returns>Retorna uma lista do tipo clientes cadastrados.</returns>
        public static List<Cliente> RetornaItens()
        {
            return ContextoSingleton.Instancia.Clientes.ToList();           
        }

        /// <summary>
        /// Método que busca cliente na tabela através da procura do ID passado por parâmetro.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Se é encontrado o cliente,retorna-se uma lista do tipo cliente cadastrado que possui o ID igual ao passado por parâmetro.</returns>
        public static List<Cliente> ClienteListaID(int id)
        {
            var c = from x in ContextoSingleton.Instancia.Clientes
                    where x.ClienteID.Equals(id)
                    select x;

            if (c != null)
                return c.ToList();
            else
                return null;
        }
    }
}

