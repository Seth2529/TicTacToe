using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class GameTicTacToe
    {
        private char[,] _tabuleiro = new char[3, 3];
        private char _jogadorAtual = 'O';
        private Computer _computer = new Computer();

        public void JogoDaVelha()
        {
            _tabuleiro = new char[3, 3];
            _jogadorAtual = 'X';
            _computer = new Computer();
        }

        public void HumanoVsHumano()
        {
            IniciarJogo();
            while (true)
            {
                ImprimirTabuleiro();
                if (JogoFinalizado()) break;

                Console.WriteLine($"Jogada do usuário {_jogadorAtual}:");
                Jogadas();
                TrocarJogador();
            }
        }

        public void HumanoVsMaquina()
        {
            IniciarJogo();
            while (true)
            {
                ImprimirTabuleiro();
                if (JogoFinalizado()) break;

                if (_jogadorAtual == 'X')
                {
                    Console.WriteLine($"Jogada do usuário {_jogadorAtual}:");
                    Jogadas();
                }
                else
                {
                    Console.WriteLine("Jogada do usuário O:");
                    _computer.JogadasMaquina(_tabuleiro);
                }
                TrocarJogador();
            }
        }

        private void IniciarJogo()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _tabuleiro[i, j] = ' ';
                }
            }
            _jogadorAtual = 'X';
        }

        private void ImprimirTabuleiro()
        {
            Console.WriteLine("  1 2 3");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"{i + 1} ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{_tabuleiro[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        private void Jogadas()
        {
            int linha, coluna;
            do
            {
                Console.Write("Escolha a Linha (1 a 3): ");
                linha = int.Parse(Console.ReadLine()) - 1;
                Console.Write("Escolha a Coluna (1 a 3): ");
                coluna = int.Parse(Console.ReadLine()) - 1;

                if (!JogadaValida(linha, coluna))
                {
                    Console.WriteLine("Erro: Já teve alguém que jogou nessa posição! Tente novamente.");
                }
            } while (!JogadaValida(linha, coluna));

            _tabuleiro[linha, coluna] = _jogadorAtual;
        }

        private bool JogadaValida(int linha, int coluna)
        {
            return linha >= 0 && linha < 3 && coluna >= 0 && coluna < 3 && _tabuleiro[linha, coluna] == ' ';
        }

        private void TrocarJogador()
        {
            _jogadorAtual = _jogadorAtual == 'X' ? 'O' : 'X';
        }

        private bool Vencer(char jogador)
        {
            for (int i = 0; i < 3; i++)
            {
                if (_tabuleiro[i, 0] == jogador && _tabuleiro[i, 1] == jogador && _tabuleiro[i, 2] == jogador)
                {
                    return true;
                }
            }
            for (int j = 0; j < 3; j++)
            {
                if (_tabuleiro[0, j] == jogador && _tabuleiro[1, j] == jogador && _tabuleiro[2, j] == jogador)
                {
                    return true;
                }
            }
            if (_tabuleiro[0, 0] == jogador && _tabuleiro[1, 1] == jogador && _tabuleiro[2, 2] == jogador)
            {
                return true;
            }
            if (_tabuleiro[0, 2] == jogador && _tabuleiro[1, 1] == jogador && _tabuleiro[2, 0] == jogador)
            {
                return true;
            }
            return false;
        }

        private bool JogoFinalizado()
        {
            if (Vencer('X'))
            {
                Console.WriteLine("Jogador X Ganhou!\n");
                return true;
            }
            if (Vencer('O'))
            {
                Console.WriteLine("Jogador O Ganhou!\n");
                return true;
            }
            if (_tabuleiro.Cast<char>().All(p => p != ' '))
            {
                Console.WriteLine("Empate!\n");
                return true;
            }
            return false;
        }
    }
}