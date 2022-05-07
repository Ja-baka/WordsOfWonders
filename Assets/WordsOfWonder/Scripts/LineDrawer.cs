using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineDrawer : MonoBehaviour
{
    private Vector3 _initialPosition;
    private Vector3 _currentPosition;
    private LineRenderer _lineRenderer;

    public void Start()
    {
        _lineRenderer = gameObject.GetComponent<LineRenderer>();

        _lineRenderer.startWidth = 0.1f; 
        _lineRenderer.endWidth = 0.1f; 
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseDown();
        }
        else if (Input.GetMouseButton(0))
        {
            MouseHold();

        }
        else if (Input.GetMouseButtonUp(0))
        {
            MouseUp();
        }
    }

    private void MouseDown()
    {
        _initialPosition = GetCurrentMousePosition();
        _lineRenderer.SetPosition(0, _initialPosition);
        _lineRenderer.positionCount = 1;

        _lineRenderer.enabled = true;
    }

    private void MouseHold()
    {
        _currentPosition = GetCurrentMousePosition();

        _lineRenderer.positionCount = 2;
        _lineRenderer.SetPosition(1, _currentPosition);
    }

    private void MouseUp()
    {
        _lineRenderer.enabled = false;
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