using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestroy : MonoBehaviour{
    public GameObject obj;//удаляемый объект
    private void Update() {
        bool trig = GameObject.Find("helper").GetComponent<mouse_follow>().flag;
        /*берём с объекта helper переменную,
         отвечающую за наличие мыши в координатах объектах*/
        if (!trig && Input.GetMouseButtonDown(1)) {//если нажата ПКМ и на объекте
            Destroy(obj);//уничтожить!
        }
    }
}
