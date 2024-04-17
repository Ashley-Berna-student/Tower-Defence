using UnityEngine;
using UnityEngine.UI;

namespace TowerDefence
{
    public class End_UI : MonoBehaviour
    {
        public Text endText;
        private Health health;

        private void Start()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                health = player.GetComponent<Health>();
            }

            endText.enabled = false;
        }

        private void Update()
        {
            if (health != null && health.currentHealth <= 0)
            {
                endText.enabled = true;
            }
            else
            {
                endText.enabled = false;
            }
        }
    }
}
