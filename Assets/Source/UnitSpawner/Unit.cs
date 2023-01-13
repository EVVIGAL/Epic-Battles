using UnityEngine.Events;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private int _cost;
    [SerializeField] private string _name;

    public int Cost => _cost;

    public string Name => _name;

    public void Remove()
    {
        Destroy(gameObject);
    }
}