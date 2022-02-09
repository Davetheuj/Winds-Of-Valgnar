using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lunge : MonoBehaviour
{
    public AudioClipController clipController;

    private Weapon weapon;
    private GameObject weaponModel;


    // Start is called before the first frame update
    void Start()
    {
        clipController = gameObject.GetComponent<AudioClipController>();



    }

    // Update is called once per frame
    void Update()
    {

        clipController.PlayInteractionClip(0, 1, false, 0, false, true,true);
        //Send message to main hand's Equipment Controller to compute damage, select a weapon animation to play,

         
        weaponModel = GameObject.Find("Hand_R").GetComponentInChildren<Weapon>().gameObject;
        Transform trueParent = weaponModel.transform.parent;
        weapon = weaponModel.GetComponentInChildren<Weapon>();
        weaponModel.transform.parent = GameObject.Find("Main Camera").transform;
        //weapon.gameObject.GetComponent<Item>().inventoryButtonPrefab.GetComponent<Equipment>().SetDefaultLocalRotationAndPosition();
        weaponModel.transform.localPosition = weaponModel.GetComponent<Item>().inventoryButtonPrefab.GetComponent<Equipment>().defaultLocalPosition;
        weaponModel.transform.localRotation = Quaternion.Euler(weaponModel.GetComponent<Item>().inventoryButtonPrefab.GetComponent<Equipment>().defaultLocalRotation);

        weapon.SelectAndEnableRandomAnimation(trueParent);
        //Destroy this gameobject
        Destroy(gameObject);

    }



    IEnumerator WaitAndDestroy()
    {

        yield return new WaitForSecondsRealtime(.025f);
        Destroy(gameObject);
    }
}
