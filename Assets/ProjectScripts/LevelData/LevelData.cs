using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChecklistItems
{
    public string InteractionName;
    public bool InteractionActive;
}

[Serializable]
public class ChecklistData
{
    public string checklistName;
    public List<ChecklistItems> items;
}   