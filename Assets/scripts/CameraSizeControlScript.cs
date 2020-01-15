using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSizeControlScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        Camera.main.orthographicSize = 540;
    }
}
