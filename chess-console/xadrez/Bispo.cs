using chess_console.nsTabuleiro;

namespace chess_console.xadrez
{
    internal class Bispo : Peca
    {
        // 1) private properties
        // 2) auto properties
        // 3) constructor
        public Bispo(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        { 
        }
        // 4) custom properties
        // 5) other methods
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

            return movimentos;
        }

        public override string ToString()
        {
            return "B";
        }
    }
}
