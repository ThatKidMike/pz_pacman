using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PacmanMovement : MonoBehaviour {

    public float velocity = 4.0f;
    private Vector2 go;
    private Vector2 direction = Vector2.right;
    Vector2 position;
    public GameObject find;
    public PillsSpawn lookFor;


    // Use this for initialization
    void Start () {

        find = GameObject.Find("PillsSpawn");
        lookFor = find.GetComponent<PillsSpawn>();
        position = gameObject.transform.position;

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        CheckInput();
        Move();

	}


    // Checks for User's input and adjusts the movement direction and the facing direction
    void CheckInput() {
      
        if(Input.GetKey(KeyCode.LeftArrow) && valid(new Vector2(-1, 0))) {

            if(!direction.Equals(Vector2.left)) {
                transform.rotation = Quaternion.identity;
                transform.Rotate(0, 0 - 180, 0);
            }
            direction = Vector2.left;

        } else if(Input.GetKey(KeyCode.RightArrow) && valid(new Vector2(1, 0))) {

            if(!direction.Equals(Vector2.right)) {
                transform.rotation = Quaternion.identity;
            }
            direction = Vector2.right;

        } else if(Input.GetKey(KeyCode.UpArrow) && valid(new Vector2(0, 1))) {

            if(!direction.Equals(Vector2.up)) {
                transform.rotation = Quaternion.identity;
                transform.Rotate(0, 0, 0 + 90);
            }
            direction = Vector2.up;
        
        } else if(Input.GetKey(KeyCode.DownArrow) && valid(new Vector2(0, -1))) {

            if(!direction.Equals(Vector2.down)) {
                transform.rotation = Quaternion.identity;
                transform.Rotate(0, 0, 0 - 90);
            }
            direction = Vector2.down;

        }
  
    }

    void Move() {

        //Vector2 position = (transform.localPosition += (Vector3)(direction * velocity) * Time.deltaTime); 
        if (lookFor.xy[(int)Math.Round(transform.position.x) + 30, (int)Math.Round(transform.position.y) + 30] == 1) {
            // go = Vector2.MoveTowards(position, position+direction, velocity * Time.deltaTime);
            // gameObject.transform.position = go;
            // position = go;

            transform.position = Vector2.Lerp(transform.position, direction, velocity * Time.deltaTime);
            position = transform.position;
        }
        //transform.localPosition += (Vector3)(direction * velocity) * Time.deltaTime;



    }

    bool valid(Vector2 dir) {
        // Cast Line from 'next to Pac-Man' to 'Pac-Man'
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }


}
