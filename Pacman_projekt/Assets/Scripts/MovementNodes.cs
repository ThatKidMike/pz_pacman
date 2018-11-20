using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementNodes : MonoBehaviour {

    public GameObject node;

	// Use this for initialization
	void Start () {

        spawnNodes();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void spawnNodes() {

        for (int j = 0; j < 10; j++) {
            for (int i = 0; i < 26; i++) {
                if (!Physics2D.OverlapCircle(new Vector2(-11 + i, -11 + j), (float)0.2)) {
                    if ((i == 0) && (j == 6))
                        Instantiate(node, new Vector2(-11 + i, -11 + j), Quaternion.identity);
                    else if ((i == 25) && (j == 6))
                        Instantiate(node, new Vector2(-11 + i, -11 + j), Quaternion.identity);
                    else
                        Instantiate(node, new Vector2(-11 + i, -11 + j), Quaternion.identity);
                }
            }
        }

        for (int j = 10; j < 15; j++) {
            for (int i = 5; i < 21; i++) {
                if (!Physics2D.OverlapCircle(new Vector2(-11 + i, -11 + j), (float)0.2))
                    Instantiate(node, new Vector2(-11 + i, -11 + j), Quaternion.identity);
            }
        }

        for (int i = 0; i < 9; i++) {
            if (!Physics2D.OverlapCircle(new Vector2(-11 + i, 4), (float)0.2))
                Instantiate(node, new Vector2(-11 + i, 4), Quaternion.identity);
        }

        for (int i = 17; i < 26; i++) {
            if (!Physics2D.OverlapCircle(new Vector2(-11 + i, 4), (float)0.2))
                Instantiate(node, new Vector2(-11 + i, 4), Quaternion.identity);
        }

        for (int j = 16; j < 20; j++) {
            for (int i = 5; i < 21; i++) {
                if (!Physics2D.OverlapCircle(new Vector2(-11 + i, -11 + j), (float)0.2))
                    Instantiate(node, new Vector2(-11 + i, -11 + j), Quaternion.identity);
            }
        }

        for (int j = 20; j < 31; j++) {
            for (int i = 0; i < 26; i++) {
                if (!Physics2D.OverlapCircle(new Vector2(-11 + i, -11 + j), (float)0.2)) {
                    if ((i == 0) && (j == 28))
                        Instantiate(node, new Vector2(-11 + i, -11 + j), Quaternion.identity);
                    else if ((i == 25) && (j == 28))
                        Instantiate(node, new Vector2(-11 + i, -11 + j), Quaternion.identity);
                    else
                        Instantiate(node, new Vector2(-11 + i, -11 + j), Quaternion.identity);
                }
            }
        }

    }

}
