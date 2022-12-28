using UnityEngine;

public class TeamColor : MonoBehaviour
{
    [SerializeField] private Material[] _materials;

    public void SetColor(Color color)
    {
        foreach (Material material in _materials)
            material.color = color;
    }
}