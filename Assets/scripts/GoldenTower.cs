using System.Collections;
using UnityEngine;
using static Unity.PlasticSCM.Editor.WebApi.CredentialsResponse;

namespace TowerDefence
{
    public class GoldenTower : MonoBehaviour
    {
        public Player player;
        public int addGold = 1;
        public float goldDelay = 1.0f;

        private void Start()
        {
            player = FindObjectOfType<Player>();
            StartCoroutine(AddGold());
        }

        IEnumerator AddGold()
        {
            while (true)
            {
                player.gold += addGold;
                yield return new WaitForSeconds(goldDelay);
            }
        }
    }
}
