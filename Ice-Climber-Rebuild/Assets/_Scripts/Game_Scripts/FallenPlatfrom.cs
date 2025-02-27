﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenPlatfrom : MonoBehaviour
{
    public float fallDelay = .5f;
    public float respawnDelay = 5f;

    private Rigidbody2D rb2d;
    private BoxCollider2D bx2d;

    private Vector3 start;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        bx2d = GetComponent<BoxCollider2D>();
        start = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", fallDelay);
            Invoke("Respawn", fallDelay + respawnDelay);
        }
    }

    void Fall()
    {
        rb2d.isKinematic = false;
        bx2d.isTrigger = true;
    }

    void Respawn()
    {
        transform.position = start;
        rb2d.isKinematic = true;
        rb2d.velocity = Vector3.zero;
        bx2d.isTrigger = false;
    }
}
