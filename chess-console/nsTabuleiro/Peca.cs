namespace chess_console.nsTabuleiro
{
    internal abstract class Peca
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

        public bool PodeMover(Posicao pos)
        {
            Peca peca = Tabuleiro.GetPeca(pos);
            // calcular se esta vazia ou se tem peca adversaria
            if(peca == null || peca.Cor != Cor)
            {
                return true;
            }
            return false;
        }

        public bool PodeMoverPara(Posicao pos)
        {
            if (!MovimentosPossiveis()[pos.Linha, pos.Coluna])
            {
                return false;
            }
            return true;
        }

        public abstract bool[,] MovimentosPossiveis();  
        
    }
}