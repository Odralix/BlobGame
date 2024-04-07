using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PickupScript : MonoBehaviour
{

    private HashSet<Collider> _validObjects = new HashSet<Collider>();
    private string pickupTag = "PickupAble";

    [SerializeField]
    private HashSet<Collider> GrabberColliders = new HashSet<Collider>();

    [SerializeField]
    private bool isHolding = false;

    [SerializeField]
    Collider grabRangeCollider;

    [SerializeField]
    List<Collider> colliders = new List<Collider>();

    GameObject heldObject = null;

    [SerializeField]
    private Material OutlineMaterial;

    [SerializeField]
    UIDocument uiHover;

    private Label infoText;
    bool textClearable = true;

    //private float pseudoPodOffset = 0f;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var collider in colliders)
        {
            GrabberColliders.Add(collider);
        }
        infoText = (Label)uiHover.rootVisualElement.Q("Info");
        //uiHover.visualTreeAsset.stylesheets;
    }

    // Update is called once per frame
    void Update()
    {
        if (_validObjects.Count > 0 && infoText.text == "")
        {
            infoText.text = "E to Pickup";
            //Show pickup button?
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_validObjects.Count > 0 && isHolding == false)
            {
                var obj = GetClosestObject(_validObjects, transform.position);
                PickupObject(obj);
            }
            else if (isHolding)
            {
                DropObject();
            }
        }

        //if (Input.GetKeyUp(KeyCode.E) && isHolding == true)
        //{
        //    DropObject();
        //}
    }

    void PickupObject(GameObject pickupObj)
    {
        pickupObj.GetComponent<Rigidbody>().isKinematic = true;
        pickupObj.GetComponent<Collider>().isTrigger = true;

        Material[] newMatsArr = new Material[2];
        var renderer = pickupObj.GetComponent<Renderer>();
        var mats = renderer.materials;
        newMatsArr[0] = mats[0];
        newMatsArr[1] = OutlineMaterial;
        renderer.materials = newMatsArr;

        var closestGrabber = GetClosestObject(GrabberColliders, pickupObj.transform.position);

        var tagScript = pickupObj.GetComponent<TagBase>();

        textClearable = false;
        infoText.text = tagScript.tagText;
        infoText.style.color = TagCollection.TagDict[tagScript.objectTag];
        //var yPos = closestGrabber.transform.position.y
        //closestGrabber.transform.position = (closestGrabber.transform.position - pickupObj.transform.position) * 0.05f;

        //transform.position = start + Difference * percent;

        //closestGrabber.transform.position *= (pickupObj.transform.position

        //pseudoPodOffset = (closestGrabber.transform.position - pickupObj.transform.position) * 0.05f;

        pickupObj.transform.position = closestGrabber.transform.position;
        pickupObj.transform.parent = closestGrabber.transform;
        heldObject = pickupObj;
        isHolding = true;
    }

    void DropObject()
    {
        Material[] newMatsArr = new Material[1];
        var renderer = heldObject.GetComponent<Renderer>();
        var mats = renderer.materials;
        newMatsArr[0] = mats[0];
        renderer.materials = newMatsArr;

        heldObject.GetComponent<Collider>().isTrigger = false;
        heldObject.transform.parent = null;
        heldObject.GetComponent<Rigidbody>().isKinematic = false;
        heldObject = null;
        isHolding = false;
        textClearable = true;
    }

    GameObject GetClosestObject(HashSet<Collider> set, Vector3 fromPosition)
    {
        float closestDistance = Mathf.Infinity;
        GameObject closestObject = null;

        foreach (Collider c in set)
        {
            float magnitudeDistance = (c.transform.position - fromPosition).sqrMagnitude;
            if (magnitudeDistance < closestDistance)
            {
                closestDistance = magnitudeDistance;
                closestObject = c.gameObject;
            }
        }

        return closestObject;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(pickupTag))
            _validObjects.Add(other);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(pickupTag))
        {
            _validObjects.Remove(other);
            if (_validObjects.Count <= 0 && textClearable)
            {
                infoText.text = "";
                //var testTree = uiHover.visualTreeAsset;

                //infoText.Clear();
            }

        }
    }
}
