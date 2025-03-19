using System.Text;

namespace _32_TheRobotPilot;

internal class Program
{
    static void Main(string[] args)
    {
        int round = 1;
        int mantiLocation = GetMantiLocation();
        Manticore manti = new();
        City city = new();
        bool runAgain = true;
        do
        {
            runAgain = DisplayRound(round, mantiLocation, manti, city);
        } while (runAgain);
    }

    private static bool DisplayRound(int round, int mantiLocation, Manticore manti, City city)
    {
        int range = GetLocationToTarget();
        int cannonDmg = CalculateCannonDmg(round);

        if (manti.CurrentHP <= 0 || city.CurrentHP <= 0)
        {
            return false;
        }

        Console.Clear();
        Console.WriteLine($"STATUS: Round: {round}\tCity: {city.CurrentHP}/{city.TotalHP}\tManticore: {manti.CurrentHP}/{manti.TotalHP}");
        Console.WriteLine($"The cannon is expected to deal {cannonDmg} damage this round.");

        if (HitTarget(range, mantiLocation))
            CalculateNewHealth(city, manti, round, cannonDmg);
    }

    private static void CalculateNewHealth(City city, Manticore manti, int round, int cannonDmg)
    {
        throw new NotImplementedException();
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

    private static int CalculateCannonDmg(int round)
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