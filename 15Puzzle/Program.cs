using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _15Puzzle
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            PuzzleBuilder puzzleBuilder = new PuzzleBuilder();
            PuzzleBuilderRO puzzleBuilderRO = new PuzzleBuilderRO(puzzleBuilder);

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(puzzleBuilderRO));
        }
    }
}
