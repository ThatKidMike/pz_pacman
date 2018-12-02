using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndTitleScript : MonoBehaviour {

    public GameObject pac;
    public GameObject run_ghost;
    public Text punkty;
    public Text info;
    public Text select;

    float velocity = 4.0f;
    Vector2 target = new Vector2(-349.09f, -267.71f);
    Vector2 direction = Vector2.right;

    private float theTime = 0;
    private float targetTime = 2;

    // Use this for initialization
    void Start () {


    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("escape")) {
            Application.Quit();
        }

        if (pac.transform.localPosition != (Vector3)target && run_ghost.transform.localPosition != (Vector3)target) {

            pac.transform.localPosition += (Vector3)(direction * velocity) * Time.deltaTime;
            run_ghost.transform.localPosition += (Vector3)(direction * velocity) * Time.deltaTime;

        }

        theTime += Time.deltaTime;

        if(theTime > targetTime) {

            punkty.text = StaticStas.Points.ToString();
            punkty.enabled = true;
            info.enabled = true;
            select.enabled = true;

            if (Input.GetKey(KeyCode.Space)) {

                info.color = Color.yellow;
                SceneManager.LoadScene("Menu");

            }


        }


    }

    }
