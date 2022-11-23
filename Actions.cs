using System;
using System.Collections.Generic;

//TO-DO Program Player Combat

namespace Game
{
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
            g.Players[target].Drinks += (g.DrinksPerBeer - g.Players[target].Drinks % g.DrinksPerBeer);
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
}
