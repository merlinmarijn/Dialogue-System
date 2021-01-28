using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue System/Create Dialogue")]
public class Dialogue : ScriptableObject
{
    public string DialogueText;

    public string Option1;
    public Dialogue Option1Object;
    public string Option2;
    public Dialogue Option2Object;
    public string Option3;
    public Dialogue Option3Object;
}
