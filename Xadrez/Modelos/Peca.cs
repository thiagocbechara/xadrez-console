using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez.Modelos
{
    public abstract class Peca
    {
        public Peca(char simbolo)
        {
            Simbolo = simbolo;
        }

        public char Simbolo { get; private set; }
        public ConsoleColor Cor { get; set; }
    }
}
