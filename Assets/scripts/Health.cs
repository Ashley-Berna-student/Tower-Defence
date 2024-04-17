using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence
{
    public class Health : MonoBehaviour
    {
        [SerializeField] public int currentHealth = 10;

        void TakeDamage(int damageAmount)
        {
            currentHealth -= damageAmount;
            ValueDisplay.OnValueChanged.Invoke(gameObject.name + "Health", currentHealth);
            if(currentHealth <=0)
            {
                if (gameObject.CompareTag("Enemy"))
                {
                    Destroy(gameObject);
                }
            }
        }

        public static void TryDamage(GameObject target, int damageAmount)
        {
            Health targetHealth = target.GetComponent<Health>();
            if ((targetHealth))
            {
                targetHealth.TakeDamage(damageAmount);
            }
        }
    }
}