using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WordsDictionary : MonoBehaviour
{
    [SerializeField] private string[] _words;
    [SerializeField] private GameObject[] _gameObjects;

    private List<string> _guessedWords;

    private void Start()
    {
        for (int i = 0; i < _words.Length; i++)
        {
            _words[i] = _words[i].ToLower();
        }
        _guessedWords = new List<string>();
    }

    public bool TryGuess(string word)
    {
        if (_words.Contains(word) == false
            || _guessedWords.Contains(word))
        {
            return false;
        }

        _guessedWords.Add(word);
        int index = Array.IndexOf(_words, word);
        _gameObjects[index].SetActive(true);
        return true;
    }

    public void ResetDictionary()
    {
        _guessedWords.Clear();
        for (int i = 0; i < _gameObjects.Length; i++)
        {
            _gameObjects[i].SetActive(false);
        }
    }
}
