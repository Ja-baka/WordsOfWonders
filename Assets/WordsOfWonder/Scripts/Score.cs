using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
internal class Score : MonoBehaviour
{
    [SerializeField] private int _bonusPerWord;
    [SerializeField] private int _penaltyPerTip;
    [SerializeField] private int _penaltyPerMiss;
    [SerializeField] private int _timeToGuess;

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

    public void Guess()
    {
        _scorePoitns += (int)(_bonusPerWord - _elapsedTime / _timeToGuess);
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
        _view.text = _prefix + _scorePoitns;
    }
}
