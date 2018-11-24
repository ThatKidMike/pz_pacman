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
    float leastDistance = 100000f;

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
        target = new Vector2(0, -5);

    }

    // Update is called once per frame
    void Update() {

         moveGhost();

    }




    void moveGhost() {
        
        if((Vector2)transform.localPosition == target) {

            target = new Vector2(target.x + Vector2.up.x, target.y + Vector2.up.y);

        }

        transform.localPosition = Vector2.MoveTowards(transform.localPosition, target, velocity * Time.deltaTime);


    } 
  

    bool canMove(Vector2 d) {

        if (lookFor.xy[Mathf.RoundToInt(transform.localPosition.x + d.x) + 30, Mathf.RoundToInt(transform.localPosition.y + d.y) + 30] == 1) {
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
