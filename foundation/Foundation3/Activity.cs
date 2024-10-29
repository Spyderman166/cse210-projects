class Activity
{
    protected string _date;

    protected int _minutes;

    public Activity(string date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public virtual double CalcDistance()
    {
        return 0;
    }

    public virtual double CalcSpeed()
    {
        return 0;
    }

    public virtual double CalcPace()
    {
        return 0;
    }

    public virtual string GetSummary()
    {
        return "";
    }
}