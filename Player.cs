using System;

namespace Jogo_Da_Velha
{
    internal class Player
    {
        // Nome do jogador.
        public string Name { get; private set; }

        // Cor que representa o jogador.
        public ConsoleColor Color { get; private set; }

        // Item associado ao jogador ('X' ou 'O')
        public BoardItem BoardItem { get; private set; }

        // Cor que representa o jogador.
        public ConsoleColor ColorBack { get; private set; }

        // Construtor
        public Player(string name, ConsoleColor color, BoardItem boardItem)
        {
            this.Name = name;
            this.Color = color; 
            this.BoardItem = boardItem;
        }

        public void Play(Board board, int row, int col)
        {
            board.Play(row, col, BoardItem);
        }
    }
}
