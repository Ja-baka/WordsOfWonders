using TMPro;
using UnityEngine;

public class CircleInstantiate : MonoBehaviour
{
    public GameObject Template;
    public char[] Letters;
    public float Radius;

    private void Awake()
    {
        int angleStep = 360 / Letters.Length;
        for (int i = 0; i < Letters.Length; i++)
        {
            GameObject letter = Instantiate(Template, transform);
            TextMeshProUGUI tmpro = letter.GetComponentInChildren<TextMeshProUGUI>();
            tmpro.text = Letters[i].ToString();

            letter.transform.localPosition = new Vector3
            (
                x: Radius * Mathf.Cos(angleStep * (i + 1) * Mathf.Deg2Rad),
                y: Radius * Mathf.Sin(angleStep * (i + 1) * Mathf.Deg2Rad),
                z: 0
            );
        }
    }
}
