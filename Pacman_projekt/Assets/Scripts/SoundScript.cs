using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour {

    public GameObject fearModeSound;
    public AudioSource fearSound;

    public GameObject mainBackground;
    public AudioSource backgroundSound;

    public GameObject red;
    public GameObject blue;
    public GameObject orange;
    public GameObject pink;

    private Pink_movement pScript;
    private Orange_movement oScript;
    private Blue_movement bScript;
    private red_movement rScript;

    // Use this for initialization
    void Start () {

        fearModeSound = GameObject.Find("fearModeSound");
        fearSound = fearModeSound.GetComponent<AudioSource>();

        mainBackground = GameObject.Find("background_sound");
        backgroundSound = mainBackground.GetComponent<AudioSource>();

        red = GameObject.Find("ghost");
        blue = GameObject.Find("ghost_blue");
        orange = GameObject.Find("ghost_orange");
        pink = GameObject.Find("ghost_pink");

        pScript = pink.GetComponent<Pink_movement>();
        oScript = orange.GetComponent<Orange_movement>();
        bScript = blue.GetComponent<Blue_movement>();
        rScript = red.GetComponent<red_movement>();

    }
	
	// Update is called once per frame
	void Update () {

        checkStatus();
		
	}

    void checkStatus() {

        if(pScript.currentMode == Pink_movement.Mode.Fear || rScript.currentMode == red_movement.Mode.Fear
            || bScript.currentMode == Blue_movement.Mode.Fear || oScript.currentMode == Orange_movement.Mode.Fear) {
            backgroundSound.volume = 0;
            fearSound.volume = 1;
        } else {
            backgroundSound.volume = 1;
            fearSound.volume = 0;
        }

    }

}

