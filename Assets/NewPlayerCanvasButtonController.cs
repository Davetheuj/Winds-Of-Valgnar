using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerCanvasButtonController : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    

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

    }


}
