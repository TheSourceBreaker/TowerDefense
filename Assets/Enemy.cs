using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private int maxIndex;
    private Waypoints Wpoints;
    public GameObject projectile;
    public float projectileDamage;
    public int index;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public int health;
    public int maxHealth;

    void Start()
    {
        Wpoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
        maxIndex = Wpoints.waypoints.Length;
        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {
        if(index != maxIndex)
        {
            transform.position = Vector3.MoveTowards(transform.position, Wpoints.waypoints[index].position, speed * Time.deltaTime); // y-axis problem, it would float a bit here

            Vector3 dir = Wpoints.waypoints[index].position - transform.position;

            float angle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.down); // The rotation needs to change, try using += for smoother turns

            if(Vector3.Distance(transform.position, Wpoints.waypoints[index].position) < 0.1f)
            {
                index++;

            }

        }
        else
        {

            if(timeBtwShots <= 0 )
            {
                Instantiate(projectile, transform.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;

            }
        }
        //Enemy Fires Projectile goes here

    }
}
