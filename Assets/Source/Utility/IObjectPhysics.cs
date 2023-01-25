using UnityEngine;

public interface IObjectPhysics
{
    bool IsActive { get; }
    void Enable();
    void Disable();
    void AddForce(Vector3 force);
}