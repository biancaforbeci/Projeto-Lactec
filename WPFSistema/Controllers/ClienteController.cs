﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class ClienteController
    {
        public void SalvarCliente(Cliente cliente)
        {

            ContextoSingleton.Instancia.Clientes.Add(cliente);
            ContextoSingleton.Instancia.SaveChanges();
        }

        public Cliente PesquisarPorNome(string nome)
        {
            var c = from x in ContextoSingleton.Instancia.Clientes
                    where x.Nome.ToLower().Contains(nome.Trim().ToLower())
                    select x;

            if (c != null)
                return c.FirstOrDefault();
            else
                return null;
        }

        public Cliente PesquisarPorID(int idCliente)
        {
            return ContextoSingleton.Instancia.Clientes.Find(idCliente);
        }

        public void ExcluirCliente(int idCliente)
        {

            Cliente c = ContextoSingleton.Instancia.Clientes.Find(idCliente);

            ContextoSingleton.Instancia.Entry(c).State =
                System.Data.Entity.EntityState.Deleted;

            ContextoSingleton.Instancia.SaveChanges();
        }

        public List<Cliente> ListarClientes()
        {
            return ContextoSingleton.Instancia.Clientes.ToList();
        }
       
    }
}

