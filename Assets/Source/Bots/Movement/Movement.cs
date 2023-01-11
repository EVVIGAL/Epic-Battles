using UnityEngine;

public abstract class Movement : MonoBehaviour, IMovement
{
    [field: SerializeField] public float MoveSpeed { get; set; }
    [field: SerializeField] public float AngularSpeed { get; set; }

    [SerializeField] private MonoBehaviour _groundMaterialSource;
    private IGroundMaterialDetector _groundMaterial => (IGroundMaterialDetector)_groundMaterialSource;

    protected Vector3 Direction { get; set; }

    protected float CurrentSpeed { get; private set; }

    public void Move(Vector2 direction)
    {
        Direction = direction;
        CurrentSpeed = MoveSpeed * (1f -_groundMaterial.Friction);
    }

    protected void Rotate()
    {
        if (Direction == Vector3.zero)
            return;

        Quaternion rotate = Quaternion.LookRotation(new Vector3(Direction.x, 0f, Direction.y));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotate, AngularSpeed * Time.deltaTime);
    }

    private void OnValidate()
    {
        if (_groundMaterialSource && !(_groundMaterialSource is IGroundMaterialDetector))
        {
            Debug.LogError(_groundMaterialSource + " + is not implement " + nameof(IGroundMaterialDetector));
            _groundMaterialSource = null;
        }
    }
}