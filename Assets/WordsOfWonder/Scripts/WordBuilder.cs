using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class WordBuilder : MonoBehaviour
{
    [SerializeField] private WordsDictionary _dictionary;
    
    private Letter[] _allLetters;
    private List<Letter> _pickedLetters;
    private bool _isPicking;

    private void Start()
    {
        _allLetters = FindObjectsOfType<Letter>();
        _pickedLetters = new List<Letter>();

        foreach (Letter letter in _allLetters)
        {
            letter.DragBegin += OnDragBegin;
            letter.MouseEnter += OnMouseEnterLetter;
            letter.DragEnd += OnDragEnd;
        }
    }
    private void OnDisable()
    {
        foreach (Letter letter in _allLetters)
        {
            letter.DragBegin -= OnDragBegin;
            letter.MouseEnter -= OnMouseEnterLetter;
            letter.DragEnd -= OnDragEnd;
        }
    }

    private void OnDragBegin(Letter letter)
    {
        _isPicking = true;

        _pickedLetters.Add(letter);
    }

    private void OnMouseEnterLetter(Letter letter)
    {
        if (_isPicking == false
            || _pickedLetters.Contains(letter))
        {
            return;
        }

        _pickedLetters.Add(letter);
    }

    private void OnDragEnd()
    {
        _isPicking = false;

        StringBuilder sb = new StringBuilder();
        foreach (Letter letter in _pickedLetters)
        {
            sb.Append(letter.Charactor);
        }

        GuessWord(sb.ToString());

        _pickedLetters.Clear();
    }

    private void GuessWord(string word)
    {
        string message = _dictionary.TryGuess(word)
            ? "Вы угадали!"
            : "Нет такого слова...";

        Debug.Log(message);
    }
}
