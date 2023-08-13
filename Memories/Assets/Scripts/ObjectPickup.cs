using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectPickup : MonoBehaviour
{
    public ObjetoRecolectable objetoInfo; //obtiene los datos especificos del objeto que se esta recogiendo
   
    //DIALOGO
    private bool isPlayerInRange; //el objeto esta en el rango de pick up del jugador
    [SerializeField] private GameObject dialoguePanel; //panel de dialogo
    [SerializeField] private TMP_Text dialogueText; //texto del dialogo del objeto

    private bool didDialogueStart; //empezo el dialogo?
    private int lineIndex; //por que linea del dialogo voy

    private float typingTime = 0.05f; //cuanto tarda el dialogo en correr


    //CONTADOR
    public TMP_Text counterText; //texto del contador
    public Inventario inventario;

    private void Awake()
    {
        
        counterText.text = "Objetos recolectados: " + inventario.cantObj.ToString();
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(isPlayerInRange && Input.GetButtonDown("Fire1") && !didDialogueStart)
        {
            StartDialogue();
            //IncreaseObj(1);

        } else if(dialogueText.text == objetoInfo.dialogueDescripcion[lineIndex] && Input.GetButtonDown("Fire1"))
        {
            NextDialogueLine();
            Debug.Log(inventario.cantObj + "POST DIALOGUE LINE");
        } else if(Input.GetKeyDown(KeyCode.F)) //saltarse la animacion de que las letras aparezcan en pantallla
        {
            StopAllCoroutines();
            dialogueText.text = objetoInfo.dialogueDescripcion[lineIndex];
        }      
    }

    private void StartDialogue()
    {
        Debug.Log(inventario.cantObj + "startdialogue");
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        lineIndex = 0;
        Time.timeScale = 0;
        StartCoroutine(ShowLine());
      
    }

    private void NextDialogueLine()
    {
        Debug.Log(inventario.cantObj + "nextdialogue");
        lineIndex++; ;
        if(lineIndex < objetoInfo.dialogueDescripcion.Length)
        {
            StartCoroutine(ShowLine()); 
        }
        else
        {
            didDialogueStart=false;
            dialoguePanel.SetActive(false);
            Time.timeScale = 1;
            updateModel();
            IncreaseObj(1);
            Debug.Log(inventario.cantObj);
        }
    }

    private IEnumerator ShowLine()
    {
        Debug.Log(inventario.cantObj + "showline");
        dialogueText.text = string.Empty;
        foreach(char ch in objetoInfo.dialogueDescripcion[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Debug.Log("Recoger");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            Debug.Log("No Recoger");
        }
    }

    private void updateModel()
    {
        Debug.Log(inventario.cantObj + "update model");
        PlayerController control = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        if (control != null)
        {
            Debug.Log("Entra");
            control.CambiarEstado(objetoInfo.estadoCambio);
        }

        Destroy(gameObject);
        
    }

    public void IncreaseObj(int v)
    {

        Debug.Log(inventario.cantObj + "increase entrada");
        inventario.cantObj += v;
        counterText.text = "Objetoss Recolectados: " + inventario.cantObj.ToString();
        switch (objetoInfo.estadoCambio)
        {
            case EstadoPersonaje.Normal:
                //aumenta 1 en los buenos recuerdos
                inventario.cantNorm += 1;
                break;
            case EstadoPersonaje.Transformado:
                //aumenta 1 en los malos recuerdos
                inventario.cantTrans += 1;
                break;
        }
        Debug.Log(inventario.cantObj + "increase SALIDA");
    }
}
