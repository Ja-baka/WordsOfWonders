using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordBuilder : MonoBehaviour
{
    private Letter[] _allLetters;
    private List<char> _pickedLetters;
    private bool _isPicking;


    private void Start()
    {
        _allLetters = FindObjectsOfType<Letter>();

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

    private void OnDragBegin(char letter)
    {
        _isPicking = true;
        _pickedLetters.Add(letter);
    }

    private void OnMouseEnterLetter(char letter)
    {
        if (_isPicking == false)
        {
            return;
        }

        _pickedLetters.Add(letter);
    }

    private void OnDragEnd()
    {
        _isPicking = false;
    }
}
