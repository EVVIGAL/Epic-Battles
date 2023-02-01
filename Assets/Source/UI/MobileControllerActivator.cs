using UnityEngine;

public class MobileControllerActivator : MonoBehaviour
{
    private const string _controllerTxt = "MobileController";

    private void Awake()
    {
        if(PlayerPrefs.HasKey(_controllerTxt))
            gameObject.SetActive(PlayerPrefs.GetInt(_controllerTxt) == 1 ? true : false);
    }
}