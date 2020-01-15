using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogPlay : MonoBehaviour
{
    public dialogObjScr Dialog;
    public GameObject NpcMark;
    public string DialogPath;

    GameObject npcMark;
    private bool is_dialog = false;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && is_dialog)
        {
            StartDialog();
        }
    }

    //начинаем диалог, останавливаем персонажа
    public void StartDialog()
    {
        FindObjectOfType<XMLReader>().StartDialogFromXml(DialogPath);
        heromove.is_moving = false;
        Destroy(npcMark);
    }

    //заканчиваем диалог, даём персонажу двигаться
    public void EndDialog()
    {
        heromove.is_moving = true;
        is_dialog = false;
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
