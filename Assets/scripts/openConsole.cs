using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openConsole : MonoBehaviour
{
    public GameObject canavs;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) {
            canavs.SetActive(!canavs.activeSelf);
        }
    }
}
