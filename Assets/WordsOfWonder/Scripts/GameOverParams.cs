public static class GameOverParams
{
    public static void Set(int totalScore, int elapsedTime)
    {
        TotalScore = totalScore;
        ElapsedTime = elapsedTime;
    }

    public static int TotalScore { get; private set; }
    public static int ElapsedTime { get; private set; }
}
