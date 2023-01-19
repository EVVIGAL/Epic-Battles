using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class TutorialTeamChecker : MonoBehaviour
{
    public event UnityAction _isReady;

    private void Update()
    {
        if (transform.childCount > 0)
        {
            _isReady?.Invoke();
        }
    }
}