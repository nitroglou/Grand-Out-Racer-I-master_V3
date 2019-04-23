using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    private int acc;

    // Start is called before the first frame update
    void Start()
    {
        acc = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        acc += 1;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(acc);
    }
}
