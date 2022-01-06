using UnityEngine;

public class DeathController : MonoBehaviour
{
    public GameObject deathCanvas;
    public void ExecuteDeathRoutine()
    {
        //Should enable a global volume here for some sort of death effect

        deathCanvas.SetActive(true);

    }
}
