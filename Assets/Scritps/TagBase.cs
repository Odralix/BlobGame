using UnityEngine;

public abstract class TagBase : TagBaseBase
{
    [SerializeField]
    protected bool isInteracting;

    protected bool isUnused = true;

    [SerializeField]
    protected float targetTime = 5;

    public abstract TagsEnum objectTag { get; }

    [SerializeField]
    public virtual string tagText { get { return ""; } }


    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (isUnused)
        {
            if (isInteracting)
            {
                ProgressTag();
            }
        }
    }

    public abstract void ProgressTag();

    public virtual void AquireTag()
    {
        playerCounter.AddTag(objectTag);
        isUnused = false;
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInteracting = true;
        }
    }

    protected void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInteracting = false;
        }
    }
}
