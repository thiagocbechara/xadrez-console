using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez.Modelos;

namespace Xadrez.Engine
{
    public class Tabuleiro
    {
        public Tabuleiro(Peca[,] pecas)
        {
            Pecas = pecas;
        }

        public Peca[,] Pecas { get; private set; }

        public void Desenhar()
        {
            for (var i = -1; i <= 8; i++)
            {
                for (var j = -1; j <= 8; j++)
                {
                    var casa = ' ';
                    if (i == 8 || j == 8 || i == -1 || j == -1)
                    {
                        if (!((i == -1 && j == -1) ||
                            (i == -1 && j == 8) ||
                            (i == 8 && j == -1) ||
                            (i == 8 && j == 8)))
                        {
                            if (i == -1 || i == 8)
                            {
                                casa = (char)(97 + j);
                            }
                            if (j == -1 || j == 8)
                            {
                                casa = char.Parse((8 - i).ToString());
                            }
                        }

                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                    }
                    else
                    {
                        if (Pecas[i, j] != null)
                        {
                            casa = Pecas[i, j].Simbolo;
                            Console.ForegroundColor = Pecas[i, j].Cor;
                        }

                        if ((i + j) % 2 == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                        }
                    }

                    Console.Write($" {casa} ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
    }
}
