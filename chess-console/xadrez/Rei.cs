using chess_console.nsTabuleiro;

namespace chess_console.xadrez
{
    internal class Rei : Peca
    {
        private PartidaDeXadrez Partida;
        // 3) constructor
        public Rei(Cor cor, Tabuleiro tabuleiro, PartidaDeXadrez partida) : base(cor, tabuleiro)
        {
            Partida = partida;
        }

        public override string ToString()
        {
            return "R";
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] Movimentacoes = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao posTeste = new Posicao(Posicao.Linha, Posicao.Coluna);

            // testando as movimentacoes possiveis para o Rei

            // Norte
            posTeste.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna);

            if (Tabuleiro.TestePosicaoValida(posTeste) && PodeMover(posTeste))
            {
                Movimentacoes[posTeste.Linha, posTeste.Coluna] = true;
            }

            // Nordeste
            posTeste.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna + 1);

            if (Tabuleiro.TestePosicaoValida(posTeste) && PodeMover(posTeste))
            {
                Movimentacoes[posTeste.Linha, posTeste.Coluna] = true;
            }
            // Leste
            posTeste.DefinirPosicao(Posicao.Linha, Posicao.Coluna + 1);

            if (Tabuleiro.TestePosicaoValida(posTeste) && PodeMover(posTeste))
            {
                Movimentacoes[posTeste.Linha, posTeste.Coluna] = true;
            }
            // Sudeste
            posTeste.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna + 1);

            if (Tabuleiro.TestePosicaoValida(posTeste) && PodeMover(posTeste))
            {
                Movimentacoes[posTeste.Linha, posTeste.Coluna] = true;
            }
            // Sul
            posTeste.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna);

            if (Tabuleiro.TestePosicaoValida(posTeste) && PodeMover(posTeste))
            {
                Movimentacoes[posTeste.Linha, posTeste.Coluna] = true;
            }
            // Sudoeste
            posTeste.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna - 1);

            if (Tabuleiro.TestePosicaoValida(posTeste) && PodeMover(posTeste))
            {
                Movimentacoes[posTeste.Linha, posTeste.Coluna] = true;
            }
            // Oeste
            posTeste.DefinirPosicao(Posicao.Linha, Posicao.Coluna - 1);

            if (Tabuleiro.TestePosicaoValida(posTeste) && PodeMover(posTeste))
            {
                Movimentacoes[posTeste.Linha, posTeste.Coluna] = true;
            }
            // Noroeste
            posTeste.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna - 1);

            if (Tabuleiro.TestePosicaoValida(posTeste) && PodeMover(posTeste))
            {
                Movimentacoes[posTeste.Linha, posTeste.Coluna] = true;
            }


            // #jogadaespecial Roque pequeno
            // primeiro movimento do rei
            // rei nao esta em xeque
            // primeiro movimento da torre
            // casas entre rei e torre desobstruidas
            // resultado da jogada nao pode se colocar em xeque
            if (QtdMovimentos == 0 && !Partida.Xeque)
            {
                Posicao posicaoTorreParaRoquePequeno = new Posicao(Posicao.Linha, Posicao.Coluna - 4);
                // conferindo se ha torre em coluna + 3
                if (Tabuleiro.TestePosicaoValida(posicaoTorreParaRoquePequeno))
                {

                    Peca torre = Tabuleiro.GetPeca(Posicao.Linha, Posicao.Coluna + 3);
                    if (torre != null
                        && torre is Torre
                        && torre.Cor == Cor
                        && torre.QtdMovimentos == 0)
                    {
                        // Testando se casas estao desobstruidas
                        Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                        Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);

                        if (Tabuleiro.GetPeca(p1) == null && Tabuleiro.GetPeca(p2) == null)
                        {
                            Movimentacoes[Posicao.Linha, Posicao.Coluna + 2] = true;
                        }
                    }
                }
            }
            // #jogadaespecial Roque grande
            // primeiro movimento do rei
            // rei nao esta em xeque
            // primeiro movimento da torre
            // casas entre rei e torre desobstruidas
            // resultado da jogada nao pode se colocar em xeque
            if (QtdMovimentos == 0 && !Partida.Xeque)
            {
                // conferindo se ha torre em coluna + 3
                Posicao posicaoTorreParaRoqueGrande = new Posicao(Posicao.Linha, Posicao.Coluna - 4);
                if (Tabuleiro.TestePosicaoValida(posicaoTorreParaRoqueGrande))
                {
                    Peca torre = Tabuleiro.GetPeca(Posicao.Linha, Posicao.Coluna - 4);
                    if (torre != null
                        && torre is Torre
                        && torre.Cor == Cor
                        && torre.QtdMovimentos == 0)
                    {
                        // Testando se casas estao desobstruidas
                        Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                        Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                        Posicao p3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);

                        if (Tabuleiro.GetPeca(p1) == null && Tabuleiro.GetPeca(p2) == null && Tabuleiro.GetPeca(p3) == null)
                        {
                            Movimentacoes[Posicao.Linha, Posicao.Coluna - 2] = true;
                        }
                    }
                }
            }


            return Movimentacoes;

        }
    }
}
