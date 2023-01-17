using System.Collections;

public class ZoomOut : ZoomButton
{
    public override IEnumerator Zoom()
    {
        while (_camera.fieldOfView < _cameraMover.MaxZoom)
        {
            _cameraMover.ZoomOut();
            yield return null;
        }
    }
}