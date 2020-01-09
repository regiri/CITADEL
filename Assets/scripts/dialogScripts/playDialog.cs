using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//скрипт ставим на нпс
public class playDialog : MonoBehaviour
{
    public dialogObjScr Dialog;
    public GameObject NpcMark;
    GameObject npcMark;
    private bool is_dialog = false;

    public void Update()
    {
        if (Input.GetKeyDown( KeyCode.E ) && is_dialog)
        {
            StartDialog();
        }
    }

    //начинаем диалог, останавливаем персонажа
    public void StartDialog()
    {
        FindObjectOfType<XMLReader>().StartDialogFromXml("dialogProto.xml");
        heromove.is_moving = false;
    }

    //заканчиваем диалог, даём персонажу двигаться
    public void EndDialog()
    {
        heromove.is_moving = true;
        Destroy(npcMark);
        is_dialog = false;

        FindObjectOfType<XMLReader>().StartQuestFromXml("questProto.xml");
    }

    //начинаем диалог, когда персонаж попадает в триггер
    // нужно будет сделать, чтобы диалог начинался ещё после нажатия определенной кнопки
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            npcMark = Instantiate(NpcMark);
            npcMark.transform.position = transform.position;
            npcMark.transform.position += new Vector3(0, 1.25f, 0);
            is_dialog = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(npcMark);
    }
}
