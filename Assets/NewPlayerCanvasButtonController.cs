using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewPlayerCanvasButtonController : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public TMP_InputField nameInputField;
    

    public void OnBackButtonPressed()
    {
        mainMenuCanvas.SetActive(true);
        this.gameObject.SetActive(false); //this gameobject should be the newPlayercanvas itself.
    }

    public void OnCreateButtonPressed()
    {

    }

    public void OnRandomNameButtonPressed()
    {
        nameInputField.text = Assets.Utilities.StringGenerators.GenerateRandomName();
    }


}
