abstract class Goal
{
    protected string _shortName = "";
    protected string _description = "";
    protected string _points = "";

    public Goal(string Name, string description, string points)
    {
        _shortName = Name;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent();

    public abstract bool IsComplete();

    public virtual string GetDetails()
    {
        return $"{_shortName} ({_description})";
    }

    public abstract string GetStringRepresentation();

}