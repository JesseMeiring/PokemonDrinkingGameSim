using System;
using System.Reflection;

//TO-DO Program Player Combat

namespace Game
{
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
            MethodInfo mInfo = typeof(Spaces).GetMethod("Space" + s.ToString());
            if (mInfo != null)
            {
                mInfo.Invoke(null, new object[] { g });
            } else
            {
                throw new Exception("Missing Case#:" + s.ToString());
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
}
