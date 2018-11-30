using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndTitleScript : MonoBehaviour {

    public GameObject pac;
    public GameObject run_ghost;

    float velocity = 4.0f;
    Vector2 target = new Vector2(-349.09f, -267.71f);
    Vector2 direction = Vector2.right;

    // Use this for initialization
    void Start () {

        

	}
	
	// Update is called once per frame
	void Update () {

        if (pac.transform.localPosition != (Vector3)target && run_ghost.transform.localPosition != (Vector3)target) {

            pac.transform.localPosition += (Vector3)(direction * velocity) * Time.deltaTime;
            run_ghost.transform.localPosition += (Vector3)(direction * velocity) * Time.deltaTime;

        }

    }
}
