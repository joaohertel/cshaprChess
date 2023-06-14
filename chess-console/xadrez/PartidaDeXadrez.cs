﻿using System.Collections.Generic;
using chess_console.nsTabuleiro;

namespace chess_console.xadrez
{
    internal class PartidaDeXadrez
    {
        // 1) private properties
        private HashSet<Peca> Pecas { get; set; }
        private HashSet<Peca> Capturadas { get; set; }
        // 2) auto properties
        public int Turno { get; private set; }
        public Tabuleiro Tab { get; set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }

        public bool Xeque { get; private set; }

        // 3) constructors
        public PartidaDeXadrez() 
        {
            Tab = new Tabuleiro(8, 8);
            JogadorAtual = Cor.Branca;
            Turno = 1;
            Pecas = new HashSet<Peca>();
            Capturadas= new HashSet<Peca>();
            ColocarPecas();
            Xeque = false;

        }
        // 4) custom properties
        // 5) other methods
        private void ColocarPecas()
        {
            ColocarNovaPeca('d',1, new Rei(Cor.Branca, Tab));
            ColocarNovaPeca('d',2, new Torre(Cor.Branca,Tab));
            ColocarNovaPeca('e',1, new Torre(Cor.Branca,Tab));
            ColocarNovaPeca('e',2, new Torre(Cor.Branca,Tab));
            ColocarNovaPeca('c',1, new Torre(Cor.Branca,Tab));
            ColocarNovaPeca('c',2, new Torre(Cor.Branca,Tab));
            
            ColocarNovaPeca('d',8,new Rei(Cor.Preta, Tab));
            ColocarNovaPeca('d',7,new Torre(Cor.Preta, Tab));
            ColocarNovaPeca('e',7, new Torre(Cor.Preta, Tab));
            ColocarNovaPeca('c',7, new Torre(Cor.Preta, Tab));
            ColocarNovaPeca('c',8, new Torre(Cor.Preta, Tab));
            ColocarNovaPeca('e',8, new Torre(Cor.Preta, Tab));
            
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tab.AdicionarPeca(peca, new PosicaoXadrez(linha,coluna).ToPos());
            Pecas.Add(peca);
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

            Peca? pecaCapturada = MovimentarPeca(posInicial, posFinal);

            if (EstaEmXeque(JogadorAtual))
            {
                // desfazer jogada
                DesfazerJogada(posInicial, posFinal, pecaCapturada);
                // Exception
                throw new TabuleiroException($"Voce nao pode se colocar em Xeque!");
            }

            if (EstaEmXeque(Adversaria(JogadorAtual)))
            {
                Xeque = true;
            }

            // Passa o turno para o outro jogador
            JogadorAtual = JogadorAtual == Cor.Preta ? Cor.Branca : Cor.Preta;

            // aumenta o turno
            IncrementaTurno();

        }

        private void DesfazerJogada(Posicao posInicial, Posicao posFinal, Peca? pecaCapturada)
        {
            MovimentarPeca(posFinal, posInicial);
            
            if (pecaCapturada != null)
            {
                Tab.AdicionarPeca(pecaCapturada, posFinal);
                Capturadas.Remove(pecaCapturada);
            }
        }

        private void IncrementaTurno()
        {
            Turno++;
        }

        private void DecrementaTurno()
        {
            Turno--;
        }

        // metodo de executar jogada
        public Peca? MovimentarPeca(Posicao posInicial, Posicao posFinal)
        {
            Peca pecaJogada = Tab.RemoverPeca(posInicial.Linha, posInicial.Coluna);

            pecaJogada.IncrementarQtdMovimentos();


            Peca pecaCapturada = Tab.RemoverPeca(posFinal.Linha, posFinal.Coluna);

            if(pecaCapturada != null)
            {
                Capturadas.Add(pecaCapturada);
            }

            Tab.AdicionarPeca(pecaJogada, posFinal);

            return pecaCapturada;
        }

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach(Peca p in Capturadas)
            {
                if(p.Cor == cor)
                {
                    aux.Add(p);
                }
            }
            return aux;
        }
        
        
        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach(Peca p in Pecas)
            {
                if(p.Cor == cor)
                {
                    aux.Add(p);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));

            return aux;
        }

        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!Tab.GetPeca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Movimentacao Invalida!");
            }
        }

        private Rei? GetRei(Cor cor)
        {
            foreach(Peca x in PecasEmJogo(cor))
            {
                if(x is Rei)
                {
                    return (Rei)x;
                }
            }
            return null;
        }

        public bool EstaEmXeque(Cor cor)
        {
            Rei? r = GetRei(cor);
            if(r == null)
            {
                throw new TabuleiroException($"Nao existe rei da cor {cor} na partida");
            }

            foreach(Peca p in PecasEmJogo(Adversaria(cor)))
            {
                if (p.MovimentosPossiveis()[r.Posicao.Linha, r.Posicao.Coluna])
                {
                    return true;
                }
            }
            return false;
        }

        private Cor Adversaria(Cor cor)
        {

            if(cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            return Cor.Branca;
        }
    }
}