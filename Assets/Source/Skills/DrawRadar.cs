using UnityEngine;
using System.Collections;

public class DrawRadar : MonoBehaviour
{
    [SerializeField] LineRenderer _lineRenderer;

    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        DrawCircle(100f, 2f);
    }

    public void DrawCircle(float radius, float lineWidth)
    {
        var segments = 360;
        _lineRenderer.useWorldSpace = false;
        _lineRenderer.startWidth = lineWidth;
        _lineRenderer.endWidth = lineWidth;
        _lineRenderer.positionCount = segments + 1;

        var pointCount = segments + 1;
        var points = new Vector3[pointCount];

        for (int i = 0; i < pointCount; i++)
        {
            var rad = Mathf.Deg2Rad * (i * 360f / segments);
            points[i] = new Vector3(Mathf.Sin(rad) * radius, 0, Mathf.Cos(rad) * radius);
        }

        _lineRenderer.SetPositions(points);
    }
}
