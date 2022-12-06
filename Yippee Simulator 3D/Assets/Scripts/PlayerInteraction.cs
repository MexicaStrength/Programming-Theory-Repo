using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public bool collectedItem;
    public int score;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Pepsi"))
        {
            collectedItem = true;
            score--;
            Destroy(other.gameObject);
            StartCoroutine(itemCountDown());
        }
        if (other.CompareTag("Coke"))
        {
            collectedItem = true;
            score++;
            Destroy(other.gameObject);
            StartCoroutine(itemCountDown());
        }
    }

    IEnumerator itemCountDown()
    {
        yield return new WaitForSeconds(0);
        collectedItem = false;
    }
}
