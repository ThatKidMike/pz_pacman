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
    //System.Random rnd = new System.Random

    private Vector2 spawnCoordinates;
    private Vector2 initialCoordinates;

    private float waitTime = 7;
    private float theTime = 0;
    private bool isInSpawn = true;

    public RuntimeAnimatorController up;
    public RuntimeAnimatorController down;
    public RuntimeAnimatorController left;
    public RuntimeAnimatorController right;
    public RuntimeAnimatorController white;
    public RuntimeAnimatorController blue;

    private Mode previousMode;

    public int scatterModeTimer1 = 7;
    public int chaseModeTimer1 = 20;
    public int scatterModeTimer2 = 7;
    public int chaseModeTimer2 = 20;
    public int scatterModeTimer3 = 5;
    public int chaseModeTimer3 = 20;
    public int scatterModeTimer4 = 5;

    public Sprite invisibleUp;
    public Sprite invisibleDown;
    public Sprite invisibleLeft;
    public Sprite invisibleRight;

    public int fearTimer = 10;
    public int blinkingTime = 7;

    bool isWhite = false;


    private int modeChangeIterator = 1;
    private float modeChangeTimer = 0;
    private float blinkTimer = 0;

    public enum Mode {
        Chase,
        Scatter,
        Fear,
        Eaten
    };

    Mode currentMode = Mode.Scatter;

    
    //

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

        spawnCoordinates = new Vector2(0, 4);
        initialCoordinates = new Vector2(1, 7);

    }

    // Update is called once per frame
    void Update() {

        moveGhost();
        ModeUpdate();
        CollisionDetection();

    }

    void Eaten() {

        currentMode = Mode.Eaten;

    }

    void CollisionDetection() {

        Rect ghostRect = new Rect(transform.position, transform.GetComponent<SpriteRenderer>().sprite.bounds.size / 4);
        Rect playerCharRect = new Rect(playerChar.transform.position, playerChar.transform.GetComponent<SpriteRenderer>().sprite.bounds.size / 4);

        if (ghostRect.Overlaps(playerCharRect) && currentMode == Mode.Fear) {

            Eaten();

        }

    }

    void ModeUpdate() {

        if (currentMode != Mode.Fear) {

            modeChangeTimer += Time.deltaTime;

            if (modeChangeIterator == 1) {

                if (currentMode == Mode.Scatter && modeChangeTimer > scatterModeTimer1) {

                    ChangeMode(Mode.Chase);
                    previousMode = Mode.Chase;
                    modeChangeTimer = 0;

                }

                if (currentMode == Mode.Chase && modeChangeTimer > chaseModeTimer1) {
                    modeChangeIterator = 2;
                    ChangeMode(Mode.Scatter);
                    previousMode = Mode.Scatter;
                    modeChangeTimer = 0;
                }

            } else if (modeChangeIterator == 2) {

                if (currentMode == Mode.Scatter && modeChangeTimer > scatterModeTimer2) {

                    ChangeMode(Mode.Chase);
                    previousMode = Mode.Chase;
                    modeChangeTimer = 0;

                }

                if (currentMode == Mode.Chase && modeChangeTimer > chaseModeTimer2) {
                    modeChangeIterator = 3;
                    ChangeMode(Mode.Scatter);
                    previousMode = Mode.Scatter;
                    modeChangeTimer = 0;
                }

            } else if (modeChangeIterator == 3) {

                if (currentMode == Mode.Scatter && modeChangeTimer > scatterModeTimer3) {

                    ChangeMode(Mode.Chase);
                    previousMode = Mode.Chase;
                    modeChangeTimer = 0;

                }

                if (currentMode == Mode.Chase && modeChangeTimer > chaseModeTimer3) {
                    modeChangeIterator = 4;
                    ChangeMode(Mode.Scatter);
                    previousMode = Mode.Scatter;
                    modeChangeTimer = 0;
                }

            } else if (modeChangeIterator == 4) {

                if (currentMode == Mode.Scatter && modeChangeTimer > scatterModeTimer4) {

                    ChangeMode(Mode.Chase);
                    previousMode = Mode.Chase;
                    modeChangeTimer = 0;

                }

            }

        } else if (currentMode == Mode.Fear) {

            modeChangeTimer += Time.deltaTime;

            if (modeChangeTimer >= blinkingTime) {

                blinkTimer += Time.deltaTime;

                if (blinkTimer >= 0.1f) {

                    blinkTimer = 0f;

                    if (isWhite) {

                        transform.GetComponent<Animator>().runtimeAnimatorController = blue;
                        isWhite = false;

                    } else {

                        transform.GetComponent<Animator>().runtimeAnimatorController = white;
                        isWhite = true;

                    }

                }

            }

            if (modeChangeTimer > fearTimer) {

                ChangeMode(previousMode);
                modeChangeTimer = 0;

            }

        }

    }

    void ChangeMode(Mode m) {

        if (currentMode != Mode.Fear)
            modeChangeTimer = 0;

        if (currentMode == Mode.Fear && m == Mode.Fear)
            modeChangeTimer = 0;

        currentMode = m;

    }

    public void ChangeForFear() {
        ChangeMode(Mode.Fear);
    }

    void updateAnimatorController() {

        if (currentMode != Mode.Fear && currentMode != Mode.Eaten) {

            if (currDirection == Vector2.up) {

                transform.GetComponent<Animator>().runtimeAnimatorController = up;

            } else if (currDirection == Vector2.down) {

                transform.GetComponent<Animator>().runtimeAnimatorController = down;

            } else if (currDirection == Vector2.right) {

                transform.GetComponent<Animator>().runtimeAnimatorController = right;

            } else if (currDirection == Vector2.left) {

                transform.GetComponent<Animator>().runtimeAnimatorController = left;

            }

        } else if (currentMode == Mode.Fear) {

            transform.GetComponent<Animator>().runtimeAnimatorController = blue;

        } else if (currentMode == Mode.Eaten) {

            transform.GetComponent<Animator>().runtimeAnimatorController = null;

            if (currDirection == Vector2.up) {

                transform.GetComponent<SpriteRenderer>().sprite = invisibleUp;

            } else if (currDirection == Vector2.down) {

                transform.GetComponent<SpriteRenderer>().sprite = invisibleDown;

            } else if (currDirection == Vector2.right) {

                transform.GetComponent<SpriteRenderer>().sprite = invisibleRight;

            } else if (currDirection == Vector2.left) {

                transform.GetComponent<SpriteRenderer>().sprite = invisibleLeft;

            }

        }

    }

    void moveGhost() {

        if (isInSpawn) {
            spawnTime();
        }

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

                if (currentMode == Mode.Chase) {

                    distance = getDistance(new Vector2(currPosition.x + validDirections[i].x, currPosition.y + validDirections[i].y),
                        getBlueTarget());
                    if (leastDistance > distance) {
                        leastDistance = distance;
                        dir = validDirections[i];
                    }

                } else if(currentMode == Mode.Scatter) {

                    distance = getDistance(new Vector2(currPosition.x + validDirections[i].x, currPosition.y + validDirections[i].y),
                        scatter);
                    if (leastDistance > distance) {
                        leastDistance = distance;
                        dir = validDirections[i];
                    }

                } else if (currentMode == Mode.Fear) {

                    leastDistance = 1;
                    distance = getDistance(new Vector2(currPosition.x + validDirections[i].x, currPosition.y + validDirections[i].y),
                        playerChar.transform.localPosition);
                    if (leastDistance < distance) {
                        leastDistance = distance;
                        dir = validDirections[i];
                    }

                } else if (currentMode == Mode.Eaten) {

                    distance = getDistance(new Vector2(currPosition.x + validDirections[i].x, currPosition.y + validDirections[i].y),
                        initialCoordinates);
                    if (leastDistance > distance) {
                        leastDistance = distance;
                        dir = validDirections[i];
                    }

                }

            }
            //Vector2 dir = validDirections[rnd.Next(counter)];
            currDirection = dir;

            target = new Vector2(target.x + currDirection.x, target.y + currDirection.y);

        }

        if (currentMode == Mode.Fear) {

            transform.localPosition = Vector2.MoveTowards(transform.localPosition, target, velocity * Time.deltaTime * 0.7f);

        } else if (currentMode == Mode.Eaten) {
            if (transform.localPosition == (Vector3)initialCoordinates)
                target = spawnCoordinates;
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, target, velocity * Time.deltaTime * 2.4f);
            if (transform.localPosition == (Vector3)spawnCoordinates) {
                ChangeMode(previousMode);
                target = initialCoordinates;
            }
        } else {

            transform.localPosition = Vector2.MoveTowards(transform.localPosition, target, velocity * Time.deltaTime * 1.7f);
        }

        updateAnimatorController();

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

    void spawnTime() {

        theTime += Time.deltaTime;

        if (waitTime > theTime) {
            target = new Vector2(3, 4);
        } else {
            isInSpawn = false;
            target = new Vector2(1, 7);
        }

    }


}
