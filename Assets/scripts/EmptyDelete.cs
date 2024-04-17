using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyDelete : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Empty"))
        {
            print(other.gameObject);
        }
    }
}
