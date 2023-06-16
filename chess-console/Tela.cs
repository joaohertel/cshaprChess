using chess_console.nsTabuleiro;
using chess_console.xadrez;

namespace chess_console
{
    internal class Tela
    {
        public static void ImprimirPartida(PartidaDeXadrez partida)
        {
            Console.Clear();
            Tela.ImprimirTabuleiro(partida.Tab);
            Console.WriteLine();
            if (!partida.Terminada)
            {
                Console.WriteLine($"pecaPassivelDeEnPassant = {partida.pecaPassivelDeEnPassant}");
                Console.WriteLine("Peças Capturadas");
                ImprimirPecasCapturadas(Cor.Branca, partida);
                Console.WriteLine();
                ImprimirPecasCapturadas(Cor.Preta, partida);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"Turno: {partida.Turno}");
                Console.WriteLine();
                if (partida.Xeque)
                {
                    Console.WriteLine("XEQUE!");
                }
                Console.WriteLine();
                Console.WriteLine($"Aguardando a jogada: {partida.JogadorAtual}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Xeque Mate!");
                Console.WriteLine();
                Console.WriteLine($"Vencedor: {partida.Vencedor}");
            }

        }

        public static void ImprimirPecasCapturadas(Cor cor, PartidaDeXadrez partida)
        {
            ConsoleColor consoleColor = Console.ForegroundColor;
            if(cor == Cor.Preta)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

            Console.Write($"{cor}: [");
            foreach(Peca p in partida.PecasCapturadas(cor))
            {
                Console.Write($"{p} ");
            }
            Console.Write("]");

            Console.ForegroundColor = consoleColor;
        }

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
