using Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Controllers
{
    public class ContextoSingleton
    {
          private static Contexto instancia;

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

