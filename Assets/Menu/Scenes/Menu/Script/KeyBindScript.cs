using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBindScript : MonoBehaviour
{
    private Dictionary<string, KeyCode> keys =  new Dictionary<string, KeyCode>();

    public Text up, left, down, right, frein, reset;

    private GameObject currentKey;

    // Start is called before the first frame update
    void Start()
    {
        keys.Add("Up",(KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up", "Z")));
        keys.Add("Down", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Down", "S")));
        keys.Add("Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "Q")));
        keys.Add("Right", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D")));
        keys.Add("Frein", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Frein", "Space")));
        keys.Add("Reset", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Reset", "R")));

        up.text = keys["Up"].ToString();
        down.text = keys["Down"].ToString();
        left.text = keys["Left"].ToString();
        right.text = keys["Right"].ToString();
        frein.text = keys["Frein"].ToString();
        reset.text = keys["Reset"].ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        if (currentKey != null)
        {
            Event e = Event.current;
            if (e.isKey && (!keys.ContainsValue(e.keyCode) || keys[currentKey.name] == e.keyCode))
            {
                keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                PlayerPrefs.SetString(currentKey.name, e.keyCode.ToString());
                PlayerPrefs.Save();
                currentKey = null;
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        currentKey = clicked;
    }

    public void SaveKeys()
    {
        foreach(var key in keys)
        {
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
        }

        PlayerPrefs.Save();
    }
}
