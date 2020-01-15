using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class Quest
{
    public string Title;
    public List<string> Tasks = new List<string>();

    public Quest(string title)
    {
        Title = title;
    }

    public void AddTask(string task)
    {
        Tasks.Add(task);
    }
}


public class questObj : MonoBehaviour
{ 
    
}
