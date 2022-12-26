using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class Shoot : Action
{
    public MonoBehaviour WeaponSource;

    private IWeapon _weapon => (IWeapon)WeaponSource;

    public override TaskStatus OnUpdate()
    {
        if (_weapon.CanShoot == false)
            return TaskStatus.Running;

        _weapon.Shoot();
        return TaskStatus.Success;
    }
}