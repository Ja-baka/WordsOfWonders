using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
internal class Score : MonoBehaviour
{
    [SerializeField] private int _bonusPerWord;
    [SerializeField] private int _penaltyPerTip;
    [SerializeField] private int _timeToGuess;

    private float _elapsedTime;
    private string _prefix;
    private TextMeshProUGUI _view;

    public int ElapsedTime => Mathf.RoundToInt(_elapsedTime);
    public int TotalScore { get; private set; }

    private void Start()
    {
        _view = GetComponent<TextMeshProUGUI>();
        _prefix = _view.text;
        ShowScore();
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
    }

    public void Guess()
    {
        TotalScore += Mathf.RoundToInt(_bonusPerWord 
            - _elapsedTime / _timeToGuess);
        ShowScore();
    }

    public void UsedTip()
    {
        TotalScore -= _penaltyPerTip;
        
        ShowScore();
    }

    private void ShowScore()
    {
        if (TotalScore < 0)
        {
            throw new System.NotImplementedException("дадаць Game Over");
        }
        _view.text = _prefix + TotalScore;
    }
}