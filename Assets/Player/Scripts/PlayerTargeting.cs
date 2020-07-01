using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
public class PlayerTargeting : MonoBehaviour
{
	public GameObject currentTarget;
	public GameObject previousTarget;
	public GameObject[] potentialTargets;
	private float time;
	public float playerCheckInterval;
    public float selectionRadius;
	public int selectionCounter;
    float distance;
    public GameObject targetMarker;

    Vector2 ViewportPosition;
    Vector2 WorldObject_ScreenPosition;
    public RectTransform CanvasRect;
    public Camera cam;
    public RectTransform TargetNPCPanelTransform;
    public float NPCPanelXOffset;
    public StatusController statusController;

    // Start is called before the first frame update
    void Start()
	{
		
		time = 0;
		selectionCounter = 0;
		potentialTargets = FindAllTargets();
		if (playerCheckInterval == 0)
		{
			playerCheckInterval = 10;
		}

	}

	// Update is called once per frame
	void Update()
	{
		
		time += Time.deltaTime;

		if (time > playerCheckInterval)
		{
			potentialTargets = FindAllTargets();
            if (potentialTargets.Length < 1)
            {
                targetMarker.SetActive(false);
                currentTarget = null;
            }

            time = 0;

		}
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			selectionCounter++;

            if(potentialTargets.Length < 1)
            {
                return;
            }
			if (selectionCounter >= potentialTargets.Length)
			{
				selectionCounter = 0;
			}

			currentTarget = potentialTargets[selectionCounter];
            if(currentTarget != null)
            {
                SetTargetPosition();
                statusController.UpdateTargetNPCHealthBar(currentTarget.GetComponent<NPC>().currentHealth , currentTarget.GetComponent<NPC>().maxHealth);
                statusController.UpdateTargetNPCName(currentTarget.GetComponent<NPC>().npcName);
            }
            else
            {
                targetMarker.SetActive(false);
            }
			

		}
        if(currentTarget != null && currentTarget.GetComponent<NPC>().angleFromPlayerForward > 1.6f)
        {
            PositionNPCTargetUIToWorld(currentTarget);
            targetMarker.SetActive(true);
        }
        else
        {
            targetMarker.SetActive(false);
            TargetNPCPanelTransform.gameObject.SetActive(false);
        }








	}

	GameObject[] FindAllTargets()
	{
        GameObject[] allTargets = GameObject.FindGameObjectsWithTag("Creature");
        List<GameObject> targets = new List<GameObject>();
        foreach (GameObject target in allTargets) 
        {
            distance = (target.transform.position - gameObject.transform.position).magnitude;
            if ((distance < selectionRadius) && (target.GetComponent<NPC>().angleFromPlayerForward > Math.PI / 3 || target.Equals(currentTarget)))
            {
                targets.Add(target);
               
            }
            

            
        }
        

        return targets.ToArray();

	}

    public void SetTargetPosition()
    {
        targetMarker.SetActive(true);

        targetMarker.transform.SetParent(currentTarget.transform);
        targetMarker.transform.localPosition = new Vector3(0, .05f, 0);
    }

    public void PositionNPCTargetUIToWorld(GameObject rayHitObject)
    {
        ViewportPosition = cam.WorldToViewportPoint(rayHitObject.transform.position + new Vector3(0, rayHitObject.GetComponent<NPC>().NPCPanelOffset, 0));
        WorldObject_ScreenPosition = new Vector2(
        ((ViewportPosition.x * CanvasRect.sizeDelta.x) - (CanvasRect.sizeDelta.x * 0.5f)),
        ((ViewportPosition.y * CanvasRect.sizeDelta.y) - (CanvasRect.sizeDelta.y * 0.5f)));
        TargetNPCPanelTransform.anchoredPosition = WorldObject_ScreenPosition - new Vector2(NPCPanelXOffset, 0);

        TargetNPCPanelTransform.gameObject.SetActive(true);

    }


}
