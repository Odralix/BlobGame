using UnityEngine;

public class PlayfulTag : MonoBehaviour
{
    bool isUnused = true;

    [SerializeField]
    bool isInteracting;

    [SerializeField]
    float targetTime = 10;

    [SerializeField]
    string testName = "NotYet";
    [SerializeField]
    int tagCount = 0;

    // Start is called before the first frame update
    void Start()
    {

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
        isUnused = false;
        tagCount++;
        testName = "Playful";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInteracting = true;
        }
    }

    //private void OnCollisionExit(Collision other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        isInteracting = false;
    //    }
    //}

    //void OnCollisionEnter(Collision other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        isInteracting = true;
    //    }
    //}

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInteracting = false;
        }
    }
}
