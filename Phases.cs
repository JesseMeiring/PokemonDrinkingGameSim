using System;

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
}
