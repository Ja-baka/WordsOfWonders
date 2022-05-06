using TMPro;
using UnityEngine;

public class CircleInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject _letterTemplate;
    [SerializeField] private char[] _letters;
    [SerializeField] private float _radius;

    private void Awake()
    {
        for (int i = 0; i < _letters.Length; i++)
        {
            _letters[i] = char.ToLower(_letters[i]);
        }

        int angleStep = 360 / _letters.Length;
        for (int i = 0; i < _letters.Length; i++)
        {
            GameObject letter = Instantiate(_letterTemplate, transform);
            TextMeshProUGUI tmpro = letter.GetComponentInChildren<TextMeshProUGUI>();
            tmpro.text = _letters[i].ToString();

            letter.transform.localPosition = new Vector3
            (
                x: _radius * Mathf.Cos(angleStep * (i + 1) * Mathf.Deg2Rad),
                y: _radius * Mathf.Sin(angleStep * (i + 1) * Mathf.Deg2Rad),
                z: 0
            );
        }
    }
}
