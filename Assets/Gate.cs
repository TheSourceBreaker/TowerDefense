using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    Runner runner1;
    Runner runner2;

    public GameObject Door1;
    public GameObject Door2;

    public GameObject Player1;
    public GameObject Player2;

    public int goalCount;
    public float speed;

    void Update()
    {
        //Vector3 v = new Vector3(transform.position.x, transform.position.y - 90, transform.position.z);

        runner1 = Player1.GetComponent<Runner>();
        if(runner1.orbCount == goalCount)
        {
            Door1.transform.Translate(Vector3.up * (speed * Time.deltaTime));
        }

        //v = new Vector3(transform.position.x, transform.position.y + 90, transform.position.z);

        runner2 = Player2.GetComponent<Runner>();
        if (runner2.orbCount == goalCount)
        {
            Door2.transform.Translate(Vector3.up * (speed * Time.deltaTime));
        }
    }
}
