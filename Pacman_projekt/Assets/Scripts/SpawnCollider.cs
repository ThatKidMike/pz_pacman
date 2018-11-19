using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollider : MonoBehaviour {


    private List<GameObject> childrenList = new List<GameObject>();
    private BoxCollider2D boxCol;


    private float oX = (float)0.502;
    private float oY = (float)0.502;

    void Start() {

        Transform[] children = GetComponentsInChildren<Transform>(true);

        for (int i = 0; i < children.Length; i++) {
            Transform child = children[i];
            if (child != transform) {
                childrenList.Add(child.gameObject);
            }
        }

        makeCollider();

    }

    // Update is called once per frame
    void Update() {

    }

    void makeCollider() {

        for (int i = 0; i < childrenList.Count; i++) {

            boxCol = childrenList[i].AddComponent<BoxCollider2D>();

            if (boxCol.name.Contains("tileset_42"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2(0, oY);
            else if (boxCol.name.Contains("tileset_28"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2(0, -oY);
            else if (boxCol.name.Contains("tileset_37"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2(oX, 0);
            else if (boxCol.name.Contains("tileset_38"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2(-oX, 0);
            else if (boxCol.name.Contains("tileset_41"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2(oX, oY);
            else if (boxCol.name.Contains("tileset_43"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2(-oX, oY);
            else if (boxCol.name.Contains("tileset_29"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2(-oX, -oY);
            else if (boxCol.name.Contains("tileset_27"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2(oX, -oY);
        }


    }

}

