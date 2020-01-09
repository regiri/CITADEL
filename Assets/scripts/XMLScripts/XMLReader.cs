using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using UnityEngine;

public class XMLReader : MonoBehaviour
{
    public questObjScr queScr;
    public dialogObjScr dialScr;

    public void StartQuestFromXml(string path)
    {
        string savedPath = Application.dataPath;

        savedPath += "/XML/Quests/" + path;
        
        XmlDocument savedDoc = new XmlDocument();
        savedDoc.Load(savedPath);
        string questName = savedDoc.GetElementsByTagName("questName")[0].InnerText;
        XmlNodeList questTasks = savedDoc.GetElementsByTagName("questTasks")[0].ChildNodes;

        Quest quest = new Quest(questName);

        for (int i = 0; i < questTasks.Count; i++)
        {
            string task = questTasks[i].InnerText;
            quest.AddTask(task);
        }

        queScr.StartQuest(quest);
    }

    public void StartDialogFromXml(string path)
    {
        string savedPath = Application.dataPath;

        savedPath += "/XML/Dialogs/" + path;

        XmlDocument savedDoc = new XmlDocument();
        savedDoc.Load(savedPath);
        XmlNodeList person = savedDoc.GetElementsByTagName("person");

        Dialog dialog = new Dialog();

        for (int i = 0; i < person.Count; i++)
        {
            string name = person[i].ChildNodes[0].InnerText;
            string face = person[i].ChildNodes[1].InnerText;
            string phrase = person[i].ChildNodes[2].InnerText;

            DialogPerson per = new DialogPerson(name, face);
            DialogPhrase phr = new DialogPhrase(per, phrase);

            dialog.AddPhrase(phr);
        }

        dialScr.StartDialog(dialog);
    }
}
