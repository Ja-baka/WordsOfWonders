using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WordsDictionary : MonoBehaviour
{
    [SerializeField] private Word[] _words;
    [SerializeField] private TextMeshProUGUI _message;
    [SerializeField] private Score _score;
    [SerializeField] private GameObject _cellsContainer;

    private string[] _wordsValue;
    private List<string> _guessedWords;
    private List<TextMeshProUGUI> _cells;

    public System.Action GameOver;

    public Word[] Words => _words;

    private void Start()
    {
        _wordsValue = _words.Select((w) => w.Value).ToArray();
        _guessedWords = new List<string>();
        _cells = _cellsContainer.GetComponentsInChildren<TextMeshProUGUI>().ToList();
    }
    
    public void ShowTip()
    {
        if (_score.IsEnoughtScoreForTip == false)
        {
            _message.color = Color.red;
            _message.text = "Недостаточно очков для подсказки!";
            return;
        }

        var disabledCells = _cells.Where((c) => c.enabled == false);

        if (disabledCells.Any() == false)
        {
            _message.color = Color.red;
            _message.text = "Все слова уже отгаданы!";
        }

        var randomCell = disabledCells.OrderBy((x) => Random.value).First();
        randomCell.enabled = true;

        _score.UsedTip();
        CheckWordsGuessed();
    }

    public void TryGuess(string word)
    {
        if (_wordsValue.Contains(word) == false)
        {
            _message.color = Color.red;
            _message.text = "Нет такого слова";
            return;
        }
        if (_guessedWords.Contains(word))
        {
            _message.color = Color.red;
            _message.text = "Вы уже отгадали это слово";
            return;
        }

        _guessedWords.Add(word);
        int index = System.Array.IndexOf(_wordsValue, word);
        _words[index].OpenWord();
        _message.text = string.Empty;
        _score.Guess();

        CheckWin();
    }

    private void CheckWordsGuessed()
    {
        foreach (Word word in _words)
        {
            if (_guessedWords.Contains(word.Value) == false
                && word.TextesEnabled == true)
            {
                _guessedWords.Add(word.Value);
            }
        }
        CheckWin();
    }

    private void CheckWin()
    {
        if (_words.Length != _guessedWords.Count)
        {
            return;
        }
        GameOver?.Invoke();

        int score = _score.TotalScore;
        int time = _score.ElapsedTime;
        int index = SceneManager.GetActiveScene().buildIndex;
        GameOverParams.Set(score, time, index);
        SceneLoader.LoadGameOverScene();
    }

    public void ResetDictionary()
    {
        _guessedWords.Clear();
        for (int i = 0; i < _words.Length; i++)
        {
            _words[i].CloseWord();
        }
    }
}
