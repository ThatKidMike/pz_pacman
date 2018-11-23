using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class red_movement : MonoBehaviour {

    public float velocity = 3.5f;

    private GameObject playerChar;
    private Vector2 direction;
    public GameObject find;
    public PillsSpawn lookFor;
    private Vector2 target;
    private Vector2 currDirection;
    private Vector2[] allDirections = new Vector2[4];
    float leastDistance = 100000f;

    // Use this for initialization
    void Start () {

        transform.localPosition = new Vector2(-6, -5);

        allDirections[0] = Vector2.left;
        allDirections[1] = Vector2.right;
        allDirections[2] = Vector2.up;
        allDirections[3] = Vector2.down;

        find = GameObject.Find("PillsSpawn");
        lookFor = find.GetComponent<PillsSpawn>();
        playerChar = GameObject.Find("watman_1");
        target = playerChar.transform.position;
        currDirection = Vector2.right;

    }
	
	// Update is called once per frame
	void Update () {

        moveToNxtPoint();

	}


    void moveToNxtPoint() {

        Vector2 playerCharPos = playerChar.transform.position;
        target = new Vector2((int)Math.Round(playerCharPos.x), (int)Math.Round(playerCharPos.y));
        //Debug.Log(playerCharPos.x + ":" + playerCharPos.y);

        float distance = lengthFromTarget(playerCharPos);
        Debug.Log(distance);

        for (int i = 0; i < 4; i++) {

            if ((leastDistance > distance) && (canMove(allDirections[i])) && (currDirection * -1 != allDirections[i])) {
                leastDistance = distance;
                currDirection = allDirections[i];
                Vector2 currPosition = transform.localPosition;
                Vector2 targetPos = new Vector2((int)Math.Round(currPosition.x + currDirection.x), (int)Math.Round(currPosition.y + currDirection.y));
                transform.localPosition = Vector2.MoveTowards(currPosition, targetPos, velocity * Time.deltaTime);
            }
        }

      /*  if (canMove(currDirection) && currDirection!=newDirection) {
            Vector2 currPosition = transform.localPosition;
            Vector2 targetPos = new Vector2((int)Math.Round(currPosition.x + currDirection.x), (int)Math.Round(currPosition.y + currDirection.y));
            transform.localPosition = Vector2.MoveTowards(currPosition, targetPos, velocity * Time.deltaTime);
            Debug.Log(currDirection); 

        } */

    }
        

        

    bool canMove(Vector2 d) {

        Vector2 currPosition = transform.localPosition;

        if (lookFor.xy[(int)Math.Round(currPosition.x + d.x) + 30, (int)Math.Round(currPosition.y + d.y) + 30] == 1) {
            return true;
        } else {
            return false;
        }

    }

    float lengthFromTarget(Vector2 targetPos) {

        Vector2 value = targetPos - (Vector2)transform.localPosition;
        return value.sqrMagnitude;

    }

    bool passedTheTarget() {

        float nodeToTarget = lengthFromTarget(target);
        float nodeToSelf = lengthFromTarget(transform.localPosition);

        return nodeToSelf > nodeToTarget;

    }

    float getDistance(Vector2 pos_1, Vector2 pos_2) {

        float dx = pos_1.x - pos_2.x;
        float dy = pos_1.y - pos_2.y;

        float distance = (float)Math.Sqrt(dx * dx + dy * dy);

        return distance;

    }



}
