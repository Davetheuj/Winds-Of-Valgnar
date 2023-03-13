using System.Collections.Generic;
using UnityEngine;

namespace Assets.GameObjects.Items
{
    class Consumable : MonoBehaviour
    {
        private AudioClipController clipController;
        private StatsController playerStats;
        
        [SerializeField]
        List<GameObject> boons;

        [SerializeField]
        private int healthToRestore;

        [SerializeField]
        private int manaToRestore;


        private void Start()
        {
            clipController = gameObject.GetComponent<AudioClipController>();
            playerStats = GameObject.Find("Player").GetComponent<StatsController>();
        }

        private void Update()
        {
            clipController.PlayClip(null, 0, 1, false, 0, false, true, true);

            playerStats.currentHealth = Mathf.Clamp(playerStats.currentHealth + healthToRestore, 0, playerStats.maxHealth);
            playerStats.currentMana = Mathf.Clamp(playerStats.currentMana + manaToRestore, 0, playerStats.maxMana);
           
            foreach (GameObject boon in boons)
            {
                Instantiate(boon);
            }

            playerStats.statusController.UpdateStatusUI();
            Destroy(this.gameObject);
        }
    }
}
