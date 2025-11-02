using UnityEngine;

public class Command : MonoBehaviour
{
    public Receiver receiver;
    
    public void NewClue(Evidence e) 
    {
        receiver.CollectEvidence(e);
    }


}
