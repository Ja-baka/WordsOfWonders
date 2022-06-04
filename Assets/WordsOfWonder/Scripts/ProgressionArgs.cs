[System.Serializable]
public class ProgressionArgs
{
    private int _passedLevelsCount;

    public ProgressionArgs(int passedLevelsCount)
    {
        _passedLevelsCount = passedLevelsCount;
    }

    public int PassedLevelsCount => _passedLevelsCount;
}
