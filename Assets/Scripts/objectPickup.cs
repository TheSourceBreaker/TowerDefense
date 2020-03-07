using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectPickup : MonoBehaviour
{
    public bool triggerTest;
    public bool colliderTest;


    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player" && triggerTest == true)
        {
            print("Object picked up with trigger");
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && colliderTest == true)
        {
            print("Object picked up with collision");
            gameObject.AddComponent<Rigidbody>();
            //Destroy(gameObject);
        }
    }
    

}
