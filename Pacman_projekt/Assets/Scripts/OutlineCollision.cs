using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineCollision : MonoBehaviour {

    private List<GameObject> childrenList = new List<GameObject>();
    private BoxCollider2D boxCol;

    private float oX = (float)0.502;
    private float oY = (float)0.502;

    // Use this for initialization
    void Start () {

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
	void Update () {
		
	}

    void makeCollider() {

        for (int i = 0; i < childrenList.Count; i++) {

            if(childrenList[i].name!="l_portal_cov" && childrenList[i].name!="r_portal_cov" 
                && childrenList[i].name != "left_portal" && childrenList[i].name != "right_portal")
            boxCol = childrenList[i].AddComponent<BoxCollider2D>();

            if (boxCol.name.Contains("tileset_10"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2(oX, 0);
            else if (boxCol.name.Contains("tileset_11"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2(oX, oY);
            else if (boxCol.name.Contains("tileset_12"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2(-oX, oY);
            else if (boxCol.name.Contains("tileset_32"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2(-oX, oY);
            else if (boxCol.name.Contains("tileset_30"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2(oX, oY);
            else if (boxCol.name.Contains("tileset_21"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2(oX, -oY);
            else if (boxCol.name.Contains("tileset_22"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2(-oX, -oY);
            else if (boxCol.name.Contains("tileset_25"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2(oX, -oY);
            else if (boxCol.name.Contains("tileset_32"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2(oX, -oY);
            else if (boxCol.name.Contains("tileset_36"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2(-oX, -oY);
            else if (boxCol.name.Contains("tileset_31"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2(oX, oY);
            else if (boxCol.name.Contains("tileset_18"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2(0, -oY);
            else if (boxCol.name.Contains("tileset_19"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2((float)0.38, (float)-0.38);
            else if (boxCol.name.Contains("tileset_15"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2((float)-0.38, (float)-0.38);
            else if (boxCol.name.Contains("tileset_16"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2((float)0.38, (float)-0.38);
            else if (boxCol.name.Contains("tileset_17"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2((float)-0.38, (float)-0.38);
            else if (boxCol.name.Contains("tileset_1"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2(0, oY);
            else if (boxCol.name.Contains("tileset_9"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2(-oX, 0);
            else if (boxCol.name.Contains("tileset_6"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2((float)-0.38, (float)0.38);
            else if (boxCol.name.Contains("tileset_5"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2((float)0.38, (float)0.38);
            else if (boxCol.name.Contains("tileset_2"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2((float)0.38, (float)0.38);
            else if (boxCol.name.Contains("tileset_0"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2((float)-0.38, (float)0.38);
            else if (boxCol.name.Contains("tileset_3"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2(oX, -oY);
            else if (boxCol.name.Contains("tileset_4"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2(-oX, -oY);
            else if (boxCol.name.Contains("tileset_7"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2((float)-0.38, (float)0.38);
            else if (boxCol.name.Contains("tileset_8"))
                boxCol.GetComponent<BoxCollider2D>().offset = new Vector2((float)0.38, (float)0.38);




        }


    }
}
