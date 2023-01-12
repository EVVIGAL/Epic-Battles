using UnityEngine.Events;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private int _cost;

    public UnityAction IsDestroyed;

    private CharacterControllerMovement _character;

    public int Cost => _cost;

    private void OnEnable()
    {
        _character = GetComponent<CharacterControllerMovement>();
    }

    private void Update()
    {
        if (_character != null)
        {
            if (!_character.enabled)
            {
                IsDestroyed?.Invoke();
                this.enabled = false;
            }
        }
    }

    public void Remove()
    {
        Destroy(gameObject);
    }
}