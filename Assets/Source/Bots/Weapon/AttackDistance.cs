using UnityEngine;

public class AttackDistance : MonoBehaviour
{
    [SerializeField] private float _defaultValue;

    private const float SeaLevel = 3f;
    private const float RandomOffsetDistance = 3f;

    private float _randomOffset;

    private void Awake()
    {
        _randomOffset = Random.Range(-RandomOffsetDistance, RandomOffsetDistance);
    }

    public float Value => transform.position.y > SeaLevel ? _defaultValue * 2f + _randomOffset : _defaultValue + _randomOffset;
}