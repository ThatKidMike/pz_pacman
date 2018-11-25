using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Teleport : MonoBehaviour {

    private GameObject red_ghost;
    private red_movement redScript;

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.name == "watman_1" && gameObject.name == "right_portal") {
            GameObject player_char = GameObject.Find("watman_1");
            GameObject left = GameObject.Find("left_portal");
            Vector2 v_left = new Vector2(left.transform.position.x + (float)1.25, left.transform.position.y);
            player_char.transform.SetPositionAndRotation(v_left, Quaternion.identity);
        } else if (collision.name == "watman_1" && gameObject.name == "left_portal") {
            GameObject player_char = GameObject.Find("watman_1");
            GameObject right = GameObject.Find("right_portal");
            Vector2 v_right = new Vector2(right.transform.position.x - (float)1.25, right.transform.position.y);
            player_char.transform.SetPositionAndRotation(v_right, Quaternion.Euler(0, 180, 0));
        }

    }
}
