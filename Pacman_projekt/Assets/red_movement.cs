using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class red_movement : MonoBehaviour {

    public float velocity = 7.9f;

    private GameObject playerChar;
    private Vector2 direction;
    public GameObject find;
    public PillsSpawn lookFor;
    private Vector2 target;
    private Vector2 currDirection = Vector2.right;
    private Vector2 currPosition;
    private Vector2[] allDirections = new Vector2[4];
    //System.Random rnd = new System.Random();

    // Use this for initialization
    void Start() {

        transform.localPosition = new Vector2(-6, -5);

        allDirections[0] = Vector2.left;
        allDirections[1] = Vector2.right;
        allDirections[2] = Vector2.up;
        allDirections[3] = Vector2.down;

        find = GameObject.Find("PillsSpawn");
        lookFor = find.GetComponent<PillsSpawn>();
        playerChar = GameObject.Find("watman_1");
        target = new Vector2(0, -5);

    }

    // Update is called once per frame
    void Update() {

         moveGhost();

    }




    void moveGhost() {

        //This if statement is useful for allign the position of ghost - making sure that he turns on the right time
        if ((Vector2)transform.localPosition == target) {

            Vector2[] validDirections = new Vector2[4];
            int counter = 0;
            for (int i = 0; i < 4; i++) {

                if (canMove(allDirections[i])) {
                    validDirections[counter] = allDirections[i];
                    counter++;
                }

            }

            float leastDistance = 1000f;
            float distance;
            currPosition = transform.localPosition;
            Vector2 dir = Vector2.zero;
            for (int i = 0; i < counter; i++) {

                distance = getDistance(new Vector2(currPosition.x+validDirections[i].x, currPosition.y + validDirections[i].y), 
                    playerChar.transform.localPosition);
                if (leastDistance > distance) {
                    leastDistance = distance;
                    dir = validDirections[i];
                }

            }
            //Vector2 dir = validDirections[rnd.Next(counter)];
            currDirection = dir;

            target = new Vector2(target.x + currDirection.x, target.y + currDirection.y);

        } 

            transform.localPosition = Vector2.MoveTowards(transform.localPosition, target, velocity * Time.deltaTime);
  
    } 
  

    bool canMove(Vector2 d) {

        if (lookFor.xy[Mathf.RoundToInt(transform.localPosition.x + d.x) + 30, Mathf.RoundToInt(transform.localPosition.y + d.y) + 30] == 1 
            && currDirection * -1 != d) {
            return true;
        } else {
            return false;
        }

    }

    float lengthFromTarget(Vector2 targetPos) {

        Vector2 value = targetPos - (Vector2)transform.position - new Vector2(currDirection.x, currDirection.y);
        // Debug.Log(Vector2.Distance(targetPos, transform.localPosition));
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

        //return Vector2.Distance(pos_1, pos_2);
    }



}
