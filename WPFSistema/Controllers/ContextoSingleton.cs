using Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Controllers
{
    /// <summary>
    /// Essa classe possui uma instância do banco de dados, sendo o pattern do Contexto (para Singleton).
    /// </summary>
    /// <remarks>Se instância for nula, é criado um novo contexto e é colocada dentro da váriavel estática instância.</remarks>
    public class ContextoSingleton
    {
            private static Contexto instancia;

            /// <summary>
            /// Método que retorna uma instância do contexto do banco de dados.
            /// </summary>
            public static Contexto Instancia
            {
                get
                {
                    if (instancia == null)
                        instancia = new Contexto();

                    return instancia;
                }

            }

            private ContextoSingleton()
            {

            }


        }
}

