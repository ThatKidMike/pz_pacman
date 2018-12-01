using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticStas : MonoBehaviour {

    private static int points;

    public static int Points {
        get {
            return points;
        }
        set {
            points = value;
        }
    }
}
