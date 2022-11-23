using System;
using System.Collections.Generic;

//TO-DO Program Player Combat

namespace Game
{
    public class Gamestate
    {
        public Gamestate(bool play)
        {
            this.play = play;
            this.DrinksPerBeer = 20;
            this.PlayerIndex = 0;
            this.Players = new List<Player>() {
                new Player("Joey", "grass"),
                new Player("Teddy", "water"),
                new Player("Fred", "fire"),/*
                new Player("Milo", "fire"),
                new Player("Steven", "water"),
                new Player("Rasputin", "grass"),*/
                };
            this.GameOver = false;
            this.TurnStack = new List<int>();
            this.ExtraTurnStack = new List<int>();
        }
        public bool play { get; }
        public int DrinksPerBeer { get; set; }
        public int PlayerIndex { get; set; }
        public List<int> TurnStack { get; set; }
        public List<int> ExtraTurnStack { get; set; }
        public List<int> deck { get; }
        public bool GameOver { get; set; }
        public int[] Stops { get; } = { 6, 13, 19, 32, 43, 52, 58, 63, 68, 69, 70, 71 };
        public List<Player> Players { get; set; }
        public void pullNextPlayer()
        {
            int next;
            if (this.ExtraTurnStack.Count == 0)
            {
                next = this.TurnStack[0];
                this.TurnStack.RemoveAt(0);
                this.TurnStack.Add(next);
            }
            else
            {
                next = this.ExtraTurnStack[0];
                this.ExtraTurnStack.RemoveAt(0);
            }
            this.PlayerIndex = next;
            return;
        }
        public int CurrentLeader()
        {
            int leader = 0, leaderSpace = 0;
            for (int n = 0; n < Players.Count; n++)
            {
                if (Players[n].Space > leaderSpace)
                {
                    leader = n;
                    leaderSpace = Players[n].Space;
                }
            }
            return leader;
        }
        public void PrintCurrentState()
        {
            Console.WriteLine("Current player:", this.Players[this.PlayerIndex].name);
            foreach (Player p in this.Players) {
                Console.WriteLine(p.name + " is on space " + p.Space + " and has drank " + p.Drinks + " drinks.");
                Console.WriteLine("They had a(n) " + p.PokemonType + " pokemon");
            }
        }
        public List<int> ListState()
        {
            List<int> State = new List<int>();
            int max = 0, min = 999, avg = 0;
            foreach (Player p in this.Players)
            {
                if (p.Drinks > max) max = p.Drinks;
                if (p.Drinks < min) min = p.Drinks;
                avg += p.Drinks;
                State.Add(p.Drinks);
                State.Add(p.Space);
            }
            avg /= this.Players.Count;
            State.Add(max);
            State.Add(min);
            State.Add(avg);
            return State;
        }

    }
}
