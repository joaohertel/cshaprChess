using System;
using System.Diagnostics.SymbolStore;
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
                    try
                    {
                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.Tab);
                        Console.WriteLine();
                        Console.WriteLine($"Turno: {partida.Turno}");
                        Console.WriteLine();
                        Console.WriteLine($"Aguardando a jogada: {partida.JogadorAtual}");
                        Console.WriteLine();
                        Console.Write("Posicao Inicial:");
                        Posicao pInicial = Tela.LerPosicaoXadrez();

                        partida.ValidaJogada( pInicial );


                        bool[,] movimentosPossiveis = partida.Tab.GetPeca(pInicial).MovimentosPossiveis();

                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.Tab, movimentosPossiveis);
                        Console.WriteLine($"Turno: {partida.Turno}");
                        Console.WriteLine();
                        Console.WriteLine($"Aguardando a jogada: {partida.JogadorAtual}");
                        Console.WriteLine();
                        Console.Write("Posicao Final:");
                        Posicao pFinal = Tela.LerPosicaoXadrez();



                        partida.ExecutarJogada(pInicial, pFinal);
                    }
                    catch (Exception ex) 
                    {
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                    }
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