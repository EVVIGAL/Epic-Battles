using UnityEngine.Events;
using UnityEngine;

public class TutorialTeamChecker : MonoBehaviour
{
    [SerializeField] private GameObject _settingsPanel;

    public event UnityAction IsReady;

    private void Update()
    {
        if (transform.childCount > 0 && !_settingsPanel.activeSelf)
            IsReady?.Invoke();

        if (Time.timeScale > 0)
            enabled = false;
    }
}
