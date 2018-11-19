using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class red_movement : MonoBehaviour {

    public float velocity = 3.9f;

    // Use this for initialization
    void Start () {

}
	
	// Update is called once per frame
	void Update () {

        Move();

	}


    void Move() {

        //float step = velocity * Time.deltaTime;
        //transform.position = Vector2.MoveTowards(transform.position, redPoint.transform.position, velocity * Time.deltaTime);



    }
}
