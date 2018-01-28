using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectPerson : MonoBehaviour {

    public List<GameObject> objectsInRange = new List<GameObject>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            foreach(GameObject target in objectsInRange)
            {
                Infect(target);
            }
        }
	}

    public void Infect(GameObject target)
    {
        PersonAI targetAI;
        if(targetAI = target.GetComponent<PersonAI>())
        {
            targetAI.GetInfected();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        objectsInRange.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        objectsInRange.Remove(collision.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        objectsInRange.Add(collision.gameObject);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        objectsInRange.Remove(collision.gameObject);
    }
}
