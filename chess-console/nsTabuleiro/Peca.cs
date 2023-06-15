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
        
        public void DecrementarQtdMovimentos()
        {
            QtdMovimentos--;
        }


        /// <summary>
        /// Calcula se a posição de destino esta vazia ou se possui uma peça adversária
        /// </summary>
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


        /// <summary>
        /// Calcula se a posição de destino está dentro das limitações específicas da peça
        /// <example>
        /// <code>
        /// Rei r = new Rei(...);
        /// r.MovimentoPossivel(algumaPosicao); 
        /// </code>
        /// Neste caso somente retorna true se a posicao de destino estiver
        /// dentro das limitações do Rei já consideradas as posições válidas
        /// dentro do tabuleiro e com peças aliadas
        /// </example>
        /// </summary>
        /// <param name="pos">Posição de Destino</param>
        /// <returns>bool indicando se a movimentação é possível</returns>
        public bool MovimentoPossivel(Posicao pos)
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