using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class testscript : MonoBehaviour
{
    public TextMeshProUGUI TestText;
    public float TimeToCompletion = 5f;
    public string text = "this is a test text";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(test(text, TimeToCompletion / text.Length));
        }
    }

    IEnumerator test(string WriteText, float WriteSpeed)
    {
        foreach (char item in WriteText)
        {
            TestText.text += item;
            yield return new WaitForSeconds(WriteSpeed);
        }
    }
}
