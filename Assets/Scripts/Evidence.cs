using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Evidence : MonoBehaviour
{
    bool acquired;
    public Button clickMe;
    public int clueIndex;

    private void Start()
    {
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
        Sing_WorldManager.Instance.UpdateClues(clueIndex);
        acquired = true;
    }
}
