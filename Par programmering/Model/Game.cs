namespace Par_programmering.Model
{
    public class Game
    {
        private string _currentPlayer = "X";
        private bool _gameOver = false;
        private bool _gameDraw = false;
        private bool _playingAgainstAI = false;

        private string[] _board = new string[9];
        public Game()
        {
            Console.WriteLine("Vil du spille mot en maskin? (J/N)");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "j") _playingAgainstAI = true;

        }

        public void Run()
        {
            Meget_fancy_AI AI = new();
            drawBoard();
            Console.WriteLine("Du spiller mot AI? " + _playingAgainstAI);

            if (_playingAgainstAI && _currentPlayer == "O")
            {
                AI.getAIMove(_board);
            }
            else
            {
                getUserInput();
            }

            checkWinner();
            checkDraw();
            if (!_gameOver)
            {
                ChangePlayer();
                Run();
            }
            else
            {
                if (_gameDraw)
                {
                    Console.WriteLine("Ingen vant XD");
                }
                else
                {
                    drawBoard();
                    DisplayWinner();
                }
            }
        }

        private void checkDraw()
        {
            bool allAreFull = true;
            for (int i = 0; i < _board.Length; i++) if (_board[i] == null) allAreFull = false;
            if (allAreFull) { _gameDraw = true; _gameOver = true; }
        }

        private void getUserInput()
        {
            string userInput = Console.ReadLine();
            if (userInput.ToUpper() == "FF")
            {
                /*while (true)
                {
                    Console.WriteLine("Spiller '" + _currentPlayer + "' er en JÆVLA TAPER XDDDDDDDDDDDDDDD");
                }
                */
            }
            else
            {

                if (userInput.Length == 1 && IsDigitsOnly(userInput) && _board[Convert.ToInt16(userInput) - 1] == null)
                {
                    _board[Convert.ToInt16(userInput) - 1] = _currentPlayer;
                }
                else
                {
                    getUserInput();
                }
            }

        }

        private bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        private void ChangePlayer()
        {
            if (_currentPlayer == "X") { _currentPlayer = "O"; }
            else { _currentPlayer = "X"; }
        }

        private void DisplayWinner()
        {
            Console.WriteLine("Gratulerer '" + _currentPlayer + "' du vant!!!");
        }

        private void drawBoard()
        {
            Console.Clear();
            Console.WriteLine("Velkommen til bonnesjakk alle sammen, dette er kampen til døden XD");
            Console.WriteLine("How to play");
            Console.WriteLine("Skriv inn tallet som står på ruten du ønsker å ta");
            Console.WriteLine("-------------");
            Console.WriteLine("| 1 | 2 | 3 |");
            Console.WriteLine("-------------");
            Console.WriteLine("| 4 | 5 | 6 |");
            Console.WriteLine("-------------");
            Console.WriteLine("| 7 | 8 | 9 |");
            Console.WriteLine("-------------");
            Console.WriteLine();
            Console.WriteLine("-------------");
            Console.WriteLine($"| {giveLetterMBY(0)} | {giveLetterMBY(1)} | {giveLetterMBY(2)} |");
            Console.WriteLine("-------------");
            Console.WriteLine($"| {giveLetterMBY(3)} | {giveLetterMBY(4)} | {giveLetterMBY(5)} |");
            Console.WriteLine("-------------");
            Console.WriteLine($"| {giveLetterMBY(6)} | {giveLetterMBY(7)} | {giveLetterMBY(8)} |");
            Console.WriteLine("-------------");
            Console.WriteLine();
            Console.WriteLine("Det er spiller '" + _currentPlayer + "' sin tur!");
        }

        private string giveLetterMBY(int index)
        {
            if (_board[index] == null) return " ";
            return _board[index];
        }

        private void checkWinner()
        {
            // Sjekker lådrett
            for (int i = 0; i < 3; i++)
            {
                if (_board[i] != null && _board[i] == _board[i + 3] && _board[i] == _board[i + 6])
                {
                    _gameOver = true;
                }
            }
            // Sjekker vannrett
            if (_board[0] != null && _board[0] == _board[1] && _board[1] == _board[2]) { _gameOver = true; }
            if (_board[3] != null && _board[3] == _board[4] && _board[4] == _board[5]) { _gameOver = true; }
            if (_board[6] != null && _board[6] == _board[7] && _board[7] == _board[8]) { _gameOver = true; }
            // Sjekker på skrå
            if (_board[0] != null && _board[0] == _board[4] && _board[4] == _board[8]) { _gameOver = true; }
            if (_board[2] != null && _board[2] == _board[4] && _board[4] == _board[6]) { _gameOver = true; }

        }
    }
}
