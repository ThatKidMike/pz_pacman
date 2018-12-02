using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

    public Text startText;
    public Text selectText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("escape")) {
            Application.Quit();
        }

        if (Input.GetKey(KeyCode.Space)) {

            startText.color = Color.yellow;
            SceneManager.LoadScene("MainScene");

        }
		
	}


}
