using UnityEngine;

public class GameOverScrinLoader : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _scoreView;

    private void Awake()
    {
        string prefix = _scoreView.text;
        _scoreView.text = prefix + GameOverParams.TotalScore;
    }
}
