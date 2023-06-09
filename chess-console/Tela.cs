﻿using chess_console.nsTabuleiro;

namespace chess_console
{
    internal class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write((8 - i) + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    Peca? p = tab.GetPeca(i, j);

                    ImprimirPeca(p);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] movimentosPossieis)
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write((8 - i) + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {

                    ConsoleColor originalColor = Console.BackgroundColor;
                    ConsoleColor shadedColor = ConsoleColor.DarkGray;

                    if (movimentosPossieis[i, j])
                    {
                        Console.BackgroundColor = shadedColor;
                    }
                    else
                    {
                        Console.BackgroundColor = originalColor;
                    }


                    Peca? p = tab.GetPeca(i, j);

                    ImprimirPeca(p);


                    Console.BackgroundColor = originalColor;

                    Console.Write(' ');
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        // void ImprimirPeca
        public static void ImprimirPeca(Peca peca)
        {

            if (peca == null)
            {
                Console.Write("_");
            }
            else if (peca.Cor == Cor.Preta)
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
            else
            {
                Console.Write(peca);
            }
        }
        public static Posicao LerPosicaoXadrez()
        {
            string entrada = Console.ReadLine();
            char coluna = entrada[0];
            int linha = int.Parse(entrada[1] + ""); // "" para forcar cast para string

            return new PosicaoXadrez(linha, coluna).ToPos();
        }
    }
}
