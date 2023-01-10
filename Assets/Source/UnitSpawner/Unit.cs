using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private int _cost;

    public int Cost => _cost;

    public void Remove()
    {
        Destroy(gameObject);
    }
}