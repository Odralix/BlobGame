using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followPoint;

    public float smoothingFactor;

    public Vector3 positionOffset;

    public

    // Start is called before the first frame update
    void Start()
    {

    }


    private void LateUpdate()
    {
        Vector3 finalPos = followPoint.position + positionOffset;
        Vector3 smoothedOutPos = Vector3.Lerp(transform.position, finalPos, smoothingFactor);
        transform.position = smoothedOutPos;

        transform.LookAt(followPoint.position);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
