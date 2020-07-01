using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityInstantiator : MonoBehaviour
{

    public GameObject ability;
    public int manaCost;
    public int healthCost;
    public bool isTargeted;
    
    public GameObject currentAbility;
   

    public bool InstantiateAbility()
    {
        Instantiate(ability);
     
        return true;
    }
  
}
