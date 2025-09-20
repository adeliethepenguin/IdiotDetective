using Unity.VisualScripting;
using UnityEngine;

public class PersonClue : Evidence
{
    [TextArea]
    public string dialoguebros;

    public void FuckEverythingUp()
    {
        Debug.Log("starting to fuck everything up");
        Sing_WorldManager.Instance.StartDialogue(dialoguebros, this);
        Debug.Log("fucked everything up");
    }

    


}
