using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    public TextMeshProUGUI TestText;
    public float TimeToCompletion = 1f;
    public Dialogue dialogue;
    public GameObject ButtonPrefab;
    public GameObject ButtonParent;
    public List<TextMeshProUGUI> buttons;
    public bool InstantText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(test());
    }

    public void SelectDialoguePath(int Path)
    {
        Debug.Log(Path);
        dialogue = dialogue.OptionsObjects[Path] ?? dialogue;
        StartCoroutine(test());
    }

    IEnumerator test()
    {
        foreach (TextMeshProUGUI item in buttons)
        {
            Destroy(item.transform.parent.gameObject);
        }
        buttons.Clear();
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
        for(int i = 0; i < dialogue.Responses.Length; i++)
        {
            Debug.Log("create");
            buttons.Add(Instantiate(ButtonPrefab, ButtonParent.transform).GetComponentInChildren<TextMeshProUGUI>());
            buttons[i].text = dialogue.Responses[i];
            //buttons[i].GetComponentInParent<Button>().onClick.AddListener(() => SelectDialoguePath(i));
        }
        foreach(TextMeshProUGUI item in buttons)
        {
            item.GetComponentInParent<Button>().onClick.AddListener(() => SelectDialoguePath(buttons.IndexOf(item)));
        }
    }
}
