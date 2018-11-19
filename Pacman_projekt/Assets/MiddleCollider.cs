using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {

        this.gameObject.AddComponent<BoxCollider2D>();
        this.gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(-(float)2.72, (float)0.47);
        this.gameObject.GetComponent<BoxCollider2D>().size = new Vector2((float)0.3, (float)0.3);
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
