using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chess_console.nsTabuleiro;

namespace chess_console.xadrez
{
    internal class Peao : Peca
    {
        public Peao(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }
        // 4) custom properties
        // 5) other methods
        public override bool PodeMover(Posicao pos)
        {
            Peca peca = Tabuleiro.GetPeca(pos);
            // calcular se esta vazia
            if (peca == null)
            {
                return true;
            }
            return false;
        }
        public bool PodeCapturar(Posicao pos)
        {
            Peca peca = Tabuleiro.GetPeca(pos);
            // calcular se esta vazia
            if (peca != null && peca.Cor != Cor)
            {
                return true;
            }
            return false;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] movimentos = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao pos = new Posicao(0, 0);

            if(Cor == Cor.Branca)
            {
                // Peao branco move pra cima
                pos.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna);
                if (Tabuleiro.TestePosicaoValida(pos) && PodeMover(pos))
                {
                    movimentos[pos.Linha, pos.Coluna] = true;
                    if(QtdMovimentos == 0 && Tabuleiro.TestePosicaoValida(pos) && PodeMover(pos))
                    {
                        // Se primeiro movimento peao pode mover 2 casas
                        movimentos[pos.Linha - 1, pos.Coluna] = true;
                    }
                }

                // Testando possibilidade de captura direita
                pos.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tabuleiro.TestePosicaoValida(pos) && PodeCapturar(pos))
                {
                    movimentos[pos.Linha, pos.Coluna] = true;
                }
                // Testando possibilidade de captura esquerda
                pos.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Tabuleiro.TestePosicaoValida(pos) && PodeCapturar(pos))
                {
                    movimentos[pos.Linha, pos.Coluna] = true;
                }
            }
            else
            {
                // Peao Preto move pra baixo
                pos.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna);
                if (Tabuleiro.TestePosicaoValida(pos) && PodeMover(pos))
                {
                    movimentos[pos.Linha, pos.Coluna] = true;
                    if(QtdMovimentos == 0 && Tabuleiro.TestePosicaoValida(pos) && PodeMover(pos))
                    {
                        // Se primeiro movimento peao pode mover 2 casas
                        movimentos[pos.Linha + 1, pos.Coluna] = true;
                    }
                }
                // Testando possibilidade de captura direita
                pos.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tabuleiro.TestePosicaoValida(pos) && PodeCapturar(pos))
                {
                    movimentos[pos.Linha, pos.Coluna] = true;
                }
                // Testando possibilidade de captura esquerda
                pos.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tabuleiro.TestePosicaoValida(pos) && PodeCapturar(pos))
                {
                    movimentos[pos.Linha, pos.Coluna] = true;
                }
            }
            // Captura apenas na diagonal
            // pode mover se nao existe peca ou se existe peca adversaria
            // na diagonal


            return movimentos;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
