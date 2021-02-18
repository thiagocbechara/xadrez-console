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

            var partida = new Partida();
            partida.Tabuleiro = new Tabuleiro(pecas);
            partida.Iniciar();
        }
    }
}
