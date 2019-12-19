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
    public enum DialogType      //тип нашего диалога
    {                           //насколько я понял, 
        FIRST_DIALOG            //этор можно использовать для расширения функционала
    }                           

    public DialogType Type;
    public List<DialogPhrase> Phrases = new List<DialogPhrase>();       //лист наших фраз

    public Dialog(DialogType type)
    {
        Type = type;
    }

    public void AddPhrase(DialogPhrase phrase)
    {
        Phrases.Add(phrase);
    }
}

//публичный класс, чтобы не создавать лишних объектов
public static class DialogManager        //ВСЕ МЕТОДЫ ДОЛЖНЫ БЫТЬ ПУБЛИЧНЫМИ!!!!
{
    public static List<Dialog> Dialogs = new List<Dialog>();    //лист диалогов

    public static void AddDialog(Dialog dialog)
    {
        Dialogs.Add(dialog);
    }
}

public class dialogObj : MonoBehaviour
{
    void Start()
    {
        //тестирование
        //потом нужно будет это всё делать через XML-файлы
        DialogPerson player = new DialogPerson("Hero", "hero");
        DialogPerson npc = new DialogPerson("NPC", "npc");

        Dialog firstDialog = new Dialog(Dialog.DialogType.FIRST_DIALOG);

        firstDialog.AddPhrase(new DialogPhrase(player, "hello"));
        firstDialog.AddPhrase(new DialogPhrase(npc, "hi"));

        DialogManager.AddDialog(firstDialog);
    }
}
