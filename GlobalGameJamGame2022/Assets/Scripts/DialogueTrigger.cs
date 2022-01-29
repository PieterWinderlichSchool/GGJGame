using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private bool inFrontOfNPC;

    public void Start()
    {
        inFrontOfNPC = false;
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void Update()
    {
        if (inFrontOfNPC == true)
        {
            if (Input.GetKeyDown(KeyCode.T))
            { TriggerDialogue(); }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inFrontOfNPC = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inFrontOfNPC = false;
        }
    }
}
