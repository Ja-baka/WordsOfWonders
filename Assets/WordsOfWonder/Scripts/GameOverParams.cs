public static class GameOverParams
{
    public static void Set(int totalScore, int elapsedTime, int completedLevel)
    {
        TotalScore = totalScore;
        ElapsedTime = elapsedTime;
        CompletedLevel = completedLevel;
    }

    public static int TotalScore { get; private set; }
    public static int ElapsedTime { get; private set; }
    public static int CompletedLevel { get; private set; }
}
