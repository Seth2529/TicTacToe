using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Computer
    {
        public void JogadasMaquina(char[,] tabuleiro)
        {
            int melhorLinha = -1, melhorColuna = -1;
            int melhorPontuacao = int.MinValue;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (tabuleiro[i, j] == ' ')
                    {
                        int pontuacao = CalcularPontuacao(i, j, tabuleiro);

                        if (pontuacao > melhorPontuacao)
                        {
                            melhorPontuacao = pontuacao;
                            melhorLinha = i;
                            melhorColuna = j;
                        }
                    }
                }
            }

            tabuleiro[melhorLinha, melhorColuna] = 'O';
            Console.WriteLine($"O Jogador O marcou na posição ({melhorLinha + 1}, {melhorColuna + 1}).");
        }

        private int CalcularPontuacao(int linha, int coluna, char[,] tabuleiro)
        {
            int pontuacao = 0;

            // 2 pontos se a posição for a central
            if (linha == 1 && coluna == 1)
            {
                pontuacao += 2;
            }

            // 1 ponto se a posição estiver em um dos cantos
            if ((linha == 0 || linha == 2) && (coluna == 0 || coluna == 2))
            {
                pontuacao += 1;
            }

            // -2 pontos se houver uma ou mais peças do adversário na mesma linha, coluna ou diagonal
            if (OponenteNaLinha(linha, tabuleiro) || OponenteNaColuna(coluna, tabuleiro) || OponenteNaDiagonal(linha, coluna, tabuleiro))
            {
                pontuacao -= 2;
            }

            // 4 pontos se a posição impedir a vitória do adversário
            tabuleiro[linha, coluna] = 'X'; // Simular jogada do adversário
            if (Vencer('X', tabuleiro))
            {
                pontuacao += 4;
            }
            tabuleiro[linha, coluna] = ' '; // Reverter a simulação

            // 4 pontos se a posição levar à vitória
            tabuleiro[linha, coluna] = 'O'; // Simular jogada da máquina
            if (Vencer('O', tabuleiro))
            {
                pontuacao += 4;
            }
            tabuleiro[linha, coluna] = ' '; // Reverter a simulação

            return pontuacao;
        }

        private bool Vencer(char jogador, char[,] tabuleiro)
        {
            for (int i = 0; i < 3; i++)
            {
                if (tabuleiro[i, 0] == jogador && tabuleiro[i, 1] == jogador && tabuleiro[i, 2] == jogador)
                {
                    return true;
                }
            }
            for (int j = 0; j < 3; j++)
            {
                if (tabuleiro[0, j] == jogador && tabuleiro[1, j] == jogador && tabuleiro[2, j] == jogador)
                {
                    return true;
                }
            }
            if (tabuleiro[0, 0] == jogador && tabuleiro[1, 1] == jogador && tabuleiro[2, 2] == jogador)
            {
                return true;
            }
            if (tabuleiro[0, 2] == jogador && tabuleiro[1, 1] == jogador && tabuleiro[2, 0] == jogador)
            {
                return true;
            }
            return false;
        }

        private bool OponenteNaLinha(int linha, char[,] tabuleiro)
        {
            char oponente = 'X';
            return tabuleiro[linha, 0] == oponente && tabuleiro[linha, 1] == oponente && tabuleiro[linha, 2] == oponente;
        }

        private bool OponenteNaColuna(int coluna, char[,] tabuleiro)
        {
            char oponente = 'X';
            return tabuleiro[0, coluna] == oponente && tabuleiro[1, coluna] == oponente && tabuleiro[2, coluna] == oponente;
        }

        private bool OponenteNaDiagonal(int linha, int coluna, char[,] tabuleiro)
        {
            char oponente = 'X';
            if (linha == coluna)
            {
                return tabuleiro[0, 0] == oponente && tabuleiro[1, 1] == oponente && tabuleiro[2, 2] == oponente;
            }
            if (linha + coluna == 2)
            {
                return tabuleiro[0, 2] == oponente && tabuleiro[1, 1] == oponente && tabuleiro[2, 0] == oponente;
            }
            return false;
        }
    }
}