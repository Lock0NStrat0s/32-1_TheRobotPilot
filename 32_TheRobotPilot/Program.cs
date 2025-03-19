using System.Text;

namespace _32_TheRobotPilot;

internal class Program
{
    static int round = 1;
    static void Main(string[] args)
    {
        int mantiLocation = GetMantiLocation();
        Manticore manti = new();
        City city = new();
        bool runAgain = true;

        do
        {
            runAgain = DisplayRound(mantiLocation, manti, city);
        } while (runAgain);

        bool win = city.CurrentHP > 0;
        WinOrLoseMessage(win);
    }

    private static void WinOrLoseMessage(bool win)
    {
        if (win)
        {
            Console.WriteLine("Congrats! You beat the manticore and saved the city!");
        }
        else
        {
            Console.WriteLine("The manticore destroyed the city.");
        }
    }

    private static bool DisplayRound(int mantiLocation, Manticore manti, City city)
    {
        if (manti.CurrentHP <= 0 || city.CurrentHP <= 0)
        {
            return false;
        }

        int cannonDmg = CalculateCannonDmg();

        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine($"STATUS: Round: {round}\tCity: {city.CurrentHP}/{city.TotalHP}\tManticore: {manti.CurrentHP}/{manti.TotalHP}");
        Console.WriteLine($"The cannon is expected to deal {cannonDmg} damage this round.");
        int range = GetLocationToTarget();

        if (HitTarget(range, mantiLocation))
            CalculateNewHealthOnHit(city, manti, cannonDmg);
        else
            CalculateNewHealthNoHit(city);

        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("\nPress any key to cotinue: ");
        Console.ReadKey();
        round += 1;
        return true;
    }

    private static void CalculateNewHealthNoHit(City city)
    {
        city.CurrentHP--;
    }

    private static void CalculateNewHealthOnHit(City city, Manticore manti, int cannonDmg)
    {
        manti.CurrentHP -= cannonDmg;
        city.CurrentHP--;
    }

    private static int GetMantiLocation()
    {
        Random rnd = new();
        return rnd.Next(0, 101);
    }

    private static int GetLocationToTarget()
    {
        int range = 0;
        do
        {
            Console.Write("Enter desired cannon range: ");
            int.TryParse(Console.ReadLine(), out range);
        } while (range <= 0 || range > 100);

        return range;
    }

    private static int CalculateCannonDmg()
    {
        // cannon dmg based on round number
        if (round % 3 == 0 && round % 5 == 0)
        {
            return 10;
        }
        else if (round % 3 == 0 || round % 5 == 0)
        {
            return 3;
        }
        else
        {
            return 1;
        }
    }

    private static bool HitTarget(int range, int mantiLocation)
    {
        // check if target is hit
        if (range > mantiLocation)
        {
            Console.WriteLine("That round OVERSHOT the target.");
            return false;
        }
        else if (range < mantiLocation)
        {
            Console.WriteLine("That round FELL SHORT of the target.");
            return false;
        }
        else
        {
            Console.WriteLine("That round was a DIRECT HIT!");
            return true;
        }
    }
}

//    // check if health drops to 0 after impact
//            if (GameState.MantiCurrentHP - GameState.CannonDmg <= 0)
//            {
//                return false;
//            }
//            else
//            {
//                GameState.MantiCurrentHP -= GameState.CannonDmg;
//                GameState.CityCurrentHP--;
//            }
//        }

//        round++;
//return true;