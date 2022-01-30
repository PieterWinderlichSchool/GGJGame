using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CheckWinCondition : MonoBehaviour
{

	public ModeSwitch modeSwitcher;
	public int coins;
	public int deadEnemies = 0;
	public bool HellVictory = false;
	public bool HeavenVictory = false;

	[SerializeField] private DialogueManager dialogue;
	public Dialogue dialogue1;
	public Dialogue dialogue2;

	public List<DialogueTrigger> triggers = new List<DialogueTrigger>();


	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		int index = 0;
		if (coins >= 19)
		{
			HellVictory = true;
		}
		else if (deadEnemies >= 20)
		{
			HeavenVictory = true;
		}
		foreach (GameObject Enemies in modeSwitcher.getHeavenEnemies())
		{


			if (Enemies == null)
			{
				index++;
				deadEnemies = index;
			}
		}

		if (HeavenVictory || HellVictory)
		{
			for (int i = 0; i < triggers.Count; i++)
			{
				triggers[i].enabled = false;
			}

		}


	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.CompareTag("PlayerCollider"))
		{
			if (Input.GetKeyDown(KeyCode.T))
			{

				if (CheckHellVictory())
				{
					dialogue.StartDialogue(dialogue1);
					Invoke("LoadCredits", 7.5f);
					Debug.Log(dialogue1);
				}
				if (CheckHeavenVictory())
				{
					dialogue.StartDialogue(dialogue2);
					Invoke("LoadCredits", 7.5f);
					Debug.Log(dialogue2);
				}
			}
		}
	}
	public bool CheckHellVictory()
	{
		if (HellVictory)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public bool CheckHeavenVictory()
	{
		if (HeavenVictory)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public void LoadCredits()
	{
		SceneManager.LoadScene(2);
	}
}