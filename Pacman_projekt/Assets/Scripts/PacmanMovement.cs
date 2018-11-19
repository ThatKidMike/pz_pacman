using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMovement : MonoBehaviour {

    public float velocity = 4.0f;
    private Vector2 direction = Vector2.right;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        CheckInput();
        Move();
        UpdatePosition();

	}

    void UpdatePosition() {
       
    }


    // Checks for User's input and adjusts the movement direction and the facing direction
    void CheckInput() {
      
        if(Input.GetKeyDown(KeyCode.LeftArrow)) {

            if(!direction.Equals(Vector2.left)) {
                transform.rotation = Quaternion.identity;
                transform.Rotate(0, 0 - 180, 0);
            }
            direction = Vector2.left;

        } else if(Input.GetKeyDown(KeyCode.RightArrow)) {

            if(!direction.Equals(Vector2.right)) {
                transform.rotation = Quaternion.identity;
            }
            direction = Vector2.right;

        } else if(Input.GetKeyDown(KeyCode.UpArrow)) {

            if(!direction.Equals(Vector2.up)) {
                transform.rotation = Quaternion.identity;
                transform.Rotate(0, 0, 0 + 90);
            }
            direction = Vector2.up;
        
        } else if(Input.GetKeyDown(KeyCode.DownArrow)) {

            if(!direction.Equals(Vector2.down)) {
                transform.rotation = Quaternion.identity;
                transform.Rotate(0, 0, 0 - 90);
            }
            direction = Vector2.down;

        }
  
    }

    void Move() {

        transform.localPosition += (Vector3)(direction * velocity) * Time.deltaTime;

    }


}
