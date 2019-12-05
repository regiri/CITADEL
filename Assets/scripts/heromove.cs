using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//подарки на Новый Год не получит никто
public class heromove : MonoBehaviour{
    public float speed = 10f;//скорость передвижения, можно менять прямо в самой юнити
    bool facing_right = true;//куда по факту смотрим
    Rigidbody2D rig;//Rigidbody нашего героя
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start() {
        rig = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update() {
        float move_h, move_v;
        move_h = Input.GetAxis("Horizontal"); //скорость по горизонтальной оси
        move_v = Input.GetAxis("Vertical"); //скорость по вертикальной оси
        rig.velocity = new Vector2(move_h * speed, move_v * speed); //задаём Rigidbody скорость вектором по осям OX и OY
        if (move_h > 0 && !facing_right)
            flip();//если спрайт смотрит влево, а мы идём вправо
        if (move_h < 0 && facing_right)
            flip();//наоборот
    }
    //функция, меняющая направление взгляда
    void flip() {
        facing_right = !facing_right; //измениние направления по факту
        Vector2 scale = this.transform.localScale;
        scale.x *= -1;//изменение направления взгляда спрайта
        this.transform.localScale = scale;
    }
}
