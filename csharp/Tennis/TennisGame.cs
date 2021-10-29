namespace Tennis
{
    class TennisGame : ITennisGame
    {
        private int player1CurrentScore = 0;
        private int player2CurrentScore = 0;
        private string player1Name;
        private string player2Name;

        public TennisGame(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                player1CurrentScore += 1;
            else
                player2CurrentScore += 1;
        }

        public string GetScore()
        {
            if (player2CurrentScore == player1CurrentScore)
            {
               return getTieScore(player2CurrentScore);
            }
            else if (player1CurrentScore >= 4 || player2CurrentScore >= 4)
            {
                return getAdvatageOrWin(player1CurrentScore, player2CurrentScore);
            }
            else
            {
                return getDefaultScore(player1CurrentScore, player2CurrentScore);
            }
        }


        private string getAdvatageOrWin(int player1CurrentScore, int player2CurrentScore)
        {
            //refactor this later with ${} for player 1/2
            var score = "";
            var minusResult = player1CurrentScore - player2CurrentScore;
            if (minusResult == 1) score = "Advantage player1";
            else if (minusResult == -1) score = "Advantage player2";
            else if (minusResult >= 2) score = "Win for player1";
            else score = "Win for player2";
            return score;
        }

        private string getDefaultScore(int player1CurrentScore, int player2CurrentScore)
        {
            return $"{getScoreName(player1CurrentScore)}-{getScoreName(player2CurrentScore)}";
        }

        private object getScoreName(int currentScore)
        {
            switch (currentScore)
            {
                case 0:
                   return "Love";
                case 1:
                   return "Fifteen";
                case 2:
                   return "Thirty";
                default:
                   return "Forty";
            }
        }

        private string getTieScore(int tiedScore)
        {
            switch (tiedScore)
            {
                case 0:
                    return "Love-All";
                case 1:
                    return "Fifteen-All";
                case 2:
                    return "Thirty-All";
                default:
                    return "Deuce";
            }
        }

    }
}

