using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Evidence : MonoBehaviour
{
    bool acquired;
    public Button clickMe;
    public int clueIndex;
    public Command command;

    public string myName;


    private void Start()
    {
        if (myName == null)
        {
            myName=transform.name;
        }
        
        if (command == null)
        {
            command=FindAnyObjectByType<Command>();
        }

        if (clickMe == null)
        {
            clickMe = GetComponent<Button>();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (acquired == true)
        {
            clickMe.interactable = false;
        }
    }

    public void SendClue()
    {
        Sing_WorldManager.Instance.UpdateClues(clueIndex, this.GetComponent<Evidence>());
        acquired = true;
    }
}
