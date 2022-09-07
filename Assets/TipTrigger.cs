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
        tipPanel = GameObject.Find("TipButton");
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
            controller.tipText.text = tipText;
            controller.timer = 0;
            tipPanel.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
