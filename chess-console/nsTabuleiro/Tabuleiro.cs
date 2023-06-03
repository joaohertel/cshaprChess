using System.Linq.Expressions;
using chess_console.nsTabuleiro;

namespace chess_console.nsTabuleiro
{
    internal class Tabuleiro
    {
        // 1) private properties
        private Peca[,] Pecas { get; set; }
        // 2) auto properties
        public int Linhas { get; set; }
        public int Colunas { get; set; }

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[linhas, colunas];
        }

        // 3) constructor

        // 4) custom properties
        // 5) other methods
        public Peca GetPeca(int linha,int coluna)
        {
            return Pecas[linha, coluna];
        }
        // sobrecarga que recebe pos
        public Peca GetPeca(Posicao pos)
        {
            return Pecas[pos.Linha, pos.Coluna];
        }
        public void AdicionarPeca (Peca p, Posicao pos)
        {
            if (ExistePeca(pos))
            {
                throw new TabuleiroException("Erro: Ja existe peca nesta posicao");
            }

            Pecas[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;
        }
        // bool TestePosicaoValida
        public bool TestePosicaoValida(Posicao pos)
        {
            if(pos.Linha < 0
                || pos.Linha > Linhas 
                || pos.Coluna < 0
                || pos.Coluna > Colunas)
            {
                return false;
            }
            return true;
        }
        // void ValidaPosicao
        public void ValidaPosicao(Posicao pos)
        {
            if(!TestePosicaoValida(pos))
            {
                throw new TabuleiroException("Erro: Posicao Invalida!");
            }
        }
        // bool existePeca
        public bool ExistePeca(Posicao pos)
        {
            ValidaPosicao(pos);
            if (Pecas[pos.Linha, pos.Coluna] != null)
            {
                return true;
            }
            return false;
        }

        public Peca RemoverPeca(int posx, int posy)
        {
            // recuperar peca
            Peca p = Pecas[posx, posy];

            // set tabulerio.pos = null
            Pecas[posx, posy] = null;

            return p;
        }
        // Peca retirarPeca
        // criar partidaxadrez
        // movimentarpeca
        // ColocarPecas
    }
}
