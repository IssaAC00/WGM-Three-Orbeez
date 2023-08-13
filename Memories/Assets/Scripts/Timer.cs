using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timer = 0;
    public TMP_Text textoTimer;
    public Inventario inventario;
    public GameManager manager;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        textoTimer.text = "" + timer.ToString("f2");
        
        if(timer < 0 && inventario.cantObj < manager.objLimit)
        {

            textoTimer.text = "Game Over";
            if(inventario.cantNorm > inventario.cantTrans)
            {
                manager.gameOver("La verdad soy toda, y la queso");
            } 
            else if(inventario.cantTrans >= inventario.cantNorm)
            {
                manager.gameOver("Soy lo menos, que triste la vida");
    
            } 
        } else if(inventario.cantObj == manager.objLimit)
        {
            manager.gameOver("La vida da muchas vueltas, a ver que sigue");
        }
    }
}
