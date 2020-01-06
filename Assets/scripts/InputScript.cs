using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputScript : MonoBehaviour
{
    InputField input;
    string codeQ = "name = 'Unknown'\nprint('hello, {0}', ****)";
    string codeA = "name = 'Unknown'\nprint('hello, {0}', name)";
    void Start()
    {
        input = GetComponent<InputField>();
        //выводим код вопроса
        input.text = codeQ;
    }

    void Update()
    {
        HandleUserInput();
    }

    void HandleUserInput()
    {
        if ( (Input.GetKey(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)) 
            && Input.GetKeyDown(KeyCode.D))
        {
            //считываем код игрока
            string ans = input.text;
            if (ans.Equals(codeA))
                print("OK");
            else
                print("WRONG");
        }
            
    }
}
