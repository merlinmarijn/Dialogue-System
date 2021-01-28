using UnityEngine;

[CreateAssetMenu(fileName = "1_Dialogue", menuName = "Dialogue System/Create Dialogue")]
public class Dialogue : ScriptableObject
{
    public string DialogueText;

    [SerializeField]
    public Dialogue[] OptionsObjects;
    [SerializeField]
    public string[] Responses;


    //old system
    //public string Option1;
    //public Dialogue Option1Object;
    //public string Option2;
    //public Dialogue Option2Object;
    //public string Option3;
    //public Dialogue Option3Object;
}
