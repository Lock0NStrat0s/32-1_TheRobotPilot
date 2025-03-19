namespace _32_TheRobotPilot;

abstract class GameObject
{
    public abstract string Name { get; }
    public abstract int TotalHP { get; }
    public abstract int CurrentHP { get; set; }
}

class Manticore : GameObject
{
    public override string Name { get; } = "Manticore";
    public override int TotalHP { get; } = 10;
    public override int CurrentHP { get; set; } = 10;
}

class City : GameObject
{
    public override string Name { get; } = "City";
    public override int TotalHP { get; } = 15;
    public override int CurrentHP { get; set; } = 15;
}