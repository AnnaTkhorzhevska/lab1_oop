namespace Lab1
{
    class Program
    {
        public class GameRecord
        {
            public int index;
            public int Us12;
            public string opponent;
            public int rate;
            public GameRecord(int index, int Us12, string opponent, int rate)
            {
                this.index = index;
                this.Us12 = Us12;
                this.opponent = opponent;
                this.rate = rate;
            }
            
        }
    public class GameAccount
    {
        private string UserName = " ";
        private int CurrentRating = 1;
        private int GamesCount = 0;
        private List<GameRecord> record = new List<GameRecord>();

        public string GetName()
        {
            return UserName;
        }
        public int GetCurrentRating()
        {
            return CurrentRating;
        }
        public int GetGamesCount()
        {
            return GamesCount;
        }

        public void SetGamesCount(int GamesCount)
        {
            this.GamesCount = GamesCount;
        }
        public GameAccount(string UserName, int CurrentRat)
        {
            this.UserName = UserName;
            this.CurrentRating = CurrentRat;
        }

        public void WinGame(string opponentName, int Rating, int index)
        {
            if (Rating > 0)
            {
                CurrentRating = CurrentRating + Rating;
                GameRecord game = new GameRecord(index, 1, opponentName, Rating);
                record.Add(game);
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
        public void LoseGame(string opponentName, int Rating, int index)
        {
            if(Rating > 0 & CurrentRating - Rating > 0)
            {
                CurrentRating = CurrentRating - Rating;
                GameRecord game = new GameRecord(index, 1, opponentName, Rating);
                record.Add(game);
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        public void GetStats()
        {
            for (int i = 0; i < record.Count; i++)
            {
                if (record[i].Us12 == 0)
                {
                    Console.WriteLine("Game {0} lose {1} - {2} points", record[i].index, record[i].opponent, record[i].rate);
                }
                else
                {
                    Console.WriteLine("Game {0} win {1} +{2} points", record[i].index, record[i].opponent, record[i].rate);
                }
            }
        }
    }

    public class Game
    {
        private int gameCount = 0;
        private List<int> index = new List<int>();
        private List<int> rate = new List<int>();
        private List<string> User1 = new List<string>();
        private List<string> User2 = new List<string>();
        
        public void Game1(GameAccount winner, GameAccount loser, int Rate)
        {
            if(Rate > 0 & loser.GetCurrentRating() - Rate > 0)
            {
                winner.WinGame(loser.GetName(), Rate, gameCount);
                loser.LoseGame(winner.GetName(), Rate, gameCount);
                index.Add(gameCount);
                User1.Add(winner.GetName());
                User2.Add(loser.GetName());
                rate.Add(Rate);
                winner.SetGamesCount(winner.GetGamesCount() + 1);
                loser.SetGamesCount(loser.GetGamesCount() + 1);
                gameCount++;
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
        public void GetStats()
        {
            for (int i = 0; i < index.Count; i++)
            {
                Console.WriteLine("Game {0}. Lose: {1}, win: {2}, rate: {3}points", index[i], User1[i], User2[i], rate[i]);
            }
        }
        
    }
    static void Main(string[] args)
        {
            GameAccount User1 = new GameAccount("User1", 1000);
            GameAccount User2 = new GameAccount("User2", 1000);
            Game game = new Game();

            Console.WriteLine("Start");
            Console.WriteLine("User1: {0}", User1.GetCurrentRating());
            Console.WriteLine("User2: {0}", User2.GetCurrentRating());

            game.Game1(User1, User2, 300);
            game.GetStats();
            Console.WriteLine("User1: {0}", User1.GetCurrentRating());
            Console.WriteLine("User2: {0}", User2.GetCurrentRating());
            
            game.Game1(User2, User1, 100);
            game.GetStats();
            Console.WriteLine("User1: {0}", User1.GetCurrentRating());
            Console.WriteLine("User2: {0}", User2.GetCurrentRating());
            
            game.Game1(User2, User1, 250);
            game.GetStats();
            Console.WriteLine("User1: {0}", User1.GetCurrentRating());
            Console.WriteLine("User2: {0}", User2.GetCurrentRating());
            
            game.Game1(User1, User2, 200);
            game.GetStats();
            Console.WriteLine("User1: {0}", User1.GetCurrentRating());
            Console.WriteLine("User2: {0}", User2.GetCurrentRating());
            
            Console.WriteLine("User2");
            User2.GetStats();
            Console.WriteLine("User1");
            User1.GetStats();
        }
    }
}