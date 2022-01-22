using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15Puzzle
{
    public class PuzzleBuilder
    {
        // ToDO: индексатор (по двум параметрам, для массива Int)
        private const int SIDE = 4;
        private const int VOID = SIDE * SIDE;
        private int[,] _numbersArray = new int[SIDE, SIDE];
        private Random randomize = new Random();

        //Start position of void button
        private int _voidX;
        private int _voidY;

        #region --==## PROPERTIES ##==--

        public int Side
        {
            get { return SIDE; }
        }

        public int Void
        {
            get { return VOID; }
        }

        public int VoidX
        {
            get { return _voidX; }
        }

        public int VoidY
        {
            get { return _voidY; }
        }

        public int[,] NumbersArray
        {
            get { return (int[,])_numbersArray.Clone(); }
        }

        #endregion

        public void SortButtons()
        {
            for (int i = 0; i < SIDE; i++)
            {
                for (int j = 0; j < SIDE; j++)
                {
                    _numbersArray[i, j] = i * SIDE + j + 1;
                }
            }
        }

        public void ShuffleButtons()
        {
            int i, j, k;
            int direction;

            _voidX = SIDE - 1;
            _voidY = SIDE - 1;

            int Times = SIDE * 2;
            for (k = 0; k < Times; k++)
            {
                direction = randomize.Next(4);

                if (direction == 0) // Up
                {
                    // Top button exist
                    if (_voidX - 1 >= 0)
                    {
                        _numbersArray[_voidX, _voidY] = _numbersArray[_voidX - 1, _voidY];
                        _voidX--;
                    }
                    else
                    {
                        for (i = 0; i < SIDE - 1; i++)
                        {
                            _numbersArray[i, _voidY] = _numbersArray[i + 1, _voidY];
                        }
                        _voidX = SIDE - 1;
                    }
                }
                else if (direction == 1) // Down
                {
                    // Bottom button exist
                    if (_voidX + 1 < SIDE)
                    {
                        _numbersArray[_voidX, _voidY] = _numbersArray[_voidX + 1, _voidY];
                        _voidX++;
                    }
                    else
                    {
                        for (i = SIDE - 1; i > 0; i--)
                        {
                            _numbersArray[i, _voidY] = _numbersArray[i - 1, _voidY];
                        }
                        _voidX = 0;
                    }
                }
                else if (direction == 2) // Left
                {
                    // Left button exist
                    if (_voidY - 1 >= 0)
                    {
                        _numbersArray[_voidX, _voidY] = _numbersArray[_voidX, _voidY - 1];
                        _voidY--;
                    }
                    else
                    {
                        for (j = 0; j < SIDE - 1; j++)
                        {
                            _numbersArray[_voidX, j] = _numbersArray[_voidX, j + 1];
                        }
                        _voidY = SIDE - 1;
                    }
                }
                else // Rigth
                {
                    // Right button exist
                    if (_voidY + 1 < SIDE)
                    {
                        _numbersArray[_voidX, _voidY] = _numbersArray[_voidX, _voidY + 1];
                        _voidY++;
                    }
                    else
                    {
                        for (j = SIDE - 1; j > 0; j--)
                        {
                            _numbersArray[_voidX, j] = _numbersArray[_voidX, j - 1];
                        }
                        _voidY = 0;
                    }
                }

                // New position of void button
                _numbersArray[_voidX, _voidY] = VOID;
            }
        }

        public bool IsMovePossible(int i, int j)
        {
            bool result = false;

            if (Math.Abs(i - _voidX) + Math.Abs(j - _voidY) == 1)
            {
                result = true;

                // Move
                _numbersArray[_voidX, _voidY] = _numbersArray[i, j];

                // New position of void button
                _voidX = i;
                _voidY = j;
                _numbersArray[_voidX, _voidY] = VOID;
            }

            return result;
        }

        public bool CheckVictory()
        {
            bool result = false;

            if (_voidX == SIDE - 1 && _voidY == SIDE - 1)
            {
                if (IsWinner())
                {
                    result = true;
                }
            }

            return result;
        }

        private bool IsWinner()
        {
            int k = 1;
            bool result = true;

            for (int i = 0; i < SIDE; i++)
            {
                for (int j = 0; j < SIDE; j++)
                {
                    // Если очередное число не совпадает с порядковым
                    // If next number don't match with serial number
                    if (_numbersArray[i, j] != k)
                    {
                        result = false;
                        i = SIDE;
                        break;
                    }

                    k++;
                }
            }

            return result;
        }

    }
}
