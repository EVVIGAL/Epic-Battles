using System;
using UnityEngine;

public class Stealthiness : MonoBehaviour
{
    public float Value { get; private set; }

    public void Add(float value)
    {
        if (value < 0)
            throw new InvalidOperationException();

        Value = value;
    }

    public void Remove()
    {
        Value = 0f;
    }
}