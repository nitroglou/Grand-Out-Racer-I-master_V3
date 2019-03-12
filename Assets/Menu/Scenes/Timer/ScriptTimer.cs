using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptTimer : MonoBehaviour
{
    public float time;

    private void Awake()
    {
        time = (int)Time.time;
    }

    void Update()
    {
        time = (int)Time.time;
        GetComponent<Text>().text = string.Format("{0:0}:{1:00}.{2:00}",Mathf.Floor(time/60),time%60,(Math.Round(Time.time, 2) - time) * 100);
    }
}
