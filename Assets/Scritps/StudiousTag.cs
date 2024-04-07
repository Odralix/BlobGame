using UnityEngine;

public class StudiousTag : TagBase
{
    [SerializeField]
    GameObject objectToColideWith = null;

    [SerializeField]
    bool isStudying = false;

    public override TagsEnum objectTag { get { return TagsEnum.Studious; } }

    string _tagText = "studying";

    public override string tagText
    {
        get
        {
            if (isStudying)
            { return _tagText; }
            else
            {
                return $"Bring object to {objectToColideWith.name} to study.";
            }
        }
    }


    private void Start()
    {
        base.Start();
        if (objectToColideWith == null)
        {
            isStudying = true;
        }
    }

    public override void ProgressTag()
    {
        if (isStudying)
        {
            targetTime -= Time.deltaTime;

            if (targetTime <= 0.0f)
            {
                AquireTag();
                isUnused = false;
                _tagText = "Can only learn so much from one place";
            }
        }
    }

    protected void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (isInteracting)
        {
            if (other.gameObject == objectToColideWith && isStudying == false)
            {
                isStudying = true;
            }
        }
    }

    protected void OnTriggerExit(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.gameObject.tag == "Player")
        {
            isStudying = false;
        }

        if (other.gameObject == objectToColideWith && isStudying == true)
        {
            isStudying = false;
        }
    }

}
