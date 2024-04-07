using UnityEngine;

public class TagAquirer : MonoBehaviour
{
    bool isUnused = true;

    [SerializeField]
    bool isInteracting;

    [SerializeField]
    float targetTime = 10;

    TagsEnum tagType;

    PlayerTagsAndCount playerTags;

    // Start is called before the first frame update
    void Start()
    {
        playerTags = transform.GetComponent<PlayerTagsAndCount>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isUnused)
        {
            if (isInteracting)
            {
                targetTime -= Time.deltaTime;

                if (targetTime <= 0.0f)
                {
                    AquireTag();
                }
            }
        }
    }

    void AquireTag()
    {
        playerTags.AddTag(tagType);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickupAble")
        {
            var objectTag = other.transform.GetComponent<ObjectTagScript>();
            if (objectTag.hasBeenUsed == false)
            {
                isInteracting = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PickupAble")
        {
            var objectTag = other.transform.GetComponent<ObjectTagScript>();
            if (objectTag.hasBeenUsed == false)
            {
                isInteracting = false;
            }
        }
    }
}
