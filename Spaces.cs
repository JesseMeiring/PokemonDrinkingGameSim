using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
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

}
