class SimpleGoal : Goal
{
    private bool _isComplete = false;

    public SimpleGoal(string name, string description, string points)
    : base(name, description, points)
    {}

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_shortName}_{_description}_{_points}_{_isComplete}";
    }

}