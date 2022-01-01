using Assets.GeneralScripts.Math;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawner : MonoBehaviour
{
    [Tooltip("If you add/remove a drop make sure you do the same to the corresponding dropRate!")]
    public List<GameObject> drops;
    public List<float> dropWeights;
    private List<Range> dropRanges = new List<Range>();



    public int dropsPerDeath = 1;
    public bool hasUnconditionableDrops;
    public List<GameObject> unconditionableDrops;


    public void SpawnDrops()
    {
        for(int i = 1; i<= dropsPerDeath; i++)
        {
            GameObject drop = getNewDrop();
            if (drop != null)
            {
               drop = Instantiate(drop, this.transform);
                drop.transform.SetParent(GameObject.Find("Environment").transform);
                drop.transform.position = this.transform.position;
            }
        }
        if (hasUnconditionableDrops)
        {
            foreach(GameObject drop in unconditionableDrops)
            {
                GameObject newDrop = Instantiate(drop, this.transform);
                newDrop.transform.SetParent(GameObject.Find("Environment").transform);
                newDrop.transform.position = this.transform.position;
            }
        }
    }

    private GameObject getNewDrop()
    {
        dropRanges.Clear();
        float weightTotal = 0;
        //sum up the total weights
        foreach (float weight in dropWeights)
        {
            weightTotal += weight;
        }
        if(weightTotal == 0)
        {
            return null;
        }
       
        //assign relative percentages and create ranges based on those
        float previousMax = dropWeights[0] / weightTotal;
        dropRanges.Add(new Range(0, previousMax));

        float currentMax;
        for(int i = 1; i<dropWeights.Count; i++)
        {
            currentMax = previousMax + dropWeights[i] / weightTotal;
            dropRanges.Add(new Range(previousMax, currentMax));
            previousMax = currentMax;
        }
        //roll a random number and find the first range it is in (ranges are inclusive)
        int counter = 0;
        bool rangeFound = false;
        float roll = Random.value;
        while(!rangeFound && counter < dropRanges.Count)
        {
            if(dropRanges[counter].isInRange(roll, true))
            {
                return drops[counter];
            }
            counter++;
        }
        return null;
    }
}
