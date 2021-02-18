using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez.Modelos;

namespace Xadrez.Engine
{
    public class Partida
    {
        public Tabuleiro Tabuleiro { get; set; }

        private bool _jogamAsBrancas = true;

        public void Iniciar()
        {
            _jogamAsBrancas = true;
            do
            {
                Console.Clear();
                Tabuleiro.Desenhar();

                var jogamAsString = _jogamAsBrancas ? "brancas" : "pretas";

                Console.WriteLine($"Jogam as {jogamAsString}. Informe seu lance:");
                var lance = Console.ReadLine().ToLower();

                if(lance == "desisto")
                {
                    Console.WriteLine($"As {jogamAsString} desistiram");
                    break;
                }

                if(lance.Length != 6)
                {
                    Console.WriteLine("Comando inválido. Tecle ENTER para reinserir");
                    Console.ReadLine();
                    continue;
                }

                if (!MoverPeca(lance))
                {
                    Console.ReadLine();
                    continue;
                }

                _jogamAsBrancas = !_jogamAsBrancas;

            } while (true);
        }

        private bool MoverPeca(string lance)
        {
            // 0 -> Peça
            // 1,2 -> Casa de Origem
            // 3 -> Separador
            // 4,5 -> Casa de destino
            var casaOrigem = new CasaTabuleiro(lance[1], lance[2]);
            var casaDestino = new CasaTabuleiro(lance[4], lance[5]);

            var peca = Tabuleiro.Pecas[casaOrigem.Dimensao1, casaOrigem.Dimensao2];

            if(!MovimentoEhValido(peca, casaOrigem, casaDestino))
            {
                Console.WriteLine("Movimento inválido");
                return false;
            }

            Tabuleiro.Pecas[casaDestino.Dimensao1, casaDestino.Dimensao2] = peca;
            Tabuleiro.Pecas[casaOrigem.Dimensao1, casaOrigem.Dimensao2] = null;
            return true;
        }

        private bool MovimentoEhValido(Peca peca, CasaTabuleiro casaOrigem, CasaTabuleiro casaDestino)
        {
            return MovimentoEhValidoDestino(peca, casaDestino) &&
                   MovimentoEhValidoPeca(peca, casaOrigem, casaDestino);
        }

        private bool MovimentoEhValidoDestino(Peca peca, CasaTabuleiro casaDestino)
        {
            var pecaDestino = Tabuleiro.Pecas[casaDestino.Dimensao1, casaDestino.Dimensao2];
            return pecaDestino == null || peca.Cor != pecaDestino.Cor;
        }

        private bool MovimentoEhValidoPeca(Peca peca, CasaTabuleiro casaOrigem, CasaTabuleiro casaDestino)
        {
            var posicoesValidas = new List<CasaTabuleiro>();
            if(peca.Simbolo == 'P')
            {
                if(peca.Cor == ConsoleColor.Black)
                {
                    posicoesValidas.Add(new CasaTabuleiro { Dimensao1 = casaOrigem.Dimensao1 + 1, Dimensao2 = casaOrigem.Dimensao2 });
                    posicoesValidas.Add(new CasaTabuleiro { Dimensao1 = casaOrigem.Dimensao1 + 2, Dimensao2 = casaOrigem.Dimensao2 });
                }
                else
                {
                    posicoesValidas.Add(new CasaTabuleiro { Dimensao1 = casaOrigem.Dimensao1 - 1, Dimensao2 = casaOrigem.Dimensao2 });
                    posicoesValidas.Add(new CasaTabuleiro { Dimensao1 = casaOrigem.Dimensao1 - 2, Dimensao2 = casaOrigem.Dimensao2 });
                }
            }
            if (peca.Simbolo == 'C')
            {
                // Horizontal
                var cima = casaOrigem.Dimensao1 - 2;
                var baixo = casaOrigem.Dimensao1 + 2;
                var esquerda = casaOrigem.Dimensao2 - 1;
                var direita = casaOrigem.Dimensao2 + 1;
                posicoesValidas.Add(new CasaTabuleiro { Dimensao1 = cima, Dimensao2 = esquerda });
                posicoesValidas.Add(new CasaTabuleiro { Dimensao1 = cima, Dimensao2 = direita });
                posicoesValidas.Add(new CasaTabuleiro { Dimensao1 = baixo, Dimensao2 = esquerda });
                posicoesValidas.Add(new CasaTabuleiro { Dimensao1 = baixo, Dimensao2 = direita });

                // Vertical
                esquerda = casaOrigem.Dimensao2 - 2;
                direita = casaOrigem.Dimensao2 + 2;
                cima = casaOrigem.Dimensao1 - 1;
                baixo = casaOrigem.Dimensao1 + 1;
                posicoesValidas.Add(new CasaTabuleiro { Dimensao1 = cima, Dimensao2 = esquerda });
                posicoesValidas.Add(new CasaTabuleiro { Dimensao1 = cima, Dimensao2 = direita });
                posicoesValidas.Add(new CasaTabuleiro { Dimensao1 = baixo, Dimensao2 = esquerda });
                posicoesValidas.Add(new CasaTabuleiro { Dimensao1 = baixo, Dimensao2 = direita });
            }

            return posicoesValidas.Contains(casaDestino);
        }
    }
}
