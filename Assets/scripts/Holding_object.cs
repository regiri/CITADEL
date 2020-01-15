using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Holding_object : MonoBehaviour {
    private int trig;
    Database data;
    void Update() {
        trig = GameObject.Find("helper").GetComponent<mouse_follow>().flag;
        if (trig == 2 && Input.GetMouseButtonDown(1)) {
            data = GameObject.Find("MainCamera").GetComponent<Inventory>().data;
            GameObject.Find("MainCamera").GetComponent<Inventory>().AddItem(trig, data.items[trig], 1);
        }
    }
}
