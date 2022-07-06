using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorCMD
{
    internal interface IEstoque
    {
        void Exibir();

        void AdicionarSaida();

        void AdicionarEntrada();
    }
}
