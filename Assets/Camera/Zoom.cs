public class Zoom
{
    private int _zoomCount;
    private int _minZoom;
    private int _maxZoom;
    private int _zOffset;
    private int _xOffset;
    private float _left;
    private float _right;
    private float _top;
    private float _bottom;

    public int ZoomCount => _zoomCount;
    public int MinZoom => _minZoom;
    public int MaxZoom => _maxZoom;
    public float Top => _top;
    public float Bottom => _bottom;
    public float Left => _left;
    public float Right => _right;

    public Zoom(float leftBound, float rightBound, float topBound, float bottomBound)
    {
        _left = leftBound;
        _right = rightBound;
        _top = topBound;
        _bottom = bottomBound;
        _zoomCount = 0;
        _minZoom = 0;
        _maxZoom = 2;
        _zOffset = 50;
        _xOffset = 25;
    }

    public void ZoomIn()
    {
        _zoomCount++;
        _top += _zOffset;
        _right += _xOffset;
        _left -= _xOffset;
    }

    public void ZoomOut()
    {
        _zoomCount--;
        _top -= _zOffset;
        _right -= _xOffset;
        _left += _xOffset;
    }
}
