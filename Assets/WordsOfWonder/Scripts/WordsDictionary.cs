using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WordsDictionary : MonoBehaviour
{
    [SerializeField] private Dictionary<string, bool> _words;

    public bool IsContainWord(string word)
    {
        if (_words.ContainsKey(word) == false
            || _words[word] == true)
        {
            return false;
        }

        _words[word] = true;
        return true;
    }

    public void ResetDictionary()
    {
        Dictionary<string, bool> temp = _words.ToDictionary
        (
            (x) => x.Key,
            (x) => x.Value
        );
        foreach (var pair in temp)
        {
            _words[pair.Key] = false;
        }
    }
}
