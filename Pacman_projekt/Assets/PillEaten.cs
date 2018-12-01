using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillEaten : MonoBehaviour {

    private GameObject playerChar;
    private PacmanMovement sounds;
    private GameObject red;
    private red_movement redScript;
    private GameObject blue;
    private Blue_movement blueScript;
    private GameObject orange;
    private Orange_movement orangeScript;
    private GameObject pink;
    private Pink_movement pinkScript;

    public GameObject find;
    public PillsSpawn lookFor;

    private void Start() {

        playerChar = GameObject.Find("watman_1");
        sounds = playerChar.GetComponent<PacmanMovement>();

        red = GameObject.Find("ghost");
        redScript = red.GetComponent<red_movement>();
        blue = GameObject.Find("ghost_blue");
        blueScript = blue.GetComponent<Blue_movement>();
        orange = GameObject.Find("ghost_orange");
        orangeScript = orange.GetComponent<Orange_movement>();
        pink = GameObject.Find("ghost_pink");
        pinkScript = pink.GetComponent<Pink_movement>();

        find = GameObject.Find("PillsSpawn");
        lookFor = find.GetComponent<PillsSpawn>();

    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.name == "watman_1" && gameObject.name.Contains("energizer")) {
            sounds.PlaySound();
            redScript.ChangeForFear();
            blueScript.ChangeForFear();
            orangeScript.ChangeForFear();
            pinkScript.ChangeForFear();
            Destroy(gameObject);
            sounds.score += 20;
            lookFor.amount--;
        } else if (collision.name == "watman_1") {
            sounds.PlaySound();
            Destroy(gameObject);
            sounds.score += 10;
            lookFor.amount--;

        } 
            

    }

}
