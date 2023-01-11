using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class Shoot : Action
{
    public MonoBehaviour WeaponSource;
    public SharedTransform Target;

    private IWeapon _weapon => (IWeapon)WeaponSource;

    public override TaskStatus OnUpdate()
    {
        if (_weapon.CanShoot == false)
            return TaskStatus.Running;

        _weapon.Shoot(Target.Value);
        return TaskStatus.Success;
    }
}