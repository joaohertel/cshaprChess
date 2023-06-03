namespace chess_console.nsTabuleiro
{
    internal class Peca
    {
        // 1) private propertiets
        // 2) auto properties
        public Posicao? Posicao { get; set; }
        public int QtdMovimentos { get; protected set; }
        public Cor Cor { get; set; }
        public Tabuleiro Tabuleiro { get; set; }

        public Peca(Cor cor, Tabuleiro tabuleiro)
        {
            Cor = cor;
            Tabuleiro = tabuleiro;
            QtdMovimentos = 0;
        }

        // 3) constructors

        // 4) custom properties
        // 5) other methods
        public void IncrementarQtdMovimentos()
        {
            QtdMovimentos++;
        }
        
    }
}