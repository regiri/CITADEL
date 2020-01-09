using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mapOpenScript : MonoBehaviour
{
    public Image Map;

    public void OpenMap()
    {
        Map.GetComponent<CanvasGroup>().alpha = 1f;
        heromove.is_moving = false;
    } 

}
