using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holding_object : MonoBehaviour {
    private bool holding = false;
    public GameObject hold_obj;
    private bool trig, collder;
    // Start is called before the first frame update
    /*void Start() {
        
    }*/
    
    // Update is called once per frame
    void Update() {
        trig = GameObject.Find("helper").GetComponent<mouse_follow>().flag;
        if (holding) {
            print("is holding");
            hold_obj.GetComponent<BoxCollider2D>().isTrigger = true;
            Vector3 mouse_pos = GameObject.Find("helper").GetComponent<mouse_follow>().mouse_position;
            hold_obj.transform.position = new Vector3(mouse_pos.x, mouse_pos.y);
        }
        if (!trig && Input.GetMouseButtonDown(0) && !holding) {
            holding = true;
        }
        else if (holding && Input.GetMouseButtonDown(0)) {
            print("stop!!!!");
            hold_obj.GetComponent<BoxCollider2D>().isTrigger = false;
            holding = false;
        }
    }
}
