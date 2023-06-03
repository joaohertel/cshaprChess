using System;
using chess_console.nsTabuleiro;
using chess_console.xadrez;

namespace chess_console
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            PosicaoXadrez px = new PosicaoXadrez(1,'a');
            Console.WriteLine($"px = {px}");
            Console.WriteLine($"px = {px.ToPos()}");

            try
            {
                Tabuleiro tabuleiro = new Tabuleiro(8, 8);
                Peca rei = new Rei(Cor.Preta, tabuleiro);
                Peca torre1 = new Torre(Cor.Preta, tabuleiro);
                Peca torre2 = new Torre(Cor.Preta, tabuleiro);

                tabuleiro.AdicionarPeca(rei, new Posicao(3, 3));
                tabuleiro.AdicionarPeca(torre1, new Posicao(2, 2));
                tabuleiro.AdicionarPeca(torre2, new Posicao(1, 0));


                Tela.ImprimirTabuleiro(tabuleiro);

            }
            catch (TabuleiroException e)
            {
                Console.WriteLine($"{e.Message}");
            }

        }
    }
    // POsicaoXadrez
    // Posicao ToPos
}