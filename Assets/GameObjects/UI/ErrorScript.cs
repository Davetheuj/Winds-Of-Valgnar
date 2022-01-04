using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ErrorScript : MonoBehaviour
{
    

	float time = 0;
    bool isErased;
	

	
	void Update()
	{
		time -= Time.deltaTime;
		if (time < 0 && !isErased)
		{
			gameObject.GetComponent<TMP_Text>().text = "";
            isErased = true;
		}
	}

	public void SetErrorText(string errorText, float time)
	{
		this.time = time;
		gameObject.GetComponent<TMP_Text>().text = errorText;
        isErased = false;
       
    }
}