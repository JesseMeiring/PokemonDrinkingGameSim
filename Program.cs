using System;
using System.Collections.Generic;

//TO-DO Program Player Combat

namespace Game
{
    class Program
    {
        static void Main()
        {
            List<List<int>> Records = new List<List<int>>();
            int sampleSize = 1000;
            Console.WriteLine("Press ENTER to begin");
            Console.ReadLine();
            for (int n = 1; n <= sampleSize; n++)
            {
                Gamestate g = new Gamestate(false);
                Actions.InitializeStack(g.TurnStack, g.Players.Count);
                do
                {
                    g.pullNextPlayer();
                    Phases.Upkeep(g.Players[g.PlayerIndex], g);
                    Phases.Movement(g.PlayerIndex, g);
                    Phases.EventsHappen(g);
                    if (g.Players[g.PlayerIndex].Skips > 0) g.Players[g.PlayerIndex].Skips--;
                } while (g.GameOver == false);
                Records.Add(g.ListState());
            }
            int avg = 0, max = 0, min = 999;
            string o = "";
            List<string> oo = new List<string>();
            foreach (List<int> l in Records)
            {
                if (l[^3] > max) max = l[^3];
                if (l[^2] < min) min = l[^2];
                avg += l[^1];
                o = "";
                foreach (int n in l)
                {
                    o += n.ToString();
                    o += ",";
                    Console.Write(n);
                    Console.Write(",");
                }
                oo.Add(o);
                Console.Write("\n");
            }
            avg /= Records.Count;
            Console.WriteLine("All time high: " + max.ToString());
            Console.WriteLine("All time low: " + min.ToString());
            Console.WriteLine("Average: " + avg.ToString());
        }
    }
}
