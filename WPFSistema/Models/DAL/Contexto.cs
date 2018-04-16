using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAL
{
    /// <summary>
    /// Essa classe possui herança com o DbContext, sendo o "espelho" do banco de dados, no qual é declarada a tabela clientes.
    /// </summary>
    /// <remarks>No EntityFramework é criado automaticamente a tabela clientes e a string de conexão é stringConn </remarks>
    public class Contexto : DbContext
    {
        /// <summary>
        /// Construtor que herda a conexão com o DB através da string de conexão. 
        /// </summary>
        /// <remarks>Possui dentro dele uma inicialização do Contexto, que deve dropar quando model cliente for alterada. </remarks>
        public Contexto() : base("stringConn")
        {
            
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
