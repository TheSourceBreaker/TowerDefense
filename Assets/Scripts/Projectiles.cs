using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    float angle;
    public float speed;

    //private Transform MT;
    Vector3 prev = Vector3.zero;
    private MainTower mtScript;

    private int bulletDamage;
    private Vector3 direction;

    private void Start()
    {
        angle = transform.eulerAngles.y;
        direction = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), 0, -Mathf.Sin(Mathf.Deg2Rad * angle));
    }

    //void Update()
    //{
    //    //MT = GameObject.FindGameObjectWithTag("MainTower").transform;

    //    if (Vector3.Distance(transform.position, MT.transform.position) < 0.3)
    //    {
    //    }

    //}

    void FixedUpdate()
    {
        if (prev != Vector3.zero)
        {
            RaycastHit hit;
            if (Physics.Linecast(prev, transform.position, out hit))
            {
                mtScript.health = mtScript.health - bulletDamage;
                DestroyProjectile();
            }
            prev = transform.position;
        }
    
        transform.position += direction * speed * Time.deltaTime;

    }

    void DestroyProjectile()
    {
        Destroy(gameObject);

    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
