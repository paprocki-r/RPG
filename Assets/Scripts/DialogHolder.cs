using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogHolder : MonoBehaviour
{
	public string dialogue;
	private DialogueManager dMAn;

	public string[] dialogueLines;

    // Start is called before the first frame update
    void Start()
    {
        dMAn = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
    	// Debug.Log("In dialogueZone: "+other.gameObject.name);
    	if(other.gameObject.name=="Player")
    	{

    		if(Input.GetKeyUp(KeyCode.Z))
    		{

    			// dMAn.ShowBox(dialogue);
    			if(!dMAn.dialogActive)
    			{
    				dMAn.dialogLines = dialogueLines;
    				dMAn.currentLine = 0;
    				dMAn.ShowDialogue();
    			}

    			if(transform.parent.GetComponent<VillagerMovement>() != null)
    			{
    				transform.parent.GetComponent<VillagerMovement>().canMove = false;
    			}
    		}
    	}
    }
}
