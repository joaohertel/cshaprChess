using chess_console.nsTabuleiro;

namespace chess_console
{
    internal class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                for (int j = 0; j < tab.Colunas; j++)
                {
                    Peca? p = tab.GetPeca(i, j);

                    if (p != null)
                    {
                        //Console.Write(p);
                        ImprimirPeca(p);  
                    }
                    else
                    {
                        Console.Write("_");
                    }
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
        // void ImprimirPeca
        public static void ImprimirPeca(Peca peca)
        {
            if(peca.Cor == Cor.Preta)
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }else
            {
                Console.Write(peca);
            }
        }
    }
}
