using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class ClienteController
    {
        public static void SalvarCliente(Cliente cliente)
        {            
            ContextoSingleton.Instancia.Clientes.Add(cliente);
            ContextoSingleton.Instancia.SaveChanges();
        }

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

        public static void ExcluirCliente(int idCliente)
        {

            Cliente c = ContextoSingleton.Instancia.Clientes.Find(idCliente);

            ContextoSingleton.Instancia.Entry(c).State =
                System.Data.Entity.EntityState.Deleted;

            ContextoSingleton.Instancia.SaveChanges();
        }

        public static List<Cliente> ListarPorOrdenacao()
        {
            var clientes = (from x in ContextoSingleton.Instancia.Clientes
                           orderby x.Idade
                           select x).ToList();

            return clientes;
        }

        public static List<Cliente> RetornaItens()
        {
            return ContextoSingleton.Instancia.Clientes.ToList();           
        }

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

