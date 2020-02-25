using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public float speed;
    private Transform MT;
    private Vector3 v;

    private void Start()
    {
        MT = GameObject.FindGameObjectWithTag("GunBarrel").transform;

        v = new Vector3(MT.transform.position.x, MT.transform.position.y, MT.transform.position.z);

    }
    void Update()
    {
        transform.position += Vector3.MoveTowards(transform.position, v, speed * Time.deltaTime);
        //transform.Translate(v * speed * Time.deltaTime);

        //if(transform.position.x == v.x && transform.position.z == v.z)
        //{
        //    DestroyProjectile();
        //}
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
