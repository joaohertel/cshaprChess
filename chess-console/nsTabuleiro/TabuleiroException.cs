using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_console.nsTabuleiro
{
    internal class TabuleiroException : Exception
    {
        public TabuleiroException(string message) : base(message) { }

        public override string ToString()
        {
            return Message;
        }
    }

}
