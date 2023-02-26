using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestruction : MonoBehaviour
{
    [SerializeField]
    private float destructionTime;
    private float timer = 0;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= destructionTime)
        {
            Destroy(this.gameObject);
        }
    }
}
