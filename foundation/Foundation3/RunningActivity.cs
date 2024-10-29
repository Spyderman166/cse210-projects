class RunningActivity : Activity
{
    private double _distance;

    public RunningActivity(string date, int minutes, double distance)
    : base(date, minutes)
    {
        _distance = distance;
    }

    public override double CalcSpeed()
    {
        return Math.Round((_distance / _minutes) * 60, 1);
    }

    public override double CalcPace()
    {
        return Math.Round(60 / CalcSpeed(), 1);
    }

    public override string GetSummary()
    {
        return $"{_date} Running ({_minutes} min): Distance: {_distance} miles, Speed: {CalcSpeed()} mph, Pace: {CalcPace()} min per mile";
    }
}