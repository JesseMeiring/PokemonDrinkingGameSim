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

    public class Phases
    {
        static public void Upkeep(Player p, Gamestate g)
        {
            switch (p.Status)
            {
                case "ConfusionZ":
                    if (Actions.RollADie() < 3)
                    {
                        p.Drinks++;
                        p.Skips++;
                    }
                    else
                    {
                        p.Status = "";
                    }
                    break;
                case "ConfusionL":
                    if (Actions.RollADie() < 4)
                    {
                        p.Skips++;
                    }
                    else
                    {
                        p.Status = "";
                    }
                    break;
                case "Cruising":
                    p.Drinks += Actions.RollADie();
                    break;
                case "GravelersProtection":
                    if (p.Status == "GravelersProtection" && p.Skips == 0) p.Status = "";
                    break;
                default:
                    break;
            }
            switch (p.Zone)
            {
                case "Pokemon Tower":
                    Actions.GiveDrinks(1, g, g.PlayerIndex);
                    break;
                case "Silph Co":
                    Actions.GiveDrinks(2, g, g.PlayerIndex);
                    break;
                case "Safari Zone":
                    int r = Actions.RollADie();
                    switch (r)
                    {
                        case int y when (y == 1 || y == 2):
                            Actions.GiveDrinks(1, g);
                            break;
                        case int y when (y == 3 || y == 4):
                            Actions.GiveDrinks(4, g, g.PlayerIndex);
                            p.Skips++;
                            break;
                        case int y when (y == 5 || y == 6):
                            Actions.GiveDrinks(2, g, g.PlayerIndex);
                            break;
                    }
                    break;
            }
        }
        static public void Movement(int target, Gamestate g)
        {
            if (g.Players[g.PlayerIndex].Space < 0) g.Players[g.PlayerIndex].Space = 0;
            if (g.Players[g.PlayerIndex].Status == "HuntingLegends") return;
            if (g.Players[g.PlayerIndex].Skips > 0) return;
            int start = g.Players[target].Space;
            Double roll = Actions.RollADie();
            if (g.Players[target].Status == "String Shot!")
            {
                roll = Math.Ceiling(roll / 2);
                g.Players[target].Status = "";
            }
            if (g.Players[target].Status == "cycling")
            {
                roll *= roll;
                g.Players[target].Status = "";
            }
            bool stopped = false;
            foreach (int stop in g.Stops)
            {
                if (start < stop && stop < start + roll && !stopped)
                {
                    if (!g.Players[target].EvolvedGymSkip)
                    {
                        g.Players[target].Space = stop;
                        stopped = true;

                    }
                    else
                    {
                        g.Players[target].EvolvedGymSkip = false;
                    }
                }
            }
            if (!stopped) g.Players[target].Space += Convert.ToInt32(roll);
            if (g.Players[target].Status == "TriAttack" && g.Players[target].Space != 35) g.Players[g.PlayerIndex].Status = ""; //clear Tri-Attack if you're not on that space
        }
        static public void EventsHappen(Gamestate g)
        {
            if (g.Players[g.PlayerIndex].Skips > 0) return;
            int s = g.Players[g.PlayerIndex].Space;
            switch (s)
            {
                case 0:
                    Spaces.Space0(g);
                    break;
                case 1:
                    Spaces.Space1(g);
                    break;
                case 2:
                    Spaces.Space2(g);
                    break;
                case 3:
                    Spaces.Space3(g);
                    break;
                case 4:
                    Spaces.Space4(g);
                    break;
                case 5:
                    Spaces.Space5(g);
                    break;
                case 6:
                    Spaces.Space6(g);
                    break;
                case 7:
                    Spaces.Space7(g);
                    break;
                case 8:
                    Spaces.Space8(g);
                    break;
                case 9:
                    Spaces.Space9(g);
                    break;
                case 10:
                    Spaces.Space10(g);
                    break;
                case 11:
                    Spaces.Space11(g);
                    break;
                case 12:
                    Spaces.Space12(g);
                    break;
                case 13:
                    Spaces.Space13(g);
                    break;
                case 14:
                    Spaces.Space14(g);
                    break;
                case 15:
                    Spaces.Space15(g);
                    break;
                case 16:
                    Spaces.Space16(g);
                    break;
                case 17:
                    Spaces.Space17(g);
                    break;
                case 18:
                    Spaces.Space18(g);
                    break;
                case 19:
                    Spaces.Space19(g);
                    break;
                case 20:
                    Spaces.Space20(g);
                    break;
                case 21:
                    Spaces.Space21(g);
                    break;
                case 22:
                    Spaces.Space22(g);
                    break;
                case 23:
                    Spaces.Space23(g);
                    break;
                case 24:
                    Spaces.Space24(g);
                    break;
                case 25:
                    Spaces.Space25(g);
                    break;
                case 26:
                    Spaces.Space26(g);
                    break;
                case 27:
                    Spaces.Space27(g);
                    break;
                case 28:
                    Spaces.Space28(g);
                    break;
                case 29:
                    Spaces.Space29(g);
                    break;
                case 30:
                    Spaces.Space30(g);
                    break;
                case 31:
                    Spaces.Space31(g);
                    break;
                case 32:
                    Spaces.Space32(g);
                    break;
                case 33:
                    Spaces.Space33(g);
                    break;
                case 34:
                    Spaces.Space34(g);
                    break;
                case 35:
                    Spaces.Space35(g);
                    break;
                case 36:
                    Spaces.Space36(g);
                    break;
                case 37:
                    Spaces.Space37(g);
                    break;
                case 38:
                    Spaces.Space38(g);
                    break;
                case 39:
                    Spaces.Space39(g);
                    break;
                case 40:
                    Spaces.Space40(g);
                    break;
                case 41:
                    Spaces.Space41(g);
                    break;
                case 42:
                    Spaces.Space42(g);
                    break;
                case 43:
                    Spaces.Space43(g);
                    break;
                case 44:
                    Spaces.Space44(g);
                    break;
                case 45:
                    Spaces.Space45(g);
                    break;
                case 46:
                    Spaces.Space46(g);
                    break;
                case 47:
                    Spaces.Space47(g);
                    break;
                case 48:
                    Spaces.Space48(g);
                    break;
                case 49:
                    Spaces.Space49(g);
                    break;
                case 50:
                    Spaces.Space50(g);
                    break;
                case 51:
                    Spaces.Space51(g);
                    break;
                case 52:
                    Spaces.Space52(g);
                    break;
                case 53:
                    Spaces.Space53(g);
                    break;
                case 54:
                    Spaces.Space54(g);
                    break;
                case 55:
                    Spaces.Space55(g);
                    break;
                case 56:
                    Spaces.Space56(g);
                    break;
                case 57:
                    Spaces.Space57(g);
                    break;
                case 58:
                    Spaces.Space58(g);
                    break;
                case 59:
                    Spaces.Space59(g);
                    break;
                case 60:
                    Spaces.Space60(g);
                    break;
                case 61:
                    Spaces.Space61(g);
                    break;
                case 62:
                    Spaces.Space62(g);
                    break;
                case 63:
                    Spaces.Space63(g);
                    break;
                case 64:
                    Spaces.Space64(g);
                    break;
                case 65:
                    Spaces.Space65(g);
                    break;
                case 66:
                    Spaces.Space66(g);
                    break;
                case 67:
                    Spaces.Space67(g);
                    break;
                case 68:
                    Spaces.Space68(g);
                    break;
                case 69:
                    Spaces.Space69(g);
                    break;
                case 70:
                    Spaces.Space70(g);
                    break;
                case 71:
                    Spaces.Space71(g);
                    break;
                default:
                    Console.WriteLine("Missing Case#:" + g.Players[g.PlayerIndex].Space.ToString());
                    break;
            }
            switch (s)
            {
                case int x when (23 <= x && x <= 27):
                    g.Players[g.PlayerIndex].Zone = "Pokemon Tower";
                    break;
                case int x when (36 <= x && x <= 40):
                    g.Players[g.PlayerIndex].Zone = "Silph Co";
                    break;
                case int x when (48 <= x && x <= 51):
                    g.Players[g.PlayerIndex].Zone = "Safari Zone";
                    break;
                default:
                    g.Players[g.PlayerIndex].Zone = "";
                    break;
            }
        }
    }
    public class Actions
    {
        public static void InitializeStack(List<int> TurnStack, int len)
        {
            for (int n = 0; n < len; n++)
            {
                TurnStack.Add(n);
            }
        }
        public static void FinishDrink(int target, Gamestate g)
        {
            g.Players[target].Drinks += (10 - g.Players[target].Drinks % 10);
        }
        public static void GiveDrinks(int drinks, Gamestate g, int target = -1)
        {
            if (target == -1)
            {
                Random r = new Random();
                do
                {
                    target = r.Next(2);
                } while (target == -1);
            }
            if (g.Players[target].Status == "GravelersProtection") return;
            g.Players[target].Drinks += drinks;
            if (g.Players[target].Status == "TriAttack") GiveDrinks(3, g, g.PlayerIndex);
        }
        public static int RollADie()
        {
            Random r = new Random();
            int result = r.Next(1, 7);
            return result;
        }
        static public void GiveExtraTurn(int target, Gamestate g)
        {
            g.ExtraTurnStack.Add(target);
        }

    }
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
            //this.Stops = { 6, 13, 19, 32, 43, 52, 58, 63, 68, 69, 70, 71 };
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
    class Spaces
    {
        public static void Space0(Gamestate g) //Start
        {
            //Start
        }
        public static void Space1(Gamestate g) //Ratata
        {
            //Console.WriteLine("Rattata used Tackle!... wait, you seriously rolled a 1? You fainted. Finish your drink");
            Actions.FinishDrink(g.PlayerIndex, g);
        }
        public static void Space2(Gamestate g) // Pigdey
        {
            //Console.WriteLine("Pidgey used Quick Attack! Use that quickness to give 1 drink and take 1 extra turn.");
            Actions.GiveDrinks(1, g);
            Actions.GiveExtraTurn(g.PlayerIndex, g);
        }
        public static void Space3(Gamestate g) // Caterpie
        {
            //Console.WriteLine("Caterpie used String Shot! It was super effective! All other players may only move 1/2 of what they roll on thier next turn (round up).");
            for (int i = 0; i < g.Players.Count; i++)
            {
                if (i != g.PlayerIndex) g.Players[i].Status = "String Shot!";
            }
        }
        public static void Space4(Gamestate g) //Pikachu
        {
            //Console.WriteLine("You caught a Pikachu! Drink 2 and replace your starter with this walking electic franchise");
            g.Players[g.PlayerIndex].Drinks += 2;
            g.Players[g.PlayerIndex].PokemonType = "Electric";
        }
        public static void Space5(Gamestate g) //Beedrill
        {
            //Console.WriteLine("Beedrill used Twinneedle! Pick two people to drink");
            List<int> arr = new List<int>(g.Players.Count);
            Random r = new Random();
            for (int n = 0; n < g.Players.Count; n++)
            {
                arr.Add(n);
            }
            arr.RemoveAt(g.PlayerIndex);
            int beeDrillTarget = r.Next(arr.Count);
            Actions.GiveDrinks(1, g, beeDrillTarget);
            arr.RemoveAt(beeDrillTarget);
            beeDrillTarget = r.Next(arr.Count);
            Actions.GiveDrinks(1, g, beeDrillTarget);
        }
        public static void Space6(Gamestate g) //Pewter Gym
        {
            //Console.WriteLine("Roll a die. Even: Give a drink. Odd: take a drink.");
            if (Actions.RollADie() % 2 == 0)
            {
                Actions.GiveDrinks(1, g);
            }
            else
            {
                g.Players[g.PlayerIndex].Drinks++;
            }
        }
        public static void Space7(Gamestate g) //Nidoran
        {
            //Console.WriteLine("If you're a guy, guys drink. If you're a girl, girls drink.");
            for (int n = 0; n < g.Players.Count; n++)
            {
                if (n == g.PlayerIndex || Actions.RollADie() % 2 == 0) Actions.GiveDrinks(1, g, n);
            }
        }
        public static void Space8(Gamestate g) //Zubat
        {
            g.Players[g.PlayerIndex].Drinks++;
            g.Players[g.PlayerIndex].Status = "ConfusionZ";
        }
        public static void Space9(Gamestate g) // Clefairy
        {
            Actions.GiveDrinks(2, g, g.PlayerIndex); //TO-DO: Make this accruate
        }
        public static void Space10(Gamestate g) //Jigglypuff
        {
            Actions.GiveExtraTurn(g.PlayerIndex, g);
        }
        public static void Space11(Gamestate g) //Abra
        {
            g.Players[g.PlayerIndex].Space = 28;
        }
        public static void Space12(Gamestate g) //Gary1
        {
            int tmp = Actions.RollADie();
            if (tmp % 2 == 1)
            {
                tmp = tmp / 2 + 1;
            }
            else
            {
                tmp /= 2;
            }
            Actions.GiveDrinks(tmp, g);
        }
        public static void Space13(Gamestate g) //Cerulean Gym
        {
            for (int n = 0; n < g.Players.Count; n++)
            {
                if (n == g.PlayerIndex) Actions.GiveDrinks(1, g, n);
                Actions.GiveDrinks(1, g, n);
            }
        }
        public static void Space14(Gamestate g) // Slowpoke
        {
            for (int n = 0; n < g.Players.Count; n++)
            {
                if (n != g.PlayerIndex) g.Players[n].Drinks += 5; //Guessing everyone else will get hit with about 5 drinks here
            }
        }
        public static void Space15(Gamestate g) // Bellsprout
        {
            Actions.GiveDrinks(1, g);
        }
        public static void Space16(Gamestate g) //Meowth
        {
            for (int n = 0; n < g.Players.Count; n++)
            {
                if (n != g.PlayerIndex) Actions.GiveDrinks(1, g, n);
            }
        }
        public static void Space17(Gamestate g) //Diglett
        {
            Actions.FinishDrink(g.PlayerIndex, g);
        }
        public static void Space18(Gamestate g) //SS Anne
        {
            g.Players[g.PlayerIndex].Status = "Cruising";
            g.Players[g.PlayerIndex].Skips = Actions.RollADie();
        }
        public static void Space19(Gamestate g) //Vermillion Gym
        {
            if (Actions.RollADie() % 2 == 0)
            {
                Actions.GiveDrinks(2, g, g.PlayerIndex);
                g.Players[g.PlayerIndex].Skips += 1;
            }
            else
            {
                Actions.GiveDrinks(1, g, g.PlayerIndex);
            }
        }
        public static void Space20(Gamestate g) //Bicycle
        {
            g.Players[g.PlayerIndex].Status = "Cycling";
        }
        public static void Space21(Gamestate g) //Magikarp
        {
            g.Players[g.PlayerIndex].Magikarp = true;
        }
        public static void Space22(Gamestate g) //Sandshrew
        {
            //TO-DO: Not sure sandshrew
        }
        public static void Space23(Gamestate g) //Pokemon Tower
        {
            //Pokemon Tower Text
        }
        public static void Space24(Gamestate g) //Channeler
        {
            //you have to get peopl drinks
        }
        public static void Space25(Gamestate g) //Haunter
        {
            int leader = 0;
            int leaderPos = 0;
            for (int n = 0; n < g.Players.Count; n++)
            {
                if (n != g.PlayerIndex && g.Players[n].Space > leaderPos)
                {
                    leaderPos = g.Players[n].Space;
                    leader = n;
                }
                g.Players[leader].Space -= 10;
            }
        }
        public static void Space26(Gamestate g) //Cubone
        {
            for (int n = 0; n < g.Players.Count; n++)
            {
                Actions.GiveDrinks(1, g, g.PlayerIndex);
            }
        }
        public static void Space27(Gamestate g) //Silph Scope
        {
            bool anyoneInSilphCo = false;
            for (int n = 0; n < g.Players.Count; n++)
            {
                if (g.Players[n].Zone == "SilphCo") anyoneInSilphCo = true;
            }
            if (anyoneInSilphCo)
            {
                for (int n = 0; n < g.Players.Count; n++)
                {
                    if (n != g.PlayerIndex) Actions.GiveDrinks(1, g, n);
                }
            }
            else
            {
                Actions.GiveDrinks(3, g, g.PlayerIndex);
            }
        }
        public static void Space28(Gamestate g) //Abra
        {
            g.Players[g.PlayerIndex].Space = 11;
        }
        public static void Space29(Gamestate g) //Snorlax
        {
            if (Actions.RollADie() < 2) Actions.GiveDrinks(4, g, g.PlayerIndex);
        }
        public static void Space30(Gamestate g) //Gary2
        {
            Actions.GiveDrinks(Actions.RollADie() - 1, g, g.PlayerIndex);
        }
        public static void Space31(Gamestate g) // Eevee (Make a new rule, assumes maker breaks once and everyone else breaks 3 times)
        {
            for (int n = 0; n < g.Players.Count; n++)
            {
                if (n == g.PlayerIndex)
                {
                    Actions.GiveDrinks(1, g, n);
                }
                else
                {
                    Actions.GiveDrinks(3, g, n);
                }
            }
        }
        public static void Space32(Gamestate g) //Celadon Gym
        {
            if (Actions.RollADie() < 4)
            {
                g.Players[g.PlayerIndex].Skips += 1;
            }
            else
            {
                Actions.FinishDrink(g.PlayerIndex, g);
            }
        }
        public static void Space33(Gamestate g) //Psyduck
        {
            for (int n = 0; n < g.Players.Count; n++)
            {
                if (n != g.PlayerIndex) g.Players[n].Drinks += 5; //Guessing everyone else will get hit with about 5 drinks here
            }
        }
        public static void Space34(Gamestate g) //Evolving
        {
            if (Actions.RollADie() % 2 == 0)
            {
                g.Players[g.PlayerIndex].Drinks += 4;
                g.Players[g.PlayerIndex].EvolvedGymSkip = true;
            }
            else
            {
                Actions.GiveExtraTurn(g.PlayerIndex, g);
            }
        }
        public static void Space35(Gamestate g) //Porygon
        {
            g.Players[g.PlayerIndex].Status = "TriAttack";
        }
        public static void Space36(Gamestate g) //Silph Co.
        {
            //Well...
        }
        public static void Space37(Gamestate g) //Scientist
        {
            Actions.GiveDrinks(g.Players.Count, g, g.PlayerIndex);
        }
        public static void Space38(Gamestate g) //Lapras
        {
            g.Players[g.CurrentLeader()].Status = "ConfusionL";
        }
        public static void Space39(Gamestate g) //Team Rocket
        {
            for (int n = 0; n < g.Players.Count; n++)
            {
                Actions.GiveDrinks(1, g, n);
            }
        }
        public static void Space40(Gamestate g) //Giovani
        {
            int val = Actions.RollADie();
            if (val < 4)
            {
                Actions.GiveDrinks(val, g);
            }
            else
            {
                Actions.GiveDrinks(val, g, g.PlayerIndex);
            }
        }
        public static void Space41(Gamestate g) //Rare candy
        {
            Actions.GiveExtraTurn(g.PlayerIndex, g);
        }
        public static void Space42(Gamestate g) //Gary3
        {
            Actions.GiveDrinks(Actions.RollADie(), g, g.PlayerIndex);
        }
        public static void Space43(Gamestate g) // Saffrom Gym
        {
            int Guess = Actions.RollADie();
            if (Actions.RollADie() == Guess)
            {
                Actions.GiveExtraTurn(g.PlayerIndex, g);
            }
            else
            {
                Actions.GiveDrinks(2, g, g.PlayerIndex);
            }
        }
        public static void Space44(Gamestate g) //Hitmonlee & Hitmonchamp
        {
            Actions.GiveDrinks(10, g, g.PlayerIndex);
            Actions.GiveDrinks(10, g, g.CurrentLeader());
            if (Actions.RollADie() > 3)
            {
                g.Players[g.CurrentLeader()].Skips += 1;
                Actions.GiveExtraTurn(g.PlayerIndex, g);
            }
            else
            {
                g.Players[g.PlayerIndex].Skips += 1;
                Actions.GiveExtraTurn(g.CurrentLeader(), g);
            }
        }
        public static void Space45(Gamestate g) //Krabby
        {
            int victim = 0, victimDrinkLeft = 1, remainder;
            for (int n = 0; n < g.Players.Count; n++)
            {
                remainder = g.Players[n].Drinks % g.DrinksPerBeer;
                if (remainder == 0) remainder = g.DrinksPerBeer;
                if (remainder > victimDrinkLeft)
                {
                    victim = n;
                    victimDrinkLeft = remainder;
                }
            }
            Actions.FinishDrink(victim, g);
        }
        public static void Space46(Gamestate g) //Ditto
        {
            //uh... TO-DO... this
        }
        public static void Space47(Gamestate g) //Doduo
        {
            Actions.GiveDrinks(4, g);
            Actions.GiveDrinks(1, g, g.PlayerIndex);
        }
        public static void Space48(Gamestate g) //Safari Zone
        {
            //Safari Text
        }
        public static void Space49(Gamestate g) // Dratini
        {
            if (Actions.RollADie() != 1) Actions.GiveDrinks(1, g, g.PlayerIndex);
        }
        public static void Space50(Gamestate g) //Taurus
        {
            Actions.GiveDrinks(2, g, g.PlayerIndex);
        }
        public static void Space51(Gamestate g) //Chansey
        {
            if (Actions.RollADie() < 4)
            {
                Actions.GiveDrinks(1, g, g.PlayerIndex);
            }
            else
            {
                Actions.GiveDrinks(2, g);
            }
        }
        public static void Space52(Gamestate g) //Fuchsia Gym
        {
            Actions.GiveDrinks(3, g, g.PlayerIndex);
        }
        public static void Space53(Gamestate g) //Electrode
        {
            for (int n = 0; n < g.Players.Count; n++)
            {
                Actions.FinishDrink(n, g);
            }
        }
        public static void Space54(Gamestate g) //Electrabuzz
        {
            g.Players[g.PlayerIndex].Skips++;
        }
        public static void Space55(Gamestate g) //Poliwag
        {
            g.Players[g.PlayerIndex].Drinks += g.DrinksPerBeer;
        }
        public static void Space56(Gamestate g) //Seaking
        {
            //Waterfall is based on first drinking 4, then second drinking 5 and so on.
            int waterFall = 4;
            if (g.Players[g.PlayerIndex].Drinks % g.DrinksPerBeer < waterFall)
            {
                Actions.FinishDrink(g.PlayerIndex, g);
            }
            else
            {
                Actions.GiveDrinks(waterFall, g, g.PlayerIndex);
            }
            for (int n = 0; n < g.TurnStack.Count - 1; n++)
            {
                waterFall++;
                if (g.Players[g.TurnStack[n]].Drinks % g.DrinksPerBeer < waterFall)
                {
                    Actions.FinishDrink(g.TurnStack[n], g);
                }
                else
                {
                    Actions.GiveDrinks(waterFall, g, g.TurnStack[n]);
                }

            }
        }
        public static void Space57(Gamestate g)  //MissingNo
        {
            if (Actions.RollADie() < 5 && Actions.RollADie() < 5 && Actions.RollADie() < 5) g.Players[g.PlayerIndex].Space = 0;
        }
        public static void Space58(Gamestate g) //Cinnabar Gym
        {
            int gymRollCount = 0;
            bool doneRolling = false;
            do
            {
                gymRollCount++;
                if (Actions.RollADie() % 2 == 1) doneRolling = true;
            } while (doneRolling != true);
        }
        public static void Space59(Gamestate g) //Koffing
        {
            Actions.GiveDrinks(2, g, g.PlayerIndex);
        }
        public static void Space60(Gamestate g) //Fossil
        {
            for (int n = 0; n < g.Players.Count; n++)
            {
                if (Actions.RollADie() > 3 && n != g.PlayerIndex) Actions.GiveDrinks(2, g, n);
            }
        }
        public static void Space61(Gamestate g) //Pokeball
        {
            if (Actions.RollADie() > 3) Actions.GiveDrinks(3, g, g.PlayerIndex);
        }
        public static void Space62(Gamestate g) //Persian
        {
            Actions.GiveDrinks(Actions.RollADie(), g);
        }
        public static void Space63(Gamestate g) //Viridian Gym
        {
            Actions.GiveDrinks(4, g, g.PlayerIndex);
            for (int n = 0; n < g.Players.Count; n++)
            {
                if (Actions.RollADie() % 2 == 1) Actions.GiveDrinks(3, g, n);
            }
        }
        public static void Space64(Gamestate g) //Ferrow
        {
            Actions.GiveDrinks(4, g, g.PlayerIndex); //TO-DO, track everyone's last turn drinks
        }
        public static void Space65(Gamestate g) //Graveler
        {
            g.Players[g.PlayerIndex].Skips += 2;
            g.Players[g.PlayerIndex].Status = "GravelersProtection";
        }
        public static void Space66(Gamestate g) //Gyrados
        {
            if (g.Players[g.PlayerIndex].Magikarp)
            {
                Actions.GiveDrinks(4, g);
            }
            else
            {
                Actions.GiveDrinks(4, g, g.PlayerIndex);
            }
        }
        public static void Space67(Gamestate g) //Dragonite
        {
            Actions.GiveDrinks(5, g);
            g.Players[g.PlayerIndex].Skips++;
        }
        public static void Space68(Gamestate g) //Legendaries
        {
            g.Players[g.PlayerIndex].Status = "HuntingLegends";
            if (Actions.RollADie() > 3) g.Players[g.PlayerIndex].Legendaries++;
            if (g.Players[g.PlayerIndex].Legendaries >= 3) g.Players[g.PlayerIndex].Status = "";
        }
        public static void Space69(Gamestate g) //The Elite Four
        {
            Actions.GiveDrinks(4, g, g.PlayerIndex); //TO-DO should they stay?
        }
        public static void Space70(Gamestate g) //Gary4
        {
            Actions.FinishDrink(g.PlayerIndex, g);
        }
        public static void Space71(Gamestate g) //Champion
        {
            g.GameOver = true;
        }
    }
    public class Player
    {
        public Player(string name, string pokemonType)
        {
            this.name = name;
            this.PokemonType = pokemonType;
            this.Drinks = 0;
            this.Space = 0;
            this.Status = "";
            this.Zone = "";
            this.Skips = 0;
            this.EvolvedGymSkip = false;
            this.Magikarp = false;
            this.Legendaries = 0;
        }
        public string name { get; }
        public string PokemonType { get; set; }
        public int Drinks { get; set; }
        public int Space { get; set; }
        public string Status { get; set; }
        public string Zone { get; set; }
        public int Skips { get; set; }
        public bool EvolvedGymSkip { get; set; }
        public bool Magikarp { get; set; }
        public int Legendaries { get; set; }
    }
}
