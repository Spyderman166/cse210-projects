using System.Diagnostics.Contracts;

class CyclingActivity : Activity
{
    private double _speed;

    public CyclingActivity(string date, int minutes, double speed)
    : base(date, minutes)
    {
        _speed = speed;
    }

    public override double CalcDistance()
    {
        return Math.Round(_speed * _minutes, 1);
    }

    public override double CalcPace()
    {
        return Math.Round(60 / _speed, 1);
    }

    public override string GetSummary()
    {
        return $"{_date} Cycling ({_minutes} min): Distance: {CalcDistance()} miles, Speed: {_speed} mph, Pace: {CalcPace()} min per mile";
    }
}