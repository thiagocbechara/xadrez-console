using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez.Modelos;

namespace Xadrez.Engine
{
    public static class FabricaPecas
    {
        public static Peca[,] GerarPecasIniciais()
        {
            var pecas = new Peca[8, 8];

            for (var i = 0; i < 8; i++)
            {
                var peaoBranco = new Peao { Cor = ConsoleColor.White };
                var peaoPreto = new Peao { Cor = ConsoleColor.Black };
                pecas[1, i] = peaoPreto;
                pecas[6, i] = peaoBranco;
            }

            var colunaPeca = 0;
            for (var i = 0; i < 2; i++)
            {
                var torrePreto = new Torre { Cor = ConsoleColor.Black };
                var torreBranco = new Torre { Cor = ConsoleColor.White };

                pecas[0, colunaPeca] = torrePreto;
                pecas[7, colunaPeca] = torreBranco;
                colunaPeca += 7;
            }

            colunaPeca = 1;
            for (var i = 0; i < 2; i++)
            {
                pecas[0, colunaPeca] = new Cavalo { Cor = ConsoleColor.Black };
                pecas[7, colunaPeca] = new Cavalo { Cor = ConsoleColor.White };
                colunaPeca += 5;
            }

            colunaPeca = 2;
            for (var i = 0; i < 2; i++)
            {
                var bispoBranco = new Bispo { Cor = ConsoleColor.White };
                var bispoPreto = new Bispo { Cor = ConsoleColor.Black };

                pecas[0, colunaPeca] = bispoPreto;
                pecas[7, colunaPeca] = bispoBranco;
                colunaPeca += 3;
            }

            pecas[0, 4] = new Rei { Cor = ConsoleColor.Black };
            pecas[7, 4] = new Rei { Cor = ConsoleColor.White };

            pecas[0, 3] = new Rainha { Cor = ConsoleColor.Black };
            pecas[7, 3] = new Rainha { Cor = ConsoleColor.White };

            return pecas;
        }
    }
}
