using System;
using System.Text;

namespace Jogo_Da_Velha
{
    enum BoardItem
    {
        X, O, EMPTY // Representa o espaço vazio.
    }

    internal class Board
    {
        // Matriz do jogo.
        private BoardItem[,] matrix = new BoardItem[3, 3]; // Field

        // Construtor
        public Board()
        {
            // Inicializa as posições da matriz com EMPTY
            for (int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    matrix[i, j] = BoardItem.EMPTY;
                }
            }
        }

        // Retorna o tabuleiro formatado
        public string GetFormattedBoard()
        {
            // Usa um StringBuilder para evitar a concatenação de strings.
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // Converte um BoardItem em um char para mostrar na tela.
                    sb.Append(" ").Append(ConvertBoardItemToChar(matrix[i, j]));

                    if (j < 2)
                    {
                        sb.Append(" | ");
                    }
                }
                sb.AppendLine();

                if(i < 2)
                {
                    sb.Append("------------").AppendLine();
                }
            }

            return sb.ToString();
        }

        // Converte um BoardItem para um char.
        private char ConvertBoardItemToChar(BoardItem boardItem) 
        { 
            switch (boardItem)
            {
                case BoardItem.X: return 'X';
                case BoardItem.O: return 'O';
                default: return ' ';
            }
        }

        // Verificar se o jogo terminou.
        public bool IsFinished(out BoardItem? winnerBoardItem) // out é um parâmetro de saída. O (?) indica que o parâmetro pode receber o valor null.
        {
            // verifica se existe alguma sequência de 3 itens.
            winnerBoardItem = CheckSequence();

            if(winnerBoardItem != null)
            {
                // Se houver uma sequência, o jogo terminou.
                // winnerBoardItem vai conter o item ganhador.
                return true;
            }

            // Se não houver sequência, verifica se o tabuleiro ainda pode receber jogadas...
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ( matrix[i, j] == BoardItem.EMPTY)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        // Efetua a jogada
        public void Play(int row, int col, BoardItem boardItem)
        {
            if (matrix[row, col] != BoardItem.EMPTY)
            {
                // Se a jogada já foi realizada, lança exceção.
                throw new PlayException("Esta jogada já foi realizada");
            }

            // Atribui o item à posição do tabuleiro.
            matrix[row, col] = boardItem;
        }

        // Verifica se existe uma sequência de 3 itens.
        private BoardItem? CheckSequence()
        {
            if (matrix[0, 0] != BoardItem.EMPTY && matrix[0, 0] == matrix[0, 1] && matrix[0, 1] == matrix[0, 2])
            {
                return matrix[0, 0];
            }

            if (matrix[1, 0] != BoardItem.EMPTY && matrix[1, 0] == matrix[1, 1] && matrix[1, 1] == matrix[1, 2])
            {
                return matrix[1, 0];
            }

            if (matrix[2, 0] != BoardItem.EMPTY && matrix[2, 0] == matrix[2, 1] && matrix[2, 1] == matrix[2, 2])
            {
                return matrix[2, 0];
            }

            if (matrix[0, 0] != BoardItem.EMPTY && matrix[0, 0] == matrix[1, 0] && matrix[1, 0] == matrix[2, 0])
            {
                return matrix[0, 0];
            }

            if (matrix[0, 1] != BoardItem.EMPTY && matrix[0, 1] == matrix[1, 1] && matrix[1, 1] == matrix[2, 1])
            {
                return matrix[0, 1];
            }

            if (matrix[0, 2] != BoardItem.EMPTY && matrix[0, 2] == matrix[1, 2] && matrix[1, 2] == matrix[2, 2])
            {
                return matrix[0, 2];
            }

            if (matrix[0, 0] != BoardItem.EMPTY && matrix[0, 0] == matrix[1, 1] && matrix[1, 1] == matrix[2, 2])
            {
                return matrix[0, 0];
            }

            if (matrix[0, 2] != BoardItem.EMPTY && matrix[0, 2] == matrix[1, 1] && matrix[1, 1] == matrix[2, 0])
            {
                return matrix[0, 2];
            }

            return null;
        }
    }
}
