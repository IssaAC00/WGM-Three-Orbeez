using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

[System.Serializable]
public class Inventario : MonoBehaviour
{
    public int cantObj = 0;
    public int cantNorm = 0;
    public int cantTrans = 0;

    public void IncreaseObj()
    {
        cantObj += 1;
    }

    public void IncreasenNorm()
    {
        cantNorm += 1;
    }

    public void IncreaseTrans()
    {
        cantTrans += 1;
    }
}