using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipTrigger : MonoBehaviour
{

    private GameObject tipPanel;
    public string tipText;
    private TipController controller;
    

    // Start is called before the first frame update
    void Start()
    {
        tipPanel = GameObject.Find("NotificationCanvas");
        controller = tipPanel.GetComponent<TipController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log($"Collided with {other.gameObject.name}");
        if(other.gameObject.name == "Player")
        {
            //Debug.Log("tip triggered");
            controller.ShowTip(tipText, 5);
            
        }
        Destroy(this.gameObject);
    }

    public void triggerToolTip()
    {
        controller.ShowTip(tipText, 5);
        Destroy(this);
    }

}
