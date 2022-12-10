using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private GameManager gameManager;
    public int pointVal;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }
    private void OnTriggerEnter(Collider other)
    {
        gameManager.UpdateScore(pointVal);
        Destroy(gameObject);
    }
}
