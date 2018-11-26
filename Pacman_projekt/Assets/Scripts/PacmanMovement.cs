﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PacmanMovement : MonoBehaviour {

    public AudioClip sound1;
    public AudioClip sound2;

    public float velocity = 3f;
    private Vector2 go;
    public Vector2 direction = Vector2.right;
    //Vector2 position;
    public GameObject find;
    public PillsSpawn lookFor;
    public Vector2 orientation;

    private bool playedSound1 = false;

    private AudioSource _audio;



    // Use this for initialization
    void Start () {

        find = GameObject.Find("PillsSpawn");
        lookFor = find.GetComponent<PillsSpawn>();
        transform.position = new Vector2(1, -5);
        _audio = gameObject.GetComponent<AudioSource>();
        //position = gameObject.transform.position;

    }
	
	// Update is called once per frame
	void Update () {

        CheckInput();
        //Move();
        moveToNxtPoint(direction);

	}

    public void PlaySound() {

        if(playedSound1) {

            _audio.PlayOneShot(sound1);
            playedSound1 = false;

        } else {

            _audio.PlayOneShot(sound2);
            playedSound1 = true;

        }
    }


    // Checks for User's input and adjusts the movement direction and the facing direction
    void CheckInput() {
      
        if(Input.GetKeyDown(KeyCode.LeftArrow) && /*valid(new Vector2(-2, 0)) &&*/ canMove(Vector2.left)) {

            if(!direction.Equals(Vector2.left)) {
                transform.rotation = Quaternion.identity;
                transform.Rotate(0, 0 - 180, 0);
                direction = Vector2.left;
                moveToNxtPoint(direction);
            }
            //Debug.Log("Left");

        } else if(Input.GetKeyDown(KeyCode.RightArrow) && /*valid(new Vector2(2, 0)) &&*/ canMove(Vector2.right)) {

            if(!direction.Equals(Vector2.right)) {
                transform.rotation = Quaternion.identity;
                direction = Vector2.right;
                moveToNxtPoint(direction);
            }
            //Debug.Log("Right");

        } else if(Input.GetKeyDown(KeyCode.UpArrow) && /*valid(new Vector2(0, 2)) &&*/ canMove(Vector2.up)) {

            if(!direction.Equals(Vector2.up)) {
                transform.rotation = Quaternion.identity;
                transform.Rotate(0, 0, 0 + 90);
                direction = Vector2.up;
                moveToNxtPoint(direction);
            }
            //Debug.Log("Up");

        } else if(Input.GetKeyDown(KeyCode.DownArrow) && /*valid(new Vector2(0, -2)) &&*/ canMove(Vector2.down)) {

            if(!direction.Equals(Vector2.down)) {
                transform.rotation = Quaternion.identity;
                transform.Rotate(0, 0, 0 - 90);
                direction = Vector2.down;
                moveToNxtPoint(direction);
            }
            //Debug.Log("Down");

        }
  
    }

    //Is not used for now
    void Move() {

         //Vector2 position = (transform.localPosition += (Vector3)(direction * velocity) * Time.deltaTime); 
        if (lookFor.xy[(int)Math.Round(transform.position.x) + 30, (int)Math.Round(transform.position.y) + 30] == 1) {
            transform.localPosition += (Vector3)(direction * velocity) * Time.deltaTime;
        }

    }

    void moveToNxtPoint(Vector2 d) {

        Vector2 currPosition = transform.localPosition;
        // transform.localPosition = new Vector2((int)Math.Round(currPosition.x + d.x), (int)Math.Round(currPosition.y + d.y));
        Vector2 targetPos = new Vector2((int)Math.Round(currPosition.x + d.x), (int)Math.Round(currPosition.y + d.y));
        transform.localPosition = Vector2.MoveTowards(currPosition, targetPos, velocity * Time.deltaTime * 1.2f);
        
    }

    bool valid(Vector2 dir) {
        // Cast Line from 'next to Pac-Man' to 'Pac-Man'
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }

    bool canMove(Vector2 d) {

        Vector2 currPosition = transform.localPosition;

        if(lookFor.xy[(int)Math.Round(currPosition.x + d.x) + 30, (int)Math.Round(currPosition.y + d.y) + 30] == 1) {
            return true;
        } else {
            return false;
        }

    }


}
