using UnityEngine;

public class GameOverScreenLoader : MonoBehaviour
{
    private const int LevelsCount = 6;

    [SerializeField] private TMPro.TextMeshProUGUI _scoreView;
    [SerializeField] private TMPro.TextMeshProUGUI _timeView;

    private void Awake()
    {
        IncreaseLevel();

        _scoreView.text += GameOverParams.TotalScore;
        _timeView.text += GameOverParams.ElapsedTime + " с.";
    }

    private static void IncreaseLevel()
    {
        var storage = new Storage<int>("PassedLevelsCount");
        var PassedLevelsCount = storage.Load(0);
        PassedLevelsCount += PassedLevelsCount < LevelsCount
            ? 1
            : 0;
        storage.Save(PassedLevelsCount);
    }
}
