using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed = 3;

    Vector2 moveDirection;

    public static GameObject instance;

    Rigidbody2D rb;
    // Use this for initialization
	void Start () {
        instance = gameObject;
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.velocity = moveDirection * speed;
	}
}
