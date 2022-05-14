using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class WordBuilder : MonoBehaviour
{
    [SerializeField] private WordsDictionary _dictionary;
    
    private Letter[] _allLetters;
    private List<Letter> _pickedLetters;

    public event Action<Letter> PickindStarted;
    public event Action<Letter> LetterPicked;
    public event Action PickindEnded;

    public bool IsPicking { get; private set; }

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
        PickindStarted?.Invoke(letter);
        IsPicking = true;

        _pickedLetters.Add(letter);
    }

    private void OnMouseEnterLetter(Letter letter)
    {
        if (IsPicking == false
            || _pickedLetters.Contains(letter))
        {
            return;
        }

        _pickedLetters.Add(letter);
        LetterPicked?.Invoke(letter);
    }

    private void OnDragEnd()
    {
        IsPicking = false;

        StringBuilder sb = new StringBuilder();
        foreach (Letter letter in _pickedLetters)
        {
            sb.Append(letter.Charactor);
        }

        GuessWord(sb.ToString());

        _pickedLetters.Clear();
        PickindEnded?.Invoke();
    }

    private void GuessWord(string word)
    {
        _dictionary.TryGuess(word);
    }
}
