using System.Collections;

public class ZoomIn : ZoomButton
{
    public override IEnumerator Zoom()
    {
        while (_camera.fieldOfView > _cameraMover.MinZoom)
        {
            _cameraMover.ZoomIn();
            yield return null;
        }
    }
}
