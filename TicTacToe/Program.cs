using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var ticTacToe = new GameTicTacToe();

            while (true)
            {
                Console.WriteLine("Jogo da velha");
                Console.WriteLine("1 - Iniciar jogo Jogador vs Jogador");
                Console.WriteLine("2 - Iniciar jogo Jogador vs Computador");
                Console.WriteLine("3 - Sair do jogo da velha");
                Console.Write("Qual deseja escolher para jogar?: ");

                if (int.TryParse(Console.ReadLine(), out int opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            ticTacToe.HumanoVsHumano();
                            break;
                        case 2:
                            ticTacToe.HumanoVsMaquina();
                            break;
                        case 3:
                            return;
                        default:
                            Console.WriteLine("Escolha inválida, tente novamente digitando um número de 1 até 3.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Digite um número.");
                }
            }
        }
    }
}
