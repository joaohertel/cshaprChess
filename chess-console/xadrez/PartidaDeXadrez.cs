using chess_console.nsTabuleiro;

namespace chess_console.xadrez
{
    internal class PartidaDeXadrez
    {
        // 1) private properties
        // 2) auto properties
        public int Turno { get; private set; }
        public Tabuleiro Tab { get; set; }
        public Cor JogadorAtual { get; private set; }
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
            Tab.AdicionarPeca(new Torre(Cor.Branca, Tab),new PosicaoXadrez(2,'d').ToPos());
            Tab.AdicionarPeca(new Torre(Cor.Branca, Tab),new PosicaoXadrez(1,'e').ToPos());
            Tab.AdicionarPeca(new Torre(Cor.Branca, Tab),new PosicaoXadrez(2,'e').ToPos());
            Tab.AdicionarPeca(new Torre(Cor.Branca, Tab),new PosicaoXadrez(1,'c').ToPos());
            Tab.AdicionarPeca(new Torre(Cor.Branca, Tab),new PosicaoXadrez(2,'c').ToPos());
            Tab.AdicionarPeca(new Torre(Cor.Branca, Tab),new PosicaoXadrez(1,'h').ToPos());
            Tab.AdicionarPeca(new Torre(Cor.Branca, Tab),new PosicaoXadrez(1,'a').ToPos());
            
            
            Tab.AdicionarPeca(new Rei(Cor.Preta, Tab),new PosicaoXadrez(8,'d').ToPos());
            Tab.AdicionarPeca(new Torre(Cor.Preta, Tab),new PosicaoXadrez(8,'a').ToPos());
            Tab.AdicionarPeca(new Torre(Cor.Preta, Tab),new PosicaoXadrez(8,'h').ToPos());
            
            
            //ExecutarJogada(new PosicaoXadrez(1, 'a').ToPos(), new PosicaoXadrez(1, 'h').ToPos());
        }

        public void ValidaJogada(Posicao posInicial)
        {
            Peca p = Tab.GetPeca(posInicial);
            if (p == null)
            {
                throw new TabuleiroException("Nenhuma peca selecionada ");
            }
            if(p.Cor != JogadorAtual)
            {
                throw new TabuleiroException("A Peca escolhida nao e sua ");
            }
            if (!MovimentosPossiveis(p))
            {
                throw new TabuleiroException("Nenhum movimento possivel para a peca ");
            }
        }

        private bool MovimentosPossiveis(Peca p)
        {
            foreach(bool posPossivel in p.MovimentosPossiveis())
            {
                if (posPossivel)
                {
                    return true;
                }
            }
            return false;
        }

        public void ExecutarJogada(Posicao posInicial, Posicao posFinal)
        {

            MovimentarPeca(posInicial, posFinal);

            // Passa o turno para o outro jogador
            JogadorAtual = JogadorAtual == Cor.Preta ? Cor.Branca : Cor.Preta;

            // aumenta o turno
            Turno++;
        }

        // metodo de executar jogada
        public void MovimentarPeca(Posicao posInicial, Posicao posFinal)
        {
            Peca pecaJogada = Tab.RemoverPeca(posInicial.Linha, posInicial.Coluna);

            pecaJogada.IncrementarQtdMovimentos();


            Peca pecaCapturada = Tab.RemoverPeca(posFinal.Linha, posFinal.Coluna);

            //Console.WriteLine($"Peca capturada = {pecaCapturada}");

            Tab.AdicionarPeca(pecaJogada, posFinal);

        }

        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!Tab.GetPeca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Movimentacao Invalida!");
            }
        }
    }
}
/*
 peca
public bool podeMoverPara(Posicao pos) 

partidaxadrez

public void validarPosicaoDeDestine(Posicao origem, Posicao destino)
throw new tabuleiro exception

program.cs
implementando restricoes de movimento

 */