using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Essa classe possui os atributos que um cliente têm, sendo a tabela CLientes do banco de dados.
    /// </summary>
    public class Cliente
    {
        public int ClienteID { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Telefone { get; set; }
    }
}
