using UnityEngine;

public class FlyMovement : CharacterControllerMovement
{
    protected override void Move(Vector3 delta)
    {
        CharacterController.Move(delta * Time.deltaTime);
    }
}