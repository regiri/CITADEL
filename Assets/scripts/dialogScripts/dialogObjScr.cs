using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class dialogObjScr : MonoBehaviour
{
    //блоки с информацией о нашем диалоге
    public TMP_Text SpeakerName, SpeakerPhrase;//имя и фраза говорящего
    public Image SpeakerFace;//иконка и сам блок

    int MessageCooldown, //кулдаун между сообщениями
        CurrentMessageNum;

    Dialog CurrentDialog;

    public void StartDialog(Dialog dialog)
    {
        CurrentMessageNum = 0; //ищем все диалоги нужно нам типа
        CurrentDialog = dialog;

        transform.DOLocalMoveY(-465, 1);                                  //меняем положение блока по оси Y с анимацией
                                                                  
        ShowMessage();
    }

    void ShowMessage()
    {
        StopCoroutine("PrintMessage");  //останавливаем коррутину печатания сообщения, чтобы они не накладывались друг на друга

        DialogPhrase currentPhrase; 

        if (CurrentMessageNum < CurrentDialog.Phrases.Count)            //проверка на то, существует ли фраза
            currentPhrase = CurrentDialog.Phrases[CurrentMessageNum];
        else
        {
            EndDialog();
            return;
        }

        MessageCooldown = 3;

        SpeakerFace.sprite = currentPhrase.Speaker.Face;    //назначаем элементы говорящего
        SpeakerName.text = currentPhrase.Speaker.Name;

        SpeakerPhrase.text = "";

        StartCoroutine(PrintMessage(currentPhrase.Message)); //печатаем сообщение нашего персонажа

        CurrentMessageNum++;

    }

    //побуквенная печать нашего сообщения 
    IEnumerator PrintMessage(string message)
    {
        for (int i = 0; i < message.Length; i++)
        {
            SpeakerPhrase.text += message[i];

            if (i == message.Length - 1)
                StartCoroutine(NextMessage());

            yield return new WaitForSeconds(.0001f);  //задержкамежду буквами
        }
    }

    //задержка между сообщениями
    IEnumerator NextMessage()
    {
        while(MessageCooldown > 0)
        {
            MessageCooldown--;
            yield return new WaitForSeconds(1);
        }

        ShowMessage();
    }

    //окончание диалога
    void EndDialog()
    {
        FindObjectOfType<dialogAndQuest>().EndDialog();
        transform.DOLocalMoveY(-615, 1);         //смещаем блок диалога обратно
    }
}
