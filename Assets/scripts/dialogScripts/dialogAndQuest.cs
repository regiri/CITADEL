using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.IO;

//скрипт ставим на нпс
public class dialogAndQuest : MonoBehaviour
{
    public dialogObjScr Dialog;
    public GameObject NpcMark;
    public string QuestPath;
    public string DialogPath;
    public int MaxQuestCount;
    public int MinQuestCount;

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
        FindObjectOfType<XMLReader>().StartDialogFromXml(DialogPath);
        heromove.is_moving = false;
        Destroy(npcMark);
    }

    //заканчиваем диалог, даём персонажу двигаться
    public void EndDialog()
    {
        heromove.is_moving = true;
        is_dialog = false;

        FindObjectOfType<XMLReader>().StartQuestFromXml(QuestPath);
    }

    //начинаем диалог, когда персонаж попадает в триггер
    // нужно будет сделать, чтобы диалог начинался ещё после нажатия определенной кнопки
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !questObjScr.is_quest && heroCounters.questCounter >= MinQuestCount && heroCounters.questCounter <= MaxQuestCount)
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
