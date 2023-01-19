using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class Patrol : Action
{
    [SerializeField] public SharedTransform Path;
    [SerializeField] private float _stopingDistance = 1f;

    public MonoBehaviour MovementSource;
    private IMovement _movement => (IMovement)MovementSource;

    private int _currentPointIndex;
    private Transform[] _points;

    public override void OnAwake()
    {
        base.OnAwake();
        _points = Path.Value.GetComponentsInChildren<Transform>();
    }

    public override TaskStatus OnUpdate()
    {
        float distance = Vector3.Distance(transform.position, _points[_currentPointIndex].position);
        if (distance <= _stopingDistance)
        {
            _currentPointIndex++;
            if (_currentPointIndex >= _points.Length)
                _currentPointIndex = 0;
        }

        Vector3 direction = (_points[_currentPointIndex].position - transform.position).normalized;
        _movement.Move(new Vector2(direction.x, direction.z));

        return TaskStatus.Running;
    }
}