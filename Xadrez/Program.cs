using System;
using Xadrez.Engine;
using Xadrez.Modelos;

namespace Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            var pecas = FabricaPecas.GerarPecasIniciais();
            var tabuleiro = new Tabuleiro(pecas);
            tabuleiro.Desenhar();
        }
    }
}
