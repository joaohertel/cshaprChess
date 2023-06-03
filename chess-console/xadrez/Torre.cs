using chess_console.nsTabuleiro;

namespace chess_console.xadrez
{
    internal class Torre : Peca
    {
        // 3) constructor
        public Torre(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {

        }

        public override string ToString()
        {
            return "T";
        }
    }
}
