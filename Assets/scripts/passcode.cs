using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class passcode : MonoBehaviour
{
    public List<KeyCode> input;
    public List<KeyCode> passward;
    public Fungus.Flowchart story_flowchart;
    public InputField inputfieldname;
    public Text intputText;
    // Start is called before the first frame update
    void Start()
    {
        passward = new List<KeyCode>() { KeyCode.L, KeyCode.I, KeyCode.L, KeyCode.L, KeyCode.Y };
    }
    void OnGUI()
    {
        
        if (Event.current.keyCode != KeyCode.None && Event.current.keyCode != KeyCode.Return && Event.current.keyCode != KeyCode.Backspace)
        {
            if (Event.current.isKey) {
                story_flowchart.SetBooleanVariable("start", true);
                Debug.Log("hhh");
            }
            if (Event.current.isKey && Event.current.type == EventType.KeyDown)
            {
                input.Add(Event.current.keyCode);
                intputText.text += Event.current.keyCode.ToString();

            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(intputText.text.Length);
        //Debug.Log(input.Count);
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (KeycodeEquals(passward, input))
            {
                story_flowchart.SetBooleanVariable("correct", true);
                print("correct");
            }
            else
            {
                input.Clear();
                inputfieldname.Select();
                inputfieldname.text = "";
                
            }
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (input.Count > 0)
                input.Remove(input[input.Count-1]);
            //Debug.Log("delete");
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(this.gameObject);
        }

    }
    static bool KeycodeEquals(List<KeyCode> a, List<KeyCode> b)
    {
        if (a == null) return b == null;
        if (b == null || a.Count != b.Count) return false;
        for (int i = 0; i < a.Count; i++)
        {
            if (a[i] != b[i])
            {
                return false;
            }
        }
        return true;
    }
}
