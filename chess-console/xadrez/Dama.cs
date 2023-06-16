using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chess_console.nsTabuleiro;

namespace chess_console.xadrez
{
    internal class Dama : Peca
    {
        public Dama(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {

        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] movimentos = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao pos = new Posicao(0, 0);

            // Teste Nordeste
            pos.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna + 1);
            while (Tabuleiro.TestePosicaoValida(pos) && PodeMover(pos))
            {
                movimentos[pos.Linha, pos.Coluna] = true;

                Peca p = Tabuleiro.GetPeca(pos);
                if (p != null && p.Cor != Cor)
                {
                    break;
                }
                pos.DefinirPosicao(pos.Linha - 1, pos.Coluna + 1);
            }
            // Teste Noroeste
            pos.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna - 1);
            while (Tabuleiro.TestePosicaoValida(pos) && PodeMover(pos))
            {
                movimentos[pos.Linha, pos.Coluna] = true;

                Peca p = Tabuleiro.GetPeca(pos);
                if (p != null && p.Cor != Cor)
                {
                    break;
                }
                pos.DefinirPosicao(pos.Linha - 1, pos.Coluna - 1);
            }
            // Teste Sudeste
            pos.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna + 1);
            while (Tabuleiro.TestePosicaoValida(pos) && PodeMover(pos))
            {
                movimentos[pos.Linha, pos.Coluna] = true;

                Peca p = Tabuleiro.GetPeca(pos);
                if (p != null && p.Cor != Cor)
                {
                    break;
                }
                pos.DefinirPosicao(pos.Linha + 1, pos.Coluna + 1);
            }
            // Teste Sudeste
            pos.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna - 1);
            while (Tabuleiro.TestePosicaoValida(pos) && PodeMover(pos))
            {
                movimentos[pos.Linha, pos.Coluna] = true;

                Peca p = Tabuleiro.GetPeca(pos);
                if (p != null && p.Cor != Cor)
                {
                    break;
                }
                pos.DefinirPosicao(pos.Linha + 1, pos.Coluna - 1);
            }
            // Teste Acima
            pos.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna);
            while (Tabuleiro.TestePosicaoValida(pos) && PodeMover(pos))
            {
                movimentos[pos.Linha, pos.Coluna] = true;

                Peca p = Tabuleiro.GetPeca(pos);
                if (p != null && p.Cor != Cor)
                {
                    break;
                }
                pos.DefinirPosicao(pos.Linha - 1, pos.Coluna);
            }

            // abaixo
            pos.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna);
            while (Tabuleiro.TestePosicaoValida(pos) && PodeMover(pos))
            {
                movimentos[pos.Linha, pos.Coluna] = true;

                Peca p = Tabuleiro.GetPeca(pos);
                if (p != null && p.Cor != Cor)
                {
                    break;
                }
                pos.DefinirPosicao(pos.Linha + 1, pos.Coluna);
            }

            // direita
            pos.DefinirPosicao(Posicao.Linha, Posicao.Coluna + 1);
            while (Tabuleiro.TestePosicaoValida(pos) && PodeMover(pos))
            {
                movimentos[pos.Linha, pos.Coluna] = true;

                Peca p = Tabuleiro.GetPeca(pos);
                if (p != null && p.Cor != Cor)
                {
                    break;
                }
                pos.DefinirPosicao(pos.Linha, pos.Coluna + 1);
            }

            // abaixo
            pos.DefinirPosicao(Posicao.Linha, Posicao.Coluna - 1);
            while (Tabuleiro.TestePosicaoValida(pos) && PodeMover(pos))
            {
                movimentos[pos.Linha, pos.Coluna] = true;

                Peca p = Tabuleiro.GetPeca(pos);
                if (p != null && p.Cor != Cor)
                {
                    break;
                }
                pos.DefinirPosicao(pos.Linha, pos.Coluna - 1);
            }

            return movimentos;
        }

        public override string ToString()
        {
            return "D";
        }
    }
}
