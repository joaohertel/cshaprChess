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
    }
}
