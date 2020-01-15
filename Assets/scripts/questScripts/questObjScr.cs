using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class questObjScr : MonoBehaviour
{
    public static bool is_quest = false;
    public TMP_Text QuestName;
    public TMP_Text QuestTask1;
    public TMP_Text QuestTask2;
    public TMP_Text QuestTask3;
    public Image CompleteBlock;
    public AnimationCurve curve;

    private int currentTask = 1;
    private int questCount;

    public void StartQuest(Quest quest)
    {
        is_quest = true;
        QuestName.text = quest.Title;
        questCount = quest.Tasks.Count;
        switch (questCount)
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

        transform.DOLocalMoveX(665f, 1);
    }

    public void CompleteTask()
    {
        switch (currentTask)
        {
            case 1:
                QuestTask1.fontStyle = FontStyles.Strikethrough;
                QuestTask1.color = new Color(0, 255, 0);
                break;
            case 2:
                QuestTask2.fontStyle = FontStyles.Strikethrough;
                QuestTask2.color = new Color(0, 255, 0);
                break;
            case 3:
                QuestTask3.fontStyle = FontStyles.Strikethrough;
                QuestTask3.color = new Color(0, 255, 0);
                break;
        }

        if (questCount == currentTask)
            CompleteQuest();
    }

    public void CompleteQuest()
    {
        heroCounters.questCounter++;
        is_quest = false;

        StartCoroutine(ShowCompleteBlock());
        StartCoroutine(CloseQuestBlock());
    }

    IEnumerator ShowCompleteBlock()
    {
        CompleteBlock.GetComponent<CanvasGroup>().DOFade(1f, 1);

        yield return new WaitForSeconds(2f);

        CompleteBlock.GetComponent<CanvasGroup>().DOFade(0, 1);
    }

    IEnumerator CloseQuestBlock()
    {
        yield return new WaitForSeconds(1f);
        QuestName.text = "";
        QuestTask1.text = "";
        QuestTask2.text = "";
        QuestTask3.text = "";
        transform.DOLocalMoveX(1255f, 1);
    }
    
}
