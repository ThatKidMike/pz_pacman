using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEntrence : MonoBehaviour {

    BoxCollider2D entrence_collider;

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if(collision.name.Contains("ghost")) {

            entrence_collider = GetComponent<BoxCollider2D>();
            entrence_collider.enabled = false;

        } else {

            entrence_collider.enabled = true;

        }

    }


}
