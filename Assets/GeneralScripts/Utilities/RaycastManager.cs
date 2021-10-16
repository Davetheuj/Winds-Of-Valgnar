using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class RaycastManager : MonoBehaviour
{
    public Transform player;


public RectTransform quickInspectItemPanelTransform;
    public TMP_Text quickInspectItemPaneltext;

    public RectTransform HoverNPCPanelTransform;
    public TMP_Text HoverNPCNameText;
   public Transform HoverNPCHealthBar;
    public TMP_Text HoverNPCHealthText;

    public RectTransform TargetNPCPanelTransform;


    bool showItemPanel = false;
    bool showHoverNPCPanel = false;
    bool showCursor = false;
    public Vector3 itemPanelOffset = new Vector3(0,25f,0);
    public RectTransform CanvasRect;
    public Camera cam;
    //public float NPCPanelOffset;
    public float NPCPanelXOffset;

    Vector2 ViewportPosition;
    Vector2 WorldObject_ScreenPosition;

    private GameObject oldObject;

    public PlayerTargeting targeting;
    public StatusController statusController;

    public InventoryController inventoryController;

    public ErrorScript errorScript;

    public DialoguePanelController dialogueController;

    public ConsoleManager console;
    // Update is called once per frame
    void Update()
    {
        showItemPanel = false;
        showHoverNPCPanel = false;

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (EventSystem.current.IsPointerOverGameObject())

        {
            return;
        }

        if (Physics.Raycast(ray, out hit))
        {
            var rayHitObject = hit.transform.gameObject;
            //Debug.Log("hit with " + rayHitObject.name);



            //Item sequence
           if (rayHitObject.GetComponent<Item>() != null)
            {
                Item item = rayHitObject.GetComponent<Item>();

                if (Input.GetMouseButtonDown(0))
                {
                    //Debug.Log("Attemping to pick up " + rayHitObject.name);
                    InitiateItemPickup(rayHitObject);
                    return;
                }

                if (oldObject == rayHitObject)
                {
                    PositionItemPanelToMouse();
                    return;
                }

                oldObject = rayHitObject;

                if (item.isStackable && item.quantity > 1)
                {
                    quickInspectItemPaneltext.SetText($"{item.itemName} x {item.quantity}");
                }
                else
                {
                    quickInspectItemPaneltext.SetText(item.itemName);
                }

                PositionItemPanelToMouse();



            }

            else if (rayHitObject.GetComponent<NPC>() != null)
            {

                //selecting target with mouse
                if (Input.GetMouseButtonDown(0))
                {
                    targeting.currentTarget = rayHitObject;
                    targeting.SetTargetPosition();
                    targeting.PositionNPCTargetUIToWorld(rayHitObject);
                    statusController.UpdateTargetNPCHealthBar((float)rayHitObject.GetComponent<NPC>().currentHealth, (float)rayHitObject.GetComponent<NPC>().maxHealth);
                    statusController.UpdateTargetNPCName(rayHitObject.GetComponent<NPC>().npcName);
                }
                if (targeting.currentTarget == rayHitObject)
                {

                }
                else
                {
                    statusController.UpdateHoverNPCHealthBar((float)rayHitObject.GetComponent<NPC>().currentHealth, (float)rayHitObject.GetComponent<NPC>().maxHealth);
                    statusController.UpdateHoverNPCName(rayHitObject.GetComponent<NPC>().npcName);

                    if (oldObject == rayHitObject)
                    {
                        PositionNPCUIToWorld(rayHitObject);
                        return;
                    }
                    oldObject = rayHitObject;
                    PositionNPCUIToWorld(rayHitObject);
                }
            }

            if (rayHitObject.GetComponent<NPCDialogueController>() != null)
            {
                if (Input.GetMouseButtonDown(0))
                {
                   
                    dialogueController.NPC = rayHitObject;
                   
                    dialogueController.UpdateAndShowDialoguePanel();
                }
            }
        }

        if (!showItemPanel)
        {
            quickInspectItemPanelTransform.gameObject.SetActive(false);
   
        }
        if (!showHoverNPCPanel)
        {
            HoverNPCPanelTransform.gameObject.SetActive(false);

        }

    }
    void Start()
    {
        console = GameObject.Find("ConsolePanel").GetComponent<ConsoleManager>();
    }

    public void PositionNPCUIToWorld(GameObject rayHitObject)
    {
        ViewportPosition = cam.WorldToViewportPoint(rayHitObject.transform.position + new Vector3(0, rayHitObject.GetComponent<NPC>().NPCPanelOffset, 0));
        WorldObject_ScreenPosition = new Vector2(
        ((ViewportPosition.x * CanvasRect.sizeDelta.x) - (CanvasRect.sizeDelta.x * 0.5f)),
        ((ViewportPosition.y * CanvasRect.sizeDelta.y) - (CanvasRect.sizeDelta.y * 0.5f)));
        HoverNPCPanelTransform.anchoredPosition = WorldObject_ScreenPosition - new Vector2(NPCPanelXOffset, 0);
        showHoverNPCPanel = true;
        HoverNPCPanelTransform.gameObject.SetActive(true);

    }
    public void PositionItemPanelToMouse()
    {
        quickInspectItemPanelTransform.position = Input.mousePosition + itemPanelOffset;//WorldObject_ScreenPosition+ new Vector2(0,50); Use anchoredposition instead of position
        showItemPanel = true;
        quickInspectItemPanelTransform.gameObject.SetActive(true);

    }

    public void InitiateItemPickup(GameObject hitObject)
    {
        Item item = hitObject.GetComponent<Item>();
        if(hitObject.GetComponent<CurrencyPickup>() != null)
        {
            if (hitObject.GetComponent<Item>().itemName == "Coins") {
                inventoryController.coins += hitObject.GetComponent<Item>().quantity;
            }
            //can add additional currencies here
            console.AddConsoleMessage1($"{item.quantity} {item.itemName} have been added to your inventory");
            DestroyImmediate(hitObject);
            return;
        }

        var inventorySlot = inventoryController.GetFirstEmptySlot();
        if (inventorySlot == null)
        {
            errorScript.SetErrorText("Inventory is full!", .5f);
            return;
        }
       

            var inventoryObject = Instantiate(hitObject.GetComponent<Item>().inventoryButtonPrefab, inventorySlot.transform);
        if (item.quantity > 1)
        {
            console.AddConsoleMessage1($"{item.quantity} {item.itemName} have been added to your inventory!");
        }
        else
        {
            console.AddConsoleMessage1($"{item.itemName} has been added to your inventory!");
        }
        inventoryObject.transform.localPosition = new Vector3(0, 0, 0);
        inventoryObject.transform.localScale = new Vector3(1,1,1);

        //Check for quest components here

        Destroy(hitObject);


    }
   
}
