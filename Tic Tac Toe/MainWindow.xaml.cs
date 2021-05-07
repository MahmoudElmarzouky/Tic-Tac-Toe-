using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tic_Tac_Toe
{
        
    public partial class MainWindow : Window
    {
        #region Private Memebers 
        /// <summary>
        /// Holds the current Results of cells on the active game 
        /// </summary>
        private MarkType[] mResults;
        /// <summary>
        /// true if the player 1 turn (X) or player 2 turn (O)
        /// </summary>
        private bool mPlayer1;
        /// <summary>
        /// if the game has end 
        /// </summary>
        private bool mGameEnded;

        #endregion
        #region Constractor 
        /// <summary>
        /// Default Constractor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            newGame();
        }
        #endregion
        /// <summary>
        /// start a new game and clear all values to start 
        /// </summary>
        private void newGame()
        {
            // crarte a new blank array of free cells 
            mResults = new MarkType[9];
            for (var i=0; i < mResults.Length; ++i)
                mResults[i] = MarkType.Free;
            // make sure Player 1 start the game 
            mPlayer1 = true;
            //Interate every Button on the Grid ...
            Grid.Children.Cast<Button>().ToList().ForEach(button =>
            {
                // change background , foreground and content Default value 
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;
            });
            //make sure the game has not finshed
            mGameEnded = false;
        }
        /// <summary>
        /// Handels a Button Click event 
        /// </summary>
        /// <param name="sender">the button that was clicked</param>
        /// <param name="e">the events of the clicks</param>
        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            // start a new game on click after it finished
            if (mGameEnded)
            {
                newGame();
                return;
            }
            // cast the sender to button
            var button = (Button)sender;
            // find postion of button in array 
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 3);
            // do not do anything when the cell already has a value in it 
            if (mResults[index] != MarkType.Free)
                return;
            // set the value in cell based on which player has turn on
            mResults[index] = mPlayer1 ? MarkType.Croess : MarkType.Nought;
            // set the button text 
            button.Content= mPlayer1 ? "X": "O";
            // change the button text color 
            if (!mPlayer1)
                button.Foreground = Brushes.Red;
            //toggle the players turns 
            mPlayer1 ^= true;
            // check which player is winner 
            checkWinner();
        }
        /// <summary>
        /// check which player is winner
        /// </summary>
        private void checkWinner()
        {
         //  check horizontal cell 
         //
         // Row 1 
         // 
         if(mResults[0]!=MarkType.Free&&(mResults[0]& mResults[1]& mResults[2])== mResults[0])
            {
                // Game Finished
                mGameEnded = true;
                // highlight the cells in Green 
                Btn0_0.Background = Btn0_1.Background = Btn0_2.Background = Brushes.Green;
            }
            //
            // Row 2 
            // 
            if (mResults[3] != MarkType.Free && (mResults[3] & mResults[4] & mResults[5]) == mResults[3])
            {
                // Game Finished
                mGameEnded = true;
                // highlight the cells in Green 
                Btn1_0.Background = Btn1_1.Background = Btn1_2.Background = Brushes.Green;
            }
            //
            // Row 3 
            // 
            if (mResults[6] != MarkType.Free && (mResults[6] & mResults[7] & mResults[8]) == mResults[6])
            {
                // Game Finished
                mGameEnded = true;
                // highlight the cells in Green 
                Btn2_0.Background = Btn2_1.Background = Btn2_2.Background = Brushes.Green;
            }

            //--------------
            //  check vertical cell 
            //
            // column 1 
            // 
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[3] & mResults[6]) == mResults[0])
            {
                // Game Finished
                mGameEnded = true;
                // highlight the cells in Green 
                Btn0_0.Background = Btn1_0.Background = Btn2_0.Background = Brushes.Green;
            }
            //
            // column 2 
            // 
            if (mResults[1] != MarkType.Free && (mResults[1] & mResults[4] & mResults[7]) == mResults[1])
            {
                // Game Finished
                mGameEnded = true;
                // highlight the cells in Green 
                Btn0_1.Background = Btn1_1.Background = Btn2_1.Background = Brushes.Green;
            }
            //
            // column 3 
            // 
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[5] & mResults[8]) == mResults[2])
            {
                // Game Finished
                mGameEnded = true;
                // highlight the cells in Green 
                Btn0_2.Background = Btn1_2.Background = Btn2_2.Background = Brushes.Green;
            }
            // chack diagonals 
            //
            // column main diagonal
            // 
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[4] & mResults[8]) == mResults[0])
            {
                // Game Finished
                mGameEnded = true;
                // highlight the cells in Green 
                Btn0_0.Background = Btn1_1.Background = Btn2_2.Background = Brushes.Green;
            }
            //
            // column secondary  diagonal
            // 
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[4] & mResults[6]) == mResults[2])
            {
                // Game Finished
                mGameEnded = true;
                // highlight the cells in Green 
                Btn2_0.Background = Btn1_1.Background = Btn0_2.Background = Brushes.Green;
            }
            // check if two players are Draw 
            if (!mResults.Any(f => f == MarkType.Free)&&!mGameEnded)
            {
                // the game finished 
                mGameEnded = true;
                // change all buttonn backgraund in orange
                Grid.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.Background = Brushes.Orange;
                });
            }
        }
    }
}
