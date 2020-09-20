using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
	public QuestObject[] quests;
	public bool[] questsCompleted;
	public DialogueManager theDM;
	public string itemCollected;
	public string enemyKilled;

    // Start is called before the first frame update
    void Start()
    {	
    	// theDM = Find
        questsCompleted = new bool[quests.Length];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowQuestText(string questText)
    {
    	theDM.dialogLines = new string[1];
    	theDM.dialogLines[0] = questText;

    	theDM.currentLine = 0;
    	theDM.ShowDialogue();
    }
}
