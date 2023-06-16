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
        private PartidaDeXadrez Partida;
        public Peao(Cor cor, Tabuleiro tabuleiro,PartidaDeXadrez partida) : base(cor, tabuleiro)
        {
            Partida = partida;
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

            // #jogadaespecial en passant
            // peao captura peao
            // condicoes
            // peao A posicionado a duas linhas do peao B
            // peao A posicionado a 1 coluna de diferenca
            // peao B com 0 movimentos
            // peao B movimenta 2 casas no primeiro movimento
            // peao A pode, apenas na jogada imediata, capturar
            // peao B na diagonal
            Peca? alvo = Partida.pecaPassivelDeEnPassant;
            if (alvo != null && alvo.Cor != Cor)
            {
                if(
                    Math.Abs(alvo.Posicao.Coluna - Posicao.Coluna) == 1
                    && alvo.Posicao.Linha == Posicao.Linha)
                {
                    if(alvo.Cor == Cor.Branca)
                    {
                        // linha + 1, coluna = coluna do alvo
                        movimentos[alvo.Posicao.Linha + 1,alvo.Posicao.Coluna] = true;
                    }
                    else
                    {
                        movimentos[alvo.Posicao.Linha - 1, alvo.Posicao.Coluna] = true;
                    }
                }
            }

            return movimentos;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
