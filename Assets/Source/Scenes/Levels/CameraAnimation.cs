using UnityEngine;

public class CameraAnimation : MonoBehaviour
{
    private Animator _animator;
    private string _animationName = "MainMenu";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        Time.timeScale = 1.0f;
        _animator.Play(_animationName);
    }
}