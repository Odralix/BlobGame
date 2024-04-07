using UnityEngine;

public class TagBaseBase : MonoBehaviour
{
    protected PlayerTagsAndCount playerCounter;

    protected void Start()
    {
        playerCounter = GameObject.Find("SlimeLatest").GetComponent<PlayerTagsAndCount>();
    }
}
