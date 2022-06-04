using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ProgressionView : MonoBehaviour
{
    [SerializeField]
    private List<Button> _buttons;

    private Storage<int> _storage;

    private void Start()
    {
        for (int i = 0; i < _buttons.Count; i++)
        {
            _buttons[i].interactable = false;
        }

        _storage = new Storage<int>("PassedLevelsCount");
        var PassedLevelsCount = _storage.Load(0);

        for (int i = 0; i < PassedLevelsCount + 1; i++)
        {
            _buttons[i].interactable = true;
        }
    }
}
