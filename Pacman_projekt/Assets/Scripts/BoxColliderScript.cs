using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColliderScript : MonoBehaviour {


    private List<GameObject> childrenList = new List<GameObject>();
    private BoxCollider2D boxCol;

    private float oX = (float)0.502;
    private float oY = (float)0.502;

    // Use this for initialization;
    // Initilize children to the List
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

    // Allign PolygonCollider2D to fit the actual shape of the sprite (At least in approximate);
    // Goes through all children of the prefab
    void makeCollider() {
            
        for (int i = 0; i < childrenList.Count; i++) {

            boxCol = childrenList[i].AddComponent<BoxCollider2D>();

            // Interior
            if (boxCol.name.Contains("35"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2(oX, 0);
            else if (boxCol.name.Contains("36"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2(-oX, 0);
            else if (boxCol.name.Contains("21"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2(0, -oY);
            else if (boxCol.name.Contains("31"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2(0, oY);
            else if (boxCol.name.Contains("26"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2(-oX, -oY);
            else if (boxCol.name.Contains("20"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2(oX, -oY);
            else if (boxCol.name.Contains("39"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2(oX, oY);
            else if (boxCol.name.Contains("40"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2(-oX, oY);
            else if (boxCol.name.Contains("22"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2(-oX, -oY);
            else if (boxCol.name.Contains("32"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2(-oX, oY);
            else if (boxCol.name.Contains("30"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2(oX, oY);
            else if (boxCol.name.Contains("25"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2(oX, -oY);
            else if (boxCol.name.Contains("34"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2((float)0.30, (float)-0.30);
            else if (boxCol.name.Contains("33"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2((float)-0.30, (float)-0.30);
            else if (boxCol.name.Contains("23"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2((float)-0.30, (float)0.30);
            else if (boxCol.name.Contains("24"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2((float)0.30, (float)0.30);

        }


    }

}

