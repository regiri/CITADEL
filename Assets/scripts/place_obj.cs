using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class place_obj : MonoBehaviour{
    // Start is called before the first frame update
    public GameObject placing_obj;//объект, который будем ставить
    private Vector3 mouse_pos;//позиция мыши
    private Camera cam;//камера
    void Start(){
        cam = Camera.main;//настройка объекта камеры на основную, следящую за персом
    }
    // Update is called once per frame
    void Update(){
        bool trig = GameObject.Find("helper").GetComponent<mouse_follow>().flag;
        /*получаем из объекта "helper" переменную flag
        отвечающую за наличтие мыши на объекте*/
        if (Input.GetMouseButtonDown(0) && trig) {//если не на объекте и ЛКМ нажата
            mouse_pos = GameObject.Find("helper").GetComponent<mouse_follow>().mouse_position;
            /*с helper берём переменную отвечающую за позицию мыши*/
            Instantiate(placing_obj, mouse_pos, Quaternion.identity);
            //создаём на взятых координатах нужный объект
        }
    }
}
