using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chess_console.nsTabuleiro;

namespace chess_console.xadrez
{
    internal class Cavalo : Peca
    {
        public Cavalo(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }
        // 4) custom properties
        // 5) other methods
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] movimentos = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao pos = new Posicao(0, 0);

            // Acima Direita
            pos.DefinirPosicao(Posicao.Linha - 2, Posicao.Coluna + 1);
            if (Tabuleiro.TestePosicaoValida(pos) && PodeMover(pos))
            {
                movimentos[pos.Linha, pos.Coluna] = true;
            }
            // Acima Direita
            pos.DefinirPosicao(Posicao.Linha - 2, Posicao.Coluna - 1);
            if (Tabuleiro.TestePosicaoValida(pos) && PodeMover(pos))
            {
                movimentos[pos.Linha, pos.Coluna] = true;
            }
            // Acima Direita
            pos.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna + 2);
            if (Tabuleiro.TestePosicaoValida(pos) && PodeMover(pos))
            {
                movimentos[pos.Linha, pos.Coluna] = true;
            }
            // Acima Direita
            pos.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna + 2);
            if (Tabuleiro.TestePosicaoValida(pos) && PodeMover(pos))
            {
                movimentos[pos.Linha, pos.Coluna] = true;
            }
            // Acima Direita
            pos.DefinirPosicao(Posicao.Linha + 2, Posicao.Coluna + 1);
            if (Tabuleiro.TestePosicaoValida(pos) && PodeMover(pos))
            {
                movimentos[pos.Linha, pos.Coluna] = true;
            }
            // Acima Direita
            pos.DefinirPosicao(Posicao.Linha +2, Posicao.Coluna - 1);
            if (Tabuleiro.TestePosicaoValida(pos) && PodeMover(pos))
            {
                movimentos[pos.Linha, pos.Coluna] = true;
            }
            // Acima Direita
            pos.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna - 2);
            if (Tabuleiro.TestePosicaoValida(pos) && PodeMover(pos))
            {
                movimentos[pos.Linha, pos.Coluna] = true;
            }
            // Acima Direita
            pos.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna - 2);
            if (Tabuleiro.TestePosicaoValida(pos) && PodeMover(pos))
            {
                movimentos[pos.Linha, pos.Coluna] = true;
            }

            return movimentos;
        }

        public override string ToString()
        {
            return "C";
        }
    }
}
