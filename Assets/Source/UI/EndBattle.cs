using UnityEngine;

public class EndBattle : MonoBehaviour
{
    [SerializeField] private EndBattle _endPanel;
    [SerializeField] private GameObject[] _objectsToHide;

    private void OnEnable()
    {
        _endPanel.enabled = false;

        for (int i = 0; i < _objectsToHide.Length; i++)
        {
            if(_objectsToHide[i] != null)
                _objectsToHide[i].SetActive(false);
        }
    }
}