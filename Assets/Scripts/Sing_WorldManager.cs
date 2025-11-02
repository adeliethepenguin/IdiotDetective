using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using NUnit.Framework;
using System.Collections.Generic;

public class Sing_WorldManager : MonoBehaviour
{
    public static Sing_WorldManager Instance { get; private set; }

    public bool dialogueing;

    public int currScene = 5;
    public GameObject[] scenes;
    public GameObject sceneButtons;

    public List<GameObject> livingButtons = new List<GameObject>();

    //Dialogue stuff

    public string currSceneDialogue;
    public GameObject buttonHolder;
    string[] currSceneLines;
    int currentLine = 0;
    public GameObject dialogueBox;
    public TMP_Text dialogueText;
    public PersonClue currentPerson;

    public string[] clues;
    public bool[] cluechecks;
    public TMP_Text clueText;


    public TMP_Text evidenceText;

    public Command command;
    public Receiver receiver;

    private void Awake()
    {
        
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        dialogueing = false;

    }
    private void Update()
    {
        if (dialogueing)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                AdvanceDialogue();
            }
        }
    }

    public void SceneChange(int newScene)
    {
        scenes[currScene].SetActive(false);
        scenes[newScene].SetActive(true);
        currScene= newScene;
    }

    public void EndCase()
    {

        currScene = 3;
        scenes[0].SetActive(false);
        scenes[1].SetActive(false);
        scenes[2].SetActive(false);
        scenes[3].SetActive(true);
        sceneButtons.SetActive(false);
    }


    public void UpdateClues(int clueIndex, Evidence e)
    {
        command.NewClue(e); 
        cluechecks[clueIndex] = true;
        clueText.text = clueText.text + " and " + clues[clueIndex];
        Debug.Log("clue obtained: " + clues[clueIndex]);

        string evidence = receiver.AllEvidence();

        string[] evidences = evidence.Split(" ");

        evidenceText.text = evidenceText.text + " and " + receiver.NewestEvidence() ;
        Debug.Log("evidence obtained: " + clues[clueIndex]);


    }

    
    public void StartDialogue(string dialogueStuff, PersonClue person)
    {
        currentPerson = person;
        currSceneDialogue = dialogueStuff;

        if (currSceneDialogue != "")
        {
            for (int i = 0; i < buttonHolder.transform.childCount; i++)
            {
                Transform child = buttonHolder.transform.GetChild(i);
                if (child.GetComponent<Button>()&&child.GetComponent<Button>().interactable==true)
                {
                    livingButtons.Add(child.gameObject);
                    child.GetComponent<Button>().enabled=false;
                    Debug.Log("Button disabled: " + child.name);
                }
                for (int j = 0; j<child.transform.childCount; j++)
                {
                    Transform grandchild = child.transform.GetChild(j);
                    if (grandchild.GetComponent<Button>())
                    {
                        if (grandchild.GetComponent<Button>().interactable == true)
                        {
                            livingButtons.Add(grandchild.gameObject);
                            grandchild.GetComponent<Button>().enabled = false;
                            Debug.Log("Button disabled: " + grandchild.name);
                        }
                    }
                }
                
            }
            currSceneLines = currSceneDialogue.Split('\n');
            currentLine = 0;
            dialogueText.gameObject.SetActive(true);
            dialogueBox.SetActive(true);
            dialogueing = true;
            AdvanceDialogue();
        }
    }

    public void AdvanceDialogue()
    {
        if (currentLine < currSceneLines.Length)
        {
            string line = currSceneLines[currentLine].Trim();
            /*char mode = line[0];
            string content = line.Substring(1).TrimStart();
            switch (mode)
            {
                case '+':
                    dialogueText.color = prophetsLight;
                    speakingCharacter.SetInteger("character", 0);
                    break;

                case '-':
                    dialogueText.color = villainsWorld;
                    speakingCharacter.SetInteger("character", 1);
                    break;

                default:
                    Debug.LogWarning("AHHHHHHHHD DIALOGUE ERROR");
                    break;
            }
            dialogueText.text = content;*/
            dialogueText.text = line;
            currentLine++;
        }
        else
        {
            dialogueBox.SetActive(false);
            dialogueText.gameObject.SetActive(false);
            foreach (GameObject obj in livingButtons)
            {
                obj.GetComponent<Button>().enabled = true;
                
            }
            livingButtons.Clear();
            currentPerson.SendClue();
            currentPerson.GetComponent<Button>().interactable = false;
            dialogueing = false;

        }
    }
}
