using UnityEngine;

public class AttackDistance : MonoBehaviour
{
    [SerializeField] private float _defaultValue;

    private const float SeaLevel = 3f;

    public float Value => transform.position.y > SeaLevel ? _defaultValue * 2f : _defaultValue;
}