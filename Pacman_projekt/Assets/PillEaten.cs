using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillEaten : MonoBehaviour {

    private GameObject playerChar;
    private PacmanMovement sounds;

    private void Start() {

        playerChar = GameObject.Find("watman_1");
        sounds = playerChar.GetComponent<PacmanMovement>();

    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.name == "watman_1") {
            Destroy(gameObject);
            sounds.PlaySound();
        }
            

    }

}
