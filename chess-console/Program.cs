using System;
using chess_console.nsTabuleiro;
using chess_console.xadrez;

namespace chess_console
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.Terminada)
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tab);
                    Console.WriteLine();


                    Console.Write("Posicao Inicial:");
                    Posicao pInicial = Tela.LerPosicaoXadrez();

                    Console.Write("Posicao Final:");
                    Posicao pFinal = Tela.LerPosicaoXadrez();

                    partida.ExecutarJogada(pInicial, pFinal);
                }


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