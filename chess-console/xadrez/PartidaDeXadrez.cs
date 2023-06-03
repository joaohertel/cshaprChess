using chess_console.nsTabuleiro;

namespace chess_console.xadrez
{
    internal class PartidaDeXadrez
    {
        // 1) private properties
        // 2) auto properties
        public int Turno { get; set; }
        public Tabuleiro Tab { get; set; }
        private Cor JogadorAtual { get; set; }
        public bool Terminada { get; private set; }

        // 3) constructors
        public PartidaDeXadrez() 
        {
            Tab = new Tabuleiro(8, 8);
            JogadorAtual = Cor.Branca;
            Turno = 1;
            ColocarPecas();
        }
        // 4) custom properties
        // 5) other methods
        private void ColocarPecas()
        {
            Tab.AdicionarPeca(new Rei(Cor.Branca, Tab),new PosicaoXadrez(1,'d').ToPos());
            Tab.AdicionarPeca(new Torre(Cor.Branca, Tab),new PosicaoXadrez(1,'h').ToPos());
            Tab.AdicionarPeca(new Torre(Cor.Branca, Tab),new PosicaoXadrez(1,'a').ToPos());
            
            
            Tab.AdicionarPeca(new Rei(Cor.Preta, Tab),new PosicaoXadrez(8,'d').ToPos());
            Tab.AdicionarPeca(new Torre(Cor.Preta, Tab),new PosicaoXadrez(8,'a').ToPos());
            Tab.AdicionarPeca(new Torre(Cor.Preta, Tab),new PosicaoXadrez(8,'h').ToPos());
            
            
            //ExecutarJogada(new PosicaoXadrez(1, 'a').ToPos(), new PosicaoXadrez(1, 'h').ToPos());
        }

        public void ExecutarJogada(Posicao posInicial, Posicao posFinal)
        {
            Peca pecaJogada = Tab.RemoverPeca(posInicial.Linha, posInicial.Coluna);

            pecaJogada.IncrementarQtdMovimentos();
            
            
            Peca pecaCapturada = Tab.RemoverPeca(posFinal.Linha, posFinal.Coluna);

            //Console.WriteLine($"Peca capturada = {pecaCapturada}");

            Tab.AdicionarPeca(pecaJogada, posFinal);

            JogadorAtual = JogadorAtual == Cor.Preta ? Cor.Branca: Cor.Preta;
        }
        // metodo de executar jogada

    }
}
