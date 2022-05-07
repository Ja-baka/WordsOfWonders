using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineDrawer : MonoBehaviour
{
    [SerializeField] private WordBuilder _wordBuilder;

    private List<Vector3> _points;
    private LineRenderer _lineRenderer;

    public void Start()
    {
        _lineRenderer = gameObject.GetComponent<LineRenderer>();
        _points = new List<Vector3>();
    }

    private void OnEnable()
    {
        _wordBuilder.PickindStarted += OnPickindStarted;
        _wordBuilder.LetterPicked += OnLetterPicked;
        _wordBuilder.PickindEnded += OnPickindEnded;
    }

    private void OnDisable()
    {
        _wordBuilder.PickindStarted -= OnPickindStarted;
        _wordBuilder.LetterPicked -= OnLetterPicked;
        _wordBuilder.PickindEnded -= OnPickindEnded;
    }

    private void OnPickindStarted(Letter letter)
    {
        AddLetterToList(letter);
        _lineRenderer.enabled = true;
    }

    private void AddLetterToList(Letter letter)
    {
        Vector3 position = letter.transform.position;
        position.z = 0;
        _points.Add(position);

        int index = _points.Count - 1;
        _lineRenderer.SetPosition(index, _points.Last());
        _lineRenderer.positionCount = _points.Count;
    }

    private void OnLetterPicked(Letter letter)
    {
        AddLetterToList(letter);
    }

    private void OnPickindEnded()
    {
        _lineRenderer.enabled = false;
        _points.Clear();
    }

    public void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MouseHold();
        }
    }
    private void MouseHold()
    {
        _lineRenderer.positionCount = _points.Count + 1;

        Vector3 mousePosition = GetCurrentMousePosition();

        _lineRenderer.SetPosition(_points.Count, mousePosition);
    }

    private Vector3 GetCurrentMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.forward, Vector3.zero);

        return plane.Raycast(ray, out float rayDistance)
            ? ray.GetPoint(rayDistance)
            : Vector3.zero;
    }
}