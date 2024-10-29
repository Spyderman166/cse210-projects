using System.Diagnostics.Contracts;

class SwimmingActivity : Activity
{
    private double _laps;

    public SwimmingActivity(string date, int minutes, double laps)
    : base(date, minutes)
    {
        _laps = laps;
    }

    public override double CalcDistance()
    {
        return Math.Round(_laps * 50 / 1000 * 0.62, 1);
    }

    public override double CalcSpeed()
    {
        return Math.Round((CalcDistance() / _minutes) * 60, 1);
    }

    public override double CalcPace()
    {
        return Math.Round(_minutes / CalcDistance(), 1);
    }

    public override string GetSummary()
    {
        return $"{_date} Swimming ({_minutes} min): Laps: {_laps}, Distance: {CalcDistance()} miles, Speed: {CalcSpeed()} mph, Pace: {CalcPace()} min per mile";
    }
}