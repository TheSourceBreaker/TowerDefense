using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    private bool isDoorOpen;
    GameObject doorHinge;
    float open = 90;
    float close = 0;
    //If something hits my col(door), get parent component transform/this object's global transform
    //
    private void OnCollisionEnter(Collision collision)
    {
        if (isDoorOpen == false && collision.gameObject.tag == "Player") // Door is closed
        {
            isDoorOpen = true;
            print("Door is opening");
        }
        else if(isDoorOpen == true && collision.gameObject.tag == "Player") // Door is closed
        {
            isDoorOpen = false;
            print("Door is closing");
        }

    }

    void Update()
    {
        doorHinge = GameObject.FindGameObjectWithTag("doorHinge");
        
        //Transform v = GetComponentInParent<Transform>();
        if(isDoorOpen == false)
        {
            doorHinge.transform.Rotate(new Vector3(0f, 0f, 0f));
        }
        //v.transform.Rotate(new Vector3(0f, 90f, 0f) * Time.deltaTime);
        if (isDoorOpen == true)
        {
            doorHinge.transform.Rotate(new Vector3(0f, 0f, 0f));
        }


        //v.transform.rotation.y = open;

    }
}
