using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_follow : MonoBehaviour{
    public GameObject theFollowing;//объект, следующий за мышью, пустышка, временно с спрайтом, для отладки(красный кружочек)
    public Vector3 mouse_position;//координаты мыши
    private Camera cam;//камера
    public bool flag = true;//переменная, отвечающая за наличие пустышки в объекте
    private void OnTriggerEnter2D(Collider2D col) {//если пересекается коллизией с чем-то
        if (col.gameObject.tag == "canMove") {//если у этого чего-то тэг "onGrid"
            print("collision!");//вспомогательная вещь, не трожь
            flag = false;//пустышка в объекте => ставить сюда объект нельзя
        }
    }
    private void OnTriggerExit2D(Collider2D col) {//если пустышка не заходит коллизией
        print("exit");//не трогай свечу!
        flag = true;//пустышка не пересекает объект => ставить можно. ура!
    }
    // Start is called before the first frame update
    void Start() {
        cam = Camera.main;//камера - та что следует за персом
    }
    // Update is called once per frame
    void Update(){
        /*перевод глобальных координат мыши в локальные координаты камеры*/
        mouse_position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
        theFollowing.transform.position = mouse_position;//передвижение пустышки
    }
}
