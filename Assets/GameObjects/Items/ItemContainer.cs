using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainer : MonoBehaviour
{
    public string containerName;
    public List<GameObject> containerItems;

    public void RemoveContainerItem(int index)
    {
        containerItems.RemoveAt(index);
    }
}
