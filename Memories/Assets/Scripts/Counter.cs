using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    public static Counter Instance;

    public TMP_Text counterText;
    public int currentObj = 0;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        counterText.text = "Objetos recolectadso: " + currentObj.ToString();
    }

    public void IncreaseObj(int v)
    {
        currentObj += v;
        counterText.text = "Objetos Recolectados: " + currentObj.ToString();
    }
}
