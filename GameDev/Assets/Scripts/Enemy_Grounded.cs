using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Grounded : MonoBehaviour
{

    public float distance;
    Transform player;
    public Transform shootPoint;
    public GameObject bullet;
    public float timeUntilNextShootInSeconds;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        time = timeUntilNextShootInSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.position, transform.position) < distance)
        {
            time -= timeUntilNextShootInSeconds * Time.deltaTime;
            if(time <= 0f)
            {
                time = timeUntilNextShootInSeconds;
                Instantiate(bullet, shootPoint.position, shootPoint.rotation);
            }
            
        }
        Vector3 dir = player.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        shootPoint.parent.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
