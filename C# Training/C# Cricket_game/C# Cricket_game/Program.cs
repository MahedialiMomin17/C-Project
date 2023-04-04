using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Cricket_game
{
    //public class Player
    //{
    //    public string Name { get; set; }
    //    public int Age { get; set; }

    //    public Player(string name, int age)
    //    {
    //        Name = name;
    //        Age = age;
    //    }

    //    //public void Play()
    //    //{
    //    //    Console.WriteLine("{0} is playing!", Name);
    //    //}
    //}



    //public class Bowler : Player
    //{
    //    public int WicketsTaken { get; set; }

    //    public Bowler(string name, int age) : base(name, age)
    //    {
    //        WicketsTaken = 0;
    //    }

    //    public void TakeWicket()
    //    {
    //        WicketsTaken++;
    //        Console.WriteLine("{0} takes a wicket!", Name);
    //        Console.WriteLine(" ");

    //    }
    //}



    //public class Batsman : Player
    //{
    //    public int RunsScored { get; set; }

    //    public Batsman(string name, int age) : base(name, age)
    //    {
    //        RunsScored = 0;
    //    }

    //    public void ScoreRun(int runs)
    //    {
    //        RunsScored += runs;
    //        Console.WriteLine("{0} scores {1} runs!", Name, runs);
    //        Console.WriteLine(" ");

    //    }
    //}


    //public class CricketGame
    //{
    //    private Bowler bowler;
    //    private Batsman batsman;

    //    public CricketGame(Bowler bowler, Batsman batsman)
    //    {
    //        this.bowler = bowler;
    //        this.batsman = batsman;
    //    }

    //    public void StartGame()
    //    {
    //        Console.WriteLine("{0} is bowling and {1} is batting!", bowler.Name, batsman.Name);
    //        Console.WriteLine(" ");
    //        bowler.TakeWicket();
    //        batsman.ScoreRun(4);
    //    }
    //}

    //internal class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Bowler bowler = new Bowler("sohambhai", 25);
    //        Batsman batsman = new Batsman("krinal", 28);
    //        CricketGame game = new CricketGame(bowler, batsman);
    //        game.StartGame();
    //    }
    //}

    class CricketGame
    {
        private int runs;
        private int wickets;
        private int overs;

        public int Runs
        {
            get { return runs; }
            set { runs = value; }
        }

        public int Wickets
        {
            get { return wickets; }
            set { wickets = value; }
        }

        public int Overs
        {
            get { return overs; }
            set { overs = value; }
        }
    }

    class InheritedCricketGame : CricketGame
    {
        private string team1;
        private string team2;

        public InheritedCricketGame(int runs, int wickets, int overs, string team1, string team2)
        {
            this.Runs = runs;
            this.Wickets = wickets;
            this.Overs = overs;
            this.team1 = team1;
            this.team2 = team2;
        }

        public void PrintData()
        {
            Console.WriteLine("Teams: {0} vs {1}", team1, team2);
            Console.WriteLine("Score: {0}/{1} ({2} overs)", Runs, Wickets, Overs);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Initialize a new inherited cricket game
            InheritedCricketGame game = new InheritedCricketGame(0, 0, 0, "India", "Australia");

            // Print the teams and the initial score
            game.PrintData();

            // Update the score after each ball
            game = new InheritedCricketGame(10, 0, 1, "India", "Australia");
            game.PrintData();

            game = new InheritedCricketGame(20, 1, 2, "India", "Australia");
            game.PrintData();

            Console.ReadKey();
        }
    }
}
