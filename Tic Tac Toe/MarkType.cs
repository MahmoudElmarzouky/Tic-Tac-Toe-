using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    /// <summary>
    /// the type of value a cell in a game in currently at  
    /// </summary>
    public enum MarkType
    {
        /// <summary>
        /// the cell is empty 
        /// </summary>
        Free,
        /// <summary>
        /// the cell is O
        /// </summary>
        Nought,

        /// <summary>
        /// the cell is X
        /// </summary>
        Croess
    }
}
