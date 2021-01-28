using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    public TextMeshProUGUI TestText;
    public float TimeToCompletion = 1f;
    public Dialogue dialogue;
    public TextMeshProUGUI[] buttons;
    public bool InstantText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(test());
    }

    public void SelectDialoguePath(int Path)
    {
        switch (Path)
        {
            case 0:
                dialogue = dialogue.Option1Object ?? dialogue;
                break;
            case 1:
                dialogue = dialogue.Option2Object ?? dialogue;
                break;
            case 2:
                dialogue = dialogue.Option3Object ?? dialogue;
                break;
        }
        StartCoroutine(test());
    }

    IEnumerator test()
    {
        TestText.text = null;
        foreach(TextMeshProUGUI item in buttons)
        {
            item.text = null;
        }
        Debug.Log("test");
        if (!InstantText)
        {
            float WriteSpeed = TimeToCompletion / dialogue.DialogueText.Length;
            foreach (char item in dialogue.DialogueText)
            {
                TestText.text += item;
                yield return new WaitForSeconds(WriteSpeed);
            }
        }
        else
        {
            TestText.text = dialogue.DialogueText;
        }
        buttons[0].text = dialogue.Option1;
        buttons[1].text = dialogue.Option2;
        buttons[2].text = dialogue.Option3;
    }
}
