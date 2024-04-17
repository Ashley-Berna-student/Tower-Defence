using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spauner : MonoBehaviour
{
    public bool spawn = true;
    public GameObject prefab;
    public float baseSpawnRate = 5f;
    public float spawnRateIncrease = 1f;
    public float spawnRateIncreaseInterval = 10f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
        StartCoroutine(IncreaseSpawnRate());
    }

    IEnumerator Spawn()
    {
        while(spawn)
        {
            Instantiate(prefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(baseSpawnRate);
        }
    }

    IEnumerator IncreaseSpawnRate()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(spawnRateIncreaseInterval);
            baseSpawnRate -= spawnRateIncrease;

            baseSpawnRate = Mathf.Max(baseSpawnRate, 0.4f);
        }
    }
}
