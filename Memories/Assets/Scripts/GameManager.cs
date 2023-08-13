using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public TMP_Text textoEnding;
    public int objLimit = 6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameOver(string endingMesagge)
    {
        textoEnding.text = endingMesagge;
        gameOverUI.SetActive(true);
    }
}
