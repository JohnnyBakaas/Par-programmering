namespace Par_programmering.Model
{
    internal class Meget_fancy_AI
    {
        public void getAIMove(string[] board)
        {
            Random random = new Random();
            int tall = random.Next(8);
            if (board[tall] == null)
            {
                board[tall] = "O";
            }
            else { getAIMove(board); }
        }
    }
}
