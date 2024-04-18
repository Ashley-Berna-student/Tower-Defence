using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence
{
    public class Health : MonoBehaviour
    {
        [SerializeField] public int currentHealth = 10;
        private Tower tower;

        void Start () 
        {
            tower = GetComponent<Tower>();
        }

        void TakeDamage(int damageAmount)
        {
            currentHealth -= damageAmount;
            ValueDisplay.OnValueChanged.Invoke(gameObject.name + "Health", currentHealth);
            if(currentHealth <=0)
            {
                if (gameObject.CompareTag("Enemy"))
                {
                    Destroy(gameObject);
                    int enemyTypeIndex = 0;
                    tower.EnemiesKilled(enemyTypeIndex);
                    print("enemies killed " + tower.GetEnemiesKilledCount(enemyTypeIndex));
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