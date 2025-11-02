using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Receiver : MonoBehaviour
{
    public Stack<Evidence> evidenceList = new Stack<Evidence>();

    public void CollectEvidence(Evidence e)
    {
        evidenceList.Push(e);
    }
    public string NewestEvidence()
    {
        return evidenceList.Peek().transform.name;
    }
    public string AllEvidence()
    {
        string stuff;

        stuff = "";

        foreach (Evidence evidence in evidenceList)
        {
            stuff += evidence.transform.name+" ";
        }

        return stuff;
    }

}
