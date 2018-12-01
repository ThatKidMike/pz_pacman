using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillsSpawn : MonoBehaviour {

    public GameObject pellet;
    public GameObject bigPill;
    public List<KeyValuePair<int, int>> coordinates = new List<KeyValuePair<int, int>>();
    public GameObject node;
    public int[,] xy = new int[100, 100];
    public int amount = 0;


	// Use this for initialization
	void Start () {

        spawnPills();
        spawnNodes();
       		
	}
	
	// Update is called once per frame
	void Update () { 

       

    }

    void spawnPills() {

        coordinates.Add(new KeyValuePair<int, int>(15, 4));
        coordinates.Add(new KeyValuePair<int, int>(16, 4));
        coordinates.Add(new KeyValuePair<int, int>(17, 4));
        coordinates.Add(new KeyValuePair<int, int>(-12, 4));
        coordinates.Add(new KeyValuePair<int, int>(-13, 4));
        coordinates.Add(new KeyValuePair<int, int>(-14, 4));
        coordinates.Add(new KeyValuePair<int, int>(-1, -5));
        coordinates.Add(new KeyValuePair<int, int>(0, -5));
        coordinates.Add(new KeyValuePair<int, int>(1, -5));
        coordinates.Add(new KeyValuePair<int, int>(2, -5));

        for (int j = 0; j < 10; j++) {
            for (int i = 0; i < 26; i++) {
                if (!Physics2D.OverlapCircle(new Vector2(-11 + i, -11 + j), (float)0.2)) {
                    if ((i == 0) && (j == 6)) {
                        Instantiate(bigPill, new Vector2(-11 + i, -11 + j), Quaternion.identity);
                        amount++;
                        coordinates.Add(new KeyValuePair<int, int>(-11 + i, -11 + j));
                    } else if ((i == 25) && (j == 6)) {
                        Instantiate(bigPill, new Vector2(-11 + i, -11 + j), Quaternion.identity);
                        amount++;
                        coordinates.Add(new KeyValuePair<int, int>(-11 + i, -11 + j));
                    } else {
                        Instantiate(pellet, new Vector2(-11 + i, -11 + j), Quaternion.identity);
                        amount++;
                        coordinates.Add(new KeyValuePair<int, int>(-11 + i, -11 + j));
                    }
                }
            }
        }

        for(int j = 10; j < 15; j++) {
            for (int i = 5; i < 21; i++) {
                if (!Physics2D.OverlapCircle(new Vector2(-11 + i, -11 + j), (float)0.2)) {
                    Instantiate(pellet, new Vector2(-11 + i, -11 + j), Quaternion.identity);
                    amount++;
                    coordinates.Add(new KeyValuePair<int, int>(-11 + i, -11 + j));
                }
            }
        }

        for(int i = 0; i < 9; i++) {
            if (!Physics2D.OverlapCircle(new Vector2(-11 + i, 4), (float)0.2)) {
                Instantiate(pellet, new Vector2(-11 + i, 4), Quaternion.identity);
                amount++;
                coordinates.Add(new KeyValuePair<int, int>(-11 + i, 4));
            }
        }

        for (int i = 17; i < 26; i++) {
            if (!Physics2D.OverlapCircle(new Vector2(-11 + i, 4), (float)0.2)) {
                Instantiate(pellet, new Vector2(-11 + i, 4), Quaternion.identity);
                amount++;
                coordinates.Add(new KeyValuePair<int, int>(-11 + i, 4));
            }
        }

        for (int j = 16; j < 20; j++) {
            for (int i = 5; i < 21; i++) {
                if (!Physics2D.OverlapCircle(new Vector2(-11 + i, -11 + j), (float)0.2)) {
                    Instantiate(pellet, new Vector2(-11 + i, -11 + j), Quaternion.identity);
                    amount++;
                    coordinates.Add(new KeyValuePair<int, int>(-11 + i, -11 + j));
                }
            }
        }

        for (int j = 20; j < 31; j++) {
            for (int i = 0; i < 26; i++) {
                if (!Physics2D.OverlapCircle(new Vector2(-11 + i, -11 + j), (float)0.2)) {
                    if ((i == 0) && (j == 28)) {
                        Instantiate(bigPill, new Vector2(-11 + i, -11 + j), Quaternion.identity);
                        amount++;
                        coordinates.Add(new KeyValuePair<int, int>(-11 + i, -11 + j));
                    } else if ((i == 25) && (j == 28)) {
                        Instantiate(bigPill, new Vector2(-11 + i, -11 + j), Quaternion.identity);
                        amount++;
                        coordinates.Add(new KeyValuePair<int, int>(-11 + i, -11 + j));
                    } else {
                        Instantiate(pellet, new Vector2(-11 + i, -11 + j), Quaternion.identity);
                        amount++;
                        coordinates.Add(new KeyValuePair<int, int>(-11 + i, -11 + j));
                    }
                }
            }
        }

    }

    void spawnNodes() {
        node = new GameObject("node");
        foreach (KeyValuePair<int, int> k in coordinates) {
            node.transform.SetPositionAndRotation(new Vector2(k.Key, k.Value), Quaternion.identity);
            Instantiate(node, new Vector2(k.Key, k.Value), Quaternion.identity);
            xy[k.Key + 30, k.Value + 30] = 1;
            //Debug.Log(k.Key + "," + k.Value);
        }
    }

}
