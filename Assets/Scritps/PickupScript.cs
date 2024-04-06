using System.Collections.Generic;
using UnityEngine;

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

    private float pseudoPodOffset = 0f;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var collider in colliders)
        {
            GrabberColliders.Add(collider);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_validObjects.Count > 0)
        {
            //Show pickup button?
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_validObjects.Count > 0 && isHolding == false)
            {
                var obj = GetClosestObject(_validObjects, transform.position);
                PickupObject(obj);
            }
        }

        if (Input.GetKeyUp(KeyCode.E) && isHolding == true)
        {
            DropObject();
        }
    }

    void PickupObject(GameObject pickupObj)
    {
        pickupObj.GetComponent<Rigidbody>().isKinematic = true;
        pickupObj.GetComponent<Collider>().isTrigger = true;

        var closestGrabber = GetClosestObject(GrabberColliders, pickupObj.transform.position);

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
        heldObject.GetComponent<Collider>().isTrigger = false;
        heldObject.transform.parent = null;
        heldObject.GetComponent<Rigidbody>().isKinematic = false;
        heldObject = null;
        isHolding = false;
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
            _validObjects.Remove(other);
    }
}
