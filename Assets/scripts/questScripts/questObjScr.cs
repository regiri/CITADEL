using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class questObjScr : MonoBehaviour
{

    public TMP_Text QuestName;
    public TMP_Text QuestTask1;
    public TMP_Text QuestTask2;
    public TMP_Text QuestTask3;
    private int currentQuestIndex = 0;

    public void StartQuest(Quest quest)
    {
        QuestName.text = quest.Title;
        int length = quest.Tasks.Count;
        switch (length)
        {
            case 3:
                QuestTask3.text = "- " + quest.Tasks[2];
                QuestTask2.text = "- " + quest.Tasks[1];
                QuestTask1.text = "- " + quest.Tasks[0];
                break;
            case 2:
                QuestTask3.text = "";
                QuestTask2.text = "- " + quest.Tasks[1];
                QuestTask1.text = "- " + quest.Tasks[0];
                break;
            case 1:
                QuestTask3.text = "";
                QuestTask2.text = "";
                QuestTask1.text = "- " + quest.Tasks[0];
                break;
        }

        transform.DOLocalMoveX(671.25f, 1);
    }

    public void CompleteQuest()
    {
        currentQuestIndex++;
        QuestName.text = "";
        QuestTask1.text = "";
        QuestTask2.text = "";
        QuestTask3.text = "";
    }
}
