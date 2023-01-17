using UnityEngine;
using System.Collections;

public class InfoText : MonoBehaviour
{
    private float _lifeTime = 2f;

    public IEnumerator HideAfterWait()
    {
        yield return new WaitForSecondsRealtime(_lifeTime);
        gameObject.SetActive(false);
    }
}