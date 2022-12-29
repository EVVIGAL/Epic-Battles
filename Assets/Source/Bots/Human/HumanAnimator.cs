using UnityEngine;

[RequireComponent (typeof(Animator), typeof(CharacterController))]
public class HumanAnimator : MonoBehaviour
{
    [SerializeField] private float _dampTime = 0.1f;

    private Animator _animator;
    private CharacterController _characterController;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _animator.SetFloat(AnimatorCharacterController.Params.Speed, _characterController.velocity.magnitude, _dampTime, Time.deltaTime);
    }
}