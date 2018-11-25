using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Blue_movement : MonoBehaviour {

    public float velocity = 2.9f;

    private GameObject playerChar;
    private Vector2 direction;
    public GameObject find;
    public PillsSpawn lookFor;
    private Vector2 target;
    private Vector2 currDirection = Vector2.right;
    private Vector2 currPosition;
    private Vector2[] allDirections = new Vector2[4];
    private GameObject l_portal;
    private GameObject r_portal;
    //System.Random rnd = new System.Random();

    private Vector2 scatter = new Vector2(14, -11);

    // Use this for initialization
    void Start() {

        transform.localPosition = new Vector2(3, 4);

        allDirections[0] = Vector2.left;
        allDirections[1] = Vector2.right;
        allDirections[2] = Vector2.up;
        allDirections[3] = Vector2.down;

        find = GameObject.Find("PillsSpawn");
        lookFor = find.GetComponent<PillsSpawn>();
        playerChar = GameObject.Find("watman_1");
        l_portal = GameObject.Find("left_portal");
        r_portal = GameObject.Find("right_portal");
        target = new Vector2(1, 7);

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

                distance = getDistance(new Vector2(currPosition.x + validDirections[i].x, currPosition.y + validDirections[i].y),
                    getBlueTarget());
                if (leastDistance > distance) {
                    leastDistance = distance;
                    dir = validDirections[i];
                }

            }
            //Vector2 dir = validDirections[rnd.Next(counter)];
            currDirection = dir;

            target = new Vector2(target.x + currDirection.x, target.y + currDirection.y);

        }


        transform.localPosition = Vector2.MoveTowards(transform.localPosition, target, velocity * Time.deltaTime * 1.7f);

        if (transform.localPosition == l_portal.transform.localPosition) {
            transform.localPosition = r_portal.transform.localPosition;
            target = new Vector2(r_portal.transform.localPosition.x - 5, r_portal.transform.localPosition.y);
        } else if (transform.localPosition == r_portal.transform.localPosition) {
            transform.localPosition = l_portal.transform.localPosition;
            target = new Vector2(l_portal.transform.localPosition.x + 5, l_portal.transform.localPosition.y);
        }

    }

    Vector2 getBlueTarget() {

        Vector2 playerCharPos = playerChar.transform.localPosition;
        Vector2 playerCharFacing = playerChar.GetComponent<PacmanMovement>().direction;

        int playerCharPosX = Mathf.RoundToInt(playerChar.transform.position.x);
        int playerCharPosY = Mathf.RoundToInt(playerChar.transform.position.y);

        Vector2 playerCharTarget = new Vector2(playerCharPosX, playerCharPosY);

        Vector2 target = playerCharTarget + (2 * playerCharFacing);

        Vector2 tmpRedPos = GameObject.Find("ghost").transform.localPosition;

        int tmpRedPosX = Mathf.RoundToInt(tmpRedPos.x);
        int tmpRedPosY = Mathf.RoundToInt(tmpRedPos.y);

        tmpRedPos = new Vector2(tmpRedPosX, tmpRedPosY);

        float distance = getDistance(tmpRedPos, target);
        distance *= 2;

        target = new Vector2(tmpRedPos.x + distance, tmpRedPosY + distance);

        return target;

    }


    bool canMove(Vector2 d) {

        if (lookFor.xy[Mathf.RoundToInt(transform.localPosition.x + d.x) + 30, Mathf.RoundToInt(transform.localPosition.y + d.y) + 30] == 1
            && currDirection * -1 != d) {
            return true;
        } else {
            return false;
        }

    }

    float getDistance(Vector2 pos_1, Vector2 pos_2) {

        float dx = pos_1.x - pos_2.x;
        float dy = pos_1.y - pos_2.y;

        float distance = (float)Math.Sqrt(dx * dx + dy * dy);
        return distance;

        //return Vector2.Distance(pos_1, pos_2);
    }

}
