using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogo_Da_Velha
{
    // Exceção lançada quando ocorre algum problema na jogada feita pelo jogador.
    public class PlayException: Exception
    {
        // Construtor
        public PlayException() { }

        // Construtor
        public PlayException(string message) : base(message) { }

        // Construtor
        public PlayException(string message, Exception inner) : base(message, inner) { }

    }
}
