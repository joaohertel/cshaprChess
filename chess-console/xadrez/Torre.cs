using chess_console.nsTabuleiro;

namespace chess_console.xadrez
{
    internal class Torre : Peca
    {
        // 3) constructor
        public Torre(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {

        }

        // 4) custom properties
        // 5) other methods

        // implementar movimentos da torre

        

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] movimentos = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao pos = new Posicao(0, 0);


            // estabelecendo pos = posicao acima da peca
            // acima
            pos.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna);
            while(Tabuleiro.TestePosicaoValida(pos) && PodeMover(pos))
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
            while(Tabuleiro.TestePosicaoValida(pos) && PodeMover(pos))
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
            while(Tabuleiro.TestePosicaoValida(pos) && PodeMover(pos))
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
            while(Tabuleiro.TestePosicaoValida(pos) && PodeMover(pos))
            {
                movimentos[pos.Linha, pos.Coluna] = true;

                Peca p = Tabuleiro.GetPeca(pos);
                if (p != null && p.Cor != Cor)
                {
                    break;
                }
                pos.DefinirPosicao(pos.Linha, pos.Coluna -1);
            }

            return movimentos;
        }

        public override string ToString()
        {
            return "T";
        }
    }
}