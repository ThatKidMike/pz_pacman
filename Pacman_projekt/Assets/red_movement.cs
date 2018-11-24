using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class red_movement : MonoBehaviour {

    public float velocity = 4.9f;

    private GameObject playerChar;
    private Vector2 direction;
    public GameObject find;
    public PillsSpawn lookFor;
    private Vector2 target;
    private Vector2 currDirection;
    private Vector2 currPosition;
    private Vector2[] allDirections = new Vector2[4];
    float leastDistance;

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

        currDirection = Vector2.right;
        target = new Vector2(1, -5);

        leastDistance = 10000f;

    }

    // Update is called once per frame
    void Update() {

        //moveToNxtPoint();
        // moveGhost();

    }

       


    void moveGhost() {

        if (new Vector2(Mathf.RoundToInt(currPosition.x), Mathf.RoundToInt(currPosition.y)) != target && target != null) {

            if(passedTheTarget()) {

                Debug.Log("Visited");

                currPosition = target;

                transform.localPosition = currPosition;

                //transform.localPosition = target;

               // transform.localPosition += (Vector3)currDirection * velocity * Time.deltaTime;

                //Debug.Log(target);

            } 

            moveToNxtPoint();

            target = new Vector2(Mathf.RoundToInt(transform.localPosition.x + currDirection.x), 
                Mathf.RoundToInt(transform.localPosition.y + currDirection.y));

        } else {

            transform.localPosition += (Vector3)currDirection * velocity * Time.deltaTime;

        }



    }



    Vector2 moveToNxtPoint() {

        Vector2 targetPos;
        Vector2 playerCharPos = playerChar.transform.position;
        targetPos = new Vector2(Mathf.RoundToInt(playerCharPos.x), Mathf.RoundToInt(playerCharPos.y));

        Vector2[] validDirection = new Vector2[4];
        Vector2 currPosition = transform.localPosition;
        int foundDirections = 0;

        //Debug.Log(distance);

        for (int i = 0; i < 4; i++) {

            if ((canMove(allDirections[i])) && (currDirection * -1 != allDirections[i])) {

                validDirection[i] = allDirections[i];
                foundDirections++;
                
            }
        }

        Debug.Log(foundDirections);

        if (foundDirections == 1) {

            int i = 0;
            while (validDirection[i] != Vector2.zero) {
                currDirection = validDirection[i];
                i++;
            }

        }

            if (foundDirections != 1) {

            float leastDistance = 10000f;

            for(int i = 0; i < 4; i++) {


                if (validDirection[i] != Vector2.zero) {

                    float distance = getDistance(new Vector2(transform.localPosition.x + validDirection[i].x,
                        transform.localPosition.y + validDirection[i].y), targetPos);

                    if (distance < leastDistance) {

                        leastDistance = distance;
                        currDirection = validDirection[i];

                    }

                }

            }

        }

       // target = new Vector2(Mathf.RoundToInt(transform.localPosition.x + currDirection.x),Mathf.RoundToInt(transform.localPosition.y + currDirection.y));
        Debug.Log(target);
        

        return currDirection;

        } 
  

    bool canMove(Vector2 d) {

        Vector2 currPosition = transform.localPosition;

        if (lookFor.xy[Mathf.RoundToInt(currPosition.x + d.x) + 30, Mathf.RoundToInt(currPosition.y + d.y) + 30] == 1) {
            return true;
        } else {
            return false;
        }

    }

    float lengthFromTarget(Vector2 targetPos) {

        Vector2 value = targetPos - (Vector2)transform.localPosition;
        // Debug.Log(Vector2.Distance(targetPos, transform.localPosition));
        return value.sqrMagnitude;

    }

    bool passedTheTarget() {

        float nodeToTarget = lengthFromTarget(target);
        float nodeToSelf = lengthFromTarget(new Vector2(transform.localPosition.x, transform.localPosition.y));

        return nodeToSelf > nodeToTarget;

    }

    float getDistance(Vector2 pos_1, Vector2 pos_2) {

        float dx = pos_1.x - pos_2.x;
        float dy = pos_1.y - pos_2.y;

        float distance = (float)Math.Sqrt(dx * dx + dy * dy);

        return Vector2.Distance(pos_1, pos_2);
    }



}
