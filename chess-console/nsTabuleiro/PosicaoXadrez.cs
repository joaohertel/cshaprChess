namespace chess_console.nsTabuleiro
{
    internal class PosicaoXadrez
    {
        public int Linha { get; set; }
        public char Coluna { get; set; }

        public PosicaoXadrez(int linha, char coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }

        public Posicao ToPos()
        {
            // retorna a posicao xadrez traduzida para posicao normal
            return new Posicao(8 - Linha, Coluna - 'a');
        }

        public override string ToString()
        {
            return $"{Linha},{Coluna}";
        }
    }
}
