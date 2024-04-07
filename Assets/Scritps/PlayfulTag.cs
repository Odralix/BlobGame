using UnityEngine;

public class PlayfulTag : TagBase
{
    string _tagText = "Playing";
    public override string tagText { get { return _tagText; } }

    public override TagsEnum objectTag { get { return TagsEnum.Playful; } }

    public override void ProgressTag()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            AquireTag();
            _tagText = "All played out";
        }
    }

    //bool isUnused = true;

    //[SerializeField]
    //bool isInteracting;

    //[SerializeField]
    //float targetTime = 10;

    //[SerializeField]
    //PlayerTagsAndCount playerCounter;

    //TagsEnum playerTag = TagsEnum.Playful;

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (isUnused)
    //    {
    //        if (isInteracting)
    //        {
    //            targetTime -= Time.deltaTime;

    //            if (targetTime <= 0.0f)
    //            {
    //                AquireTag();
    //            }
    //        }
    //    }
    //}

    //void AquireTag()
    //{
    //    isUnused = false;
    //    playerCounter.AddTag(playerTag);
    //}

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        isInteracting = true;
    //    }
    //}

    ////private void OnCollisionExit(Collision other)
    ////{
    ////    if (other.gameObject.tag == "Player")
    ////    {
    ////        isInteracting = false;
    ////    }
    ////}

    ////void OnCollisionEnter(Collision other)
    ////{
    ////    if (other.gameObject.tag == "Player")
    ////    {
    ////        isInteracting = true;
    ////    }
    ////}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        isInteracting = false;
    //    }
    //}
}
