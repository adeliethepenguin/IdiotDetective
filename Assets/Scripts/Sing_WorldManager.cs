using UnityEngine;

public class Sing_WorldManager : MonoBehaviour
{
    public static Sing_WorldManager Instance { get; private set; }

    public int currScene;

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
}
