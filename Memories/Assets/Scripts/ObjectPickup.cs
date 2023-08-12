using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectPickup : MonoBehaviour
{
    public ObjetoRecolectable objetoInfo;
    private bool isPlayerInRange;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;

    private bool didDialogueStart;
    private int lineIndex;

    private float typingTime = 0.1f;
 

    // Update is called once per frame
    private void Update()
    {
        if(isPlayerInRange && Input.GetButtonDown("Fire1") && !didDialogueStart)
        {
            StartDialogue();

        } else if(dialogueText.text == objetoInfo.dialogueDescripcion[lineIndex] && Input.GetButtonDown("Fire1"))
        {
            NextDialogueLine();
            //pausarlo
        }       
    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        lineIndex = 0;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine()
    {
        lineIndex++; ;
        if(lineIndex < objetoInfo.dialogueDescripcion.Length)
        {
            StartCoroutine(ShowLine()); 
        }
        else
        {
            didDialogueStart=false;
            dialoguePanel.SetActive(false);
            updateModel();
        }
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;
        foreach(char ch in objetoInfo.dialogueDescripcion[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSeconds(typingTime);
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
        PlayerController control = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        if (control != null)
        {
            Debug.Log("Entra");
            control.CambiarEstado(objetoInfo.estadoCambio);
        } 
        Destroy(gameObject);
        
    }
}
