using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonAI : MonoBehaviour {
    public float movementSpeed = 0.5f,
        infectedSpeed = 1.5f,
        minWaitTime = 2000,
        maxWaitTime = 10000;
    public Vector2 moveSize = new Vector2(3, 3);
    public bool infected = false;

    public float curTime = 0,
        targetTime = 0;

    public Vector3 targetPosition;

    Rigidbody2D rb;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        targetTime = Random.Range(0, maxWaitTime);
        targetPosition = transform.position + new Vector3(Random.Range(-moveSize.x, moveSize.x), Random.Range(-moveSize.y, moveSize.y), 0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!infected)
        {
            if (curTime > targetTime)
            {
                targetPosition = transform.position + new Vector3(Random.Range(-moveSize.x, moveSize.x), Random.Range(-moveSize.y, moveSize.y), 0);
                curTime = 0;
                targetTime = Random.Range(minWaitTime, maxWaitTime);
            }
            if (Vector3.Distance(transform.position, targetPosition) < .1f)
            {
                rb.velocity = Vector3.zero;
                curTime += Time.deltaTime;
            }
            else
            {
                rb.velocity = (targetPosition - transform.position).normalized * movementSpeed;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, PlayerMovement.instance.transform.position + targetPosition) < .3f)
            {
                targetPosition = new Vector3(Random.Range(-moveSize.x, moveSize.x), Random.Range(-moveSize.y, moveSize.y), 0);
            }
            rb.velocity = ((PlayerMovement.instance.transform.position + targetPosition) - transform.position).normalized * infectedSpeed;
        }
	}
    
    public void GetInfected()
    {
        infected = true;
        targetPosition = new Vector3(Random.Range(-moveSize.x, moveSize.x), Random.Range(-moveSize.y, moveSize.y), 0);
    }

    public void StopInfection()
    {
        infected = false;
        targetPosition = transform.position + new Vector3(Random.Range(-moveSize.x, moveSize.x), Random.Range(-moveSize.y, moveSize.y), 0);
        curTime = 0;
        targetTime = Random.Range(minWaitTime, maxWaitTime);
    }
}
