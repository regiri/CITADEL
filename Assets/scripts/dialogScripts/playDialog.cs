using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//скрипт ставим на нпс
public class playDialog : MonoBehaviour
{
    public Dialog.DialogType DialogType;
    public dialogObjScr Dialog;

    //начинаем диалог, останавливаем персонажа
    public void StartDialog()
    {
        Dialog.StartDialog(DialogType);
        heromove.is_moving = false;
    }

    //заканчиваем диалог, даём персонажу двигаться
    public void EndDialog()
    {
        heromove.is_moving = true;
    }

    //начинаем диалог, когда персонаж попадает в триггер
    // нужно будет сделать, чтобы диалог начинался ещё после нажатия определенной кнопки
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "hero")
        {
            StartDialog();
        }
    }
}
