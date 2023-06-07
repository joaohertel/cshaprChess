using chess_console.nsTabuleiro;

namespace chess_console.xadrez
{
    internal class Rei : Peca
    {
        // 3) constructor
        public Rei(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro )
        {

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

            return Movimentacoes;

        }
    }
}
