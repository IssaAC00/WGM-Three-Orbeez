using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

[System.Serializable]
public class ObjetoRecolectable : MonoBehaviour
{
    public string nombre;
    [SerializeField, TextArea(4, 6)] public string[] dialogueDescripcion;
    public EstadoPersonaje estadoCambio;
}

