using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
internal class Score : MonoBehaviour
{
    [SerializeField] private int _bonusPerLetter;
    [SerializeField] private int _penaltyPerTip;
    [SerializeField] private int _penaltyPerMiss;
    [SerializeField] private int _timeToGuess;
    [SerializeField] private bool _canBeNegativeScore;

    private float _elapsedTime;
    private int _scorePoitns;
    private string _prefix;
    private TextMeshProUGUI _view;

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

    public void Guess(int lettersCount)
    {
        _scorePoitns += Mathf.RoundToInt(_bonusPerLetter * lettersCount - _elapsedTime / _timeToGuess);
        ShowScore();
    }

    public void UsedTip()
    {
        _scorePoitns -= _penaltyPerTip;
        ShowScore();
    }

    public void Miss()
    {
        _scorePoitns -= _penaltyPerMiss;
        ShowScore();
    }

    private void ShowScore()
    {
        if (_scorePoitns < 0
            && _canBeNegativeScore == false)
        {
            _scorePoitns = 0;
        }
        _view.text = _prefix + _scorePoitns;
    }
}
