using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez.Modelos
{
    public class CasaTabuleiro
    {
        public CasaTabuleiro() { }

        public CasaTabuleiro(char posicao1, char posicao2)
        {
            Dimensao1 = 8 - int.Parse(posicao2.ToString());
            Dimensao2 = posicao1 - 97;
        }

        public int Dimensao1 { get; set; }
        public int Dimensao2 { get; set; }

        public override bool Equals(object obj)
        {

            if(obj == null || !(obj is CasaTabuleiro))
            {
                return false;
            }
            var casaTabuleiro = (CasaTabuleiro)obj;
            return Dimensao1 == casaTabuleiro.Dimensao1 && Dimensao2 == casaTabuleiro.Dimensao2;
        }
    }
}
