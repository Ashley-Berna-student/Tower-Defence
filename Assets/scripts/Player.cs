using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence
{
    public class Player : MonoBehaviour
    {

        [SerializeField] public GameObject towerPrefab;
        [SerializeField] public int gold;
        Health health;

        Tower[] towers;

        public UnityEngine.UI.Text endText;

        Grid grid;
        UICursorPointer cursorCapture;
        Cursor cursor;

        private void Awake()
        {
            grid = FindObjectOfType<Grid>();
            cursorCapture = FindObjectOfType<UICursorPointer>();
            cursor = GetComponentInChildren<Cursor>();
            health = GetComponent<Health>();
            towers = FindObjectsOfType<Tower>();
        }
        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && !cursorCapture.cursorOverUI)
            {
                TryPlaceTower(grid, Grid.WorldToGrid(cursor.transform.position));
            }

            ValueDisplay.OnValueChanged.Invoke("PlayerGold", gold);

            if (health.currentHealth <= 0)
            {
                Time.timeScale = 0f;
                if (endText != null)
                {
                    endText.enabled = true;
                }
            }

            foreach (Tower tower in towers)
            {
                if (tower.GetEnemiesKilledCount(0) == 5)
                {
                    print("you win");
                }
            }
        }

        public bool TryPlaceTower(Grid grid, Vector3Int tileCoordinates)
        {
            if (gold < Tower_SO.GetCost(towerPrefab))
            {
                return false;
            }
            if (grid.Occupied(tileCoordinates))
            {
                return false;
            }

            GameObject newTower = Instantiate(towerPrefab, tileCoordinates, Quaternion.identity);
            grid.Add(tileCoordinates, newTower);
            gold -= Tower_SO.GetCost(towerPrefab);

            return true;
        }

        public void UpdateGold(int amount)
        {
            gold += amount;
        }
    }
}