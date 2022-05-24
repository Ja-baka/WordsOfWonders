using UnityEngine;

public class GameOverScreenLoader : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _scoreView;
    [SerializeField] private TMPro.TextMeshProUGUI _timeView;

    private void Awake()
    {
        _scoreView.text += GameOverParams.TotalScore;
        _timeView.text += GameOverParams.ElapsedTime + " ñ.";
    }
}
