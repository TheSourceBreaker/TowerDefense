using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    Runner runner;
    public GameObject Player1;
    public GameObject Player2;

    void OnTriggerEnter(Collider collider)
    {
        if(collider.name == "Player1")
        {
            runner = Player1.GetComponent<Runner>();
            runner.orbCount++;
            Destroy(gameObject);
        }
        else if (collider.name == "Player2")
        {
            runner = Player2.GetComponent<Runner>();
            runner.orbCount++;
            Destroy(gameObject);
        }
    }
}
