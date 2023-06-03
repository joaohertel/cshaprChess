namespace chess_console.nsTabuleiro
{
    internal class Posicao
    {
        // 1) private properties
        // 2) auto properties
        public int Linha { get; set; }
        public int Coluna { get; set; }

        // 3) constructors
        public Posicao(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }



        // 4) custom properties
        // 5) other methods
        public override string ToString()
        {
            return $"{Linha}, {Coluna}";
        }

    }
}
