using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timer = 0;
    public TMP_Text textoTimer;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        textoTimer.text = "" + timer.ToString("f2");
        
        if(timer < 0)
        {
            textoTimer.text = "Game Over";
        }
    }
}
