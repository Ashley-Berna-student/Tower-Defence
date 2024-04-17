using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence
{
    [RequireComponent(typeof(Animator))]
    public class Tower : MonoBehaviour
    {
        [SerializeField] private List<GameObject> enimiesInRange = new List<GameObject>();
        public Tower_SO towerType;
        private bool firing = false;
        GameObject enemyTarget;
        Animator animator;

        public Transform topElement;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        public void DamageTarget()
        {
            if (!enemyTarget) return;
            Health.TryDamage(enemyTarget, towerType.damage);
        }

        private void RemoveDestroyedEnemies()
        {
            int i = 0;
            while(i < enimiesInRange.Count)
            {
                if (enimiesInRange[i])
                {
                    i++;
                }
                else
                {
                    enimiesInRange.RemoveAt(i);
                }
            }
        }

        IEnumerator DamageEnemyTarget()
        {
            firing = true;

            while (enimiesInRange.Count > 0)
            {
                RemoveDestroyedEnemies();
                if (enimiesInRange.Count > 0)
                {
                    enemyTarget = enimiesInRange[0];
                    RotateTowardsEnemy();
                    animator.SetTrigger("Fire");
                }
                yield return new WaitForSeconds(towerType.fireRate);
            }

            firing = false;
        }

        private void RotateTowardsEnemy()
        {
            float rotationSpeed = 300f;
            if (enemyTarget != null && topElement != null)
            {
                Vector3 direction = enemyTarget.transform.position - topElement.position;

                Quaternion horizontalLookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

                Vector3 verticalDirection = enemyTarget.transform.position - transform.position;
                Quaternion verticalLookRotation = Quaternion.LookRotation(verticalDirection);

                Quaternion combinedRotation = Quaternion.Lerp(horizontalLookRotation, verticalLookRotation, 0.5f);

                topElement.rotation = Quaternion.Lerp(topElement.rotation, combinedRotation, Time.deltaTime * rotationSpeed);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy")) enimiesInRange.Add(other.gameObject);

            if (!firing) StartCoroutine(DamageEnemyTarget());
        }

        private void OnTriggerExit(Collider other)
        {
            enimiesInRange.Remove(other.gameObject);
        }
    }

}