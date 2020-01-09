using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//персона диалога
public class DialogPerson
{
    public Sprite Face;
    public string Name;

    public DialogPerson(string name, string facePath)
    {
        Name = name;
        Face = Resources.Load<Sprite>(facePath); //ищем спрайт в папке Resources, нужно будет поменять 
    }
}

public class DialogPhrase
{
    public DialogPerson Speaker;
    public string Message;

    public DialogPhrase(DialogPerson person, string msg)
    {
        Speaker = person;
        Message = msg;
    }
}

public class Dialog
{
    public List<DialogPhrase> Phrases = new List<DialogPhrase>();       //лист наших фраз

    public void AddPhrase(DialogPhrase phrase)
    {
        Phrases.Add(phrase);
    }
}

public class dialogObj : MonoBehaviour
{
    void Start()
    {
        
    }
}
