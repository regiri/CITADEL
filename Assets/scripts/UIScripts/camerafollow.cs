using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour{
    public Transform player; //то, за чем объект будет следовать
    public GameObject follow_obj; // то, что будет следовать
    public Vector3 offset;//отступ, константа
    // Start is called before the first frame update
    void Start(){
        //отступ = позиция ведомого объекта - позиция ведущего
        offset = follow_obj.transform.position - player.position;
        //проверка значения отступа:
        //print(offset);

    }

    // Update is called once per frame
    void Update(){
        //изменение позиции ведомого объекта
        follow_obj.transform.position = player.position + offset;
    }
}
