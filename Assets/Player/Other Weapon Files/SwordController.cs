﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    public bool attacking;
    public GameObject terrain;

    // Start is called before the first frame update
    void Start()
    {
        // Don't want to detect collisions with the ground or player
        Collider playerCollider = GameObject.Find("Player").GetComponent<Collider>();
        Collider thisCollider = GetComponent<Collider>();
        Physics.IgnoreCollision(playerCollider, thisCollider);

        attacking = false;
    }

    private void FixedUpdate()
    {
        // I know this is weird to put here, but if we do this in Start() we're not always
        // guaranteed that the player's script will have assigned the terrain variable yet

        if (terrain != null)
        {
            Collider thisCollider = GetComponent<Collider>();
            Collider terrainCollider = terrain.GetComponent<Collider>();
            Physics.IgnoreCollision(terrainCollider, thisCollider);
            terrain = null;
            print("Fixed collider");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (attacking)
        {
            // Do collider things
            print("Sword sliced " + collision.gameObject.name);
        }
    }
}
