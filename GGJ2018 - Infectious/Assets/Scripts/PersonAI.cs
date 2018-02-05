using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonAI : MonoBehaviour {
    public float movementSpeed = 0.5f,
        infectedSpeed = 1.5f,
        minWaitTime = 2000,
        maxWaitTime = 10000,
        looseInfectionRange = 4;
    public Vector2 moveSize = new Vector2(3, 3);

    public bool infected = false, wasInfected = false;
	public float resistance = 3f;

    public float curTime = 0,
        targetTime = 0;

    public Vector3 targetPosition;

    public Color damagedButNotInfectedColor = Color.yellow;
    public Color infectedColor = Color.red;

    Rigidbody2D rb;
    Animator anim;

	// Use this for initialization
	void Start ()
    {
        GameManager.instance.possibleInfected += 1;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
            if (Vector3.Distance(transform.position, targetPosition) < .2f)
            {
                rb.velocity = Vector3.zero;
                curTime += Time.deltaTime;
                anim.SetBool("isWalking", false);
            }
            else
            {
                rb.velocity = (targetPosition - transform.position).normalized * movementSpeed;
                anim.SetBool("isWalking", true);
            }
        }
        else
        { 
            if(Vector3.Distance(transform.position, PlayerMovement.instance.transform.position) > looseInfectionRange)
            {
                StopInfection();
                return;
            }
            if (Vector3.Distance(transform.position, PlayerMovement.instance.transform.position + targetPosition) < .3f)
            {
                targetPosition = new Vector3(Random.Range(-moveSize.x, moveSize.x), Random.Range(-moveSize.y, moveSize.y), 0);
                anim.SetBool("isWalking", false);
            }
            else
            {
                anim.SetBool("isWalking", true);
            }
            rb.velocity = ((PlayerMovement.instance.transform.position + targetPosition) - transform.position).normalized * infectedSpeed;
        }
        anim.SetBool("isInfected", infected);
        //To fix sort order. Mess with later.
       // transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
	}
    
    public void GetInfected()
    {
        resistance = (resistance > 0f ? resistance - 1f : 0f);

        infected = resistance == 0f;
        if (infected)
        {
            targetPosition = new Vector3(Random.Range(-moveSize.x, moveSize.x), Random.Range(-moveSize.y, moveSize.y), 0);
            GetComponentInChildren<SpriteRenderer>().color = infectedColor;
        }
        else
        {
            GetComponentInChildren<SpriteRenderer>().color = damagedButNotInfectedColor;
        }
        if(!wasInfected && infected)
        {
            GameManager.instance.infected += 1;
            wasInfected = true;
        }
    }

    public void StopInfection()
    {
        if (infected)
        {
            wasInfected = false;
            GameManager.instance.infected -= 1;
            infected = false;
            targetPosition = transform.position + new Vector3(Random.Range(-moveSize.x, moveSize.x), Random.Range(-moveSize.y, moveSize.y), 0);
            curTime = 0;
            targetTime = Random.Range(minWaitTime, maxWaitTime);
            GetComponentInChildren<SpriteRenderer>().color = Color.white;
        }
    }
}
