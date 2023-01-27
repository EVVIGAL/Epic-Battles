using UnityEngine;

public class EndBattle : MonoBehaviour
{
    [SerializeField] private GameObject[] _objectsToHide;

    private void OnEnable()
    {
        for (int i = 0; i < _objectsToHide.Length; i++)
        {
            if(_objectsToHide[i] != null)
                _objectsToHide[i].SetActive(false);
        }
    }
}