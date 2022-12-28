using UnityEngine;

public class MobileController : MonoBehaviour
{
    [SerializeField] private CameraMover _cameraMover;

    private Joystick _joystick;

    private void Awake()
    {
        _joystick = GetComponent<Joystick>();
    }

    private void Update()
    {
        _cameraMover.Move(_joystick.GetDirection());
    }
}
