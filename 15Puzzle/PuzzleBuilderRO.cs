using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15Puzzle
{
    public class PuzzleBuilderRO
    {
        private readonly PuzzleBuilder _puzzleBuilder;

        public PuzzleBuilderRO(PuzzleBuilder puzzleBuilder)
        {
            _puzzleBuilder = puzzleBuilder;
        }

        public int Side
        {
            get { return _puzzleBuilder.Side; }
        }

        public int Void
        {
            get { return _puzzleBuilder.Void; }
        }

        public int VoidX
        {
            get { return _puzzleBuilder.VoidX; }
        }

        public int VoidY
        {
            get { return _puzzleBuilder.VoidY; }
        }

        public int[,] NumbersArray
        {
            get { return (int[,])_puzzleBuilder.NumbersArray.Clone(); }
        }

        public void SortButtons()
        {
            _puzzleBuilder.SortButtons();
        }

        public void ShuffleButtons()
        {
            _puzzleBuilder.ShuffleButtons();
        }

        public bool IsMovePossible(int i, int j)
        {
            return _puzzleBuilder.IsMovePossible(i , j);
        }

        public bool CheckVictory()
        {
            return _puzzleBuilder.CheckVictory();
        }
    }
}
