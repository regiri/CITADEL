using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapCloseScript : MonoBehaviour
{
    public GameObject Map;

    public void CloseMap()
    {
        Map.GetComponent<CanvasGroup>().alpha = 0f;
        heromove.is_moving = true;
    }
}
