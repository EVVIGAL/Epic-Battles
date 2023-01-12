using System;
using UnityEngine;

public class Security : MonoBehaviour
{
    public int Value { get; private set; }

    public void Add(int value)
    {
        if (value < 0)
            throw new InvalidOperationException();

        Value = value;
    }

    public void Remove()
    {
        Value = 0;
    }
}