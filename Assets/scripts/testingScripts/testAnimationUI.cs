using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class testAnimationUI : MonoBehaviour
{
    public Image CompleteBlock;
    public TMP_Text CompleteMessage;
    public AnimationCurve curve;

    public void TestCompleteQuest()
    {
        FindObjectOfType<questObjScr>().CompleteTask();
    }
}
