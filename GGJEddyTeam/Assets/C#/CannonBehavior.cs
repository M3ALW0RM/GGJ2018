using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehavior : MonoBehaviour {

    [SerializeField]
    GameObject Earth;

    [SerializeField]
    float DistanceFromCore;

    [SerializeField]
    float RotateSpeed;

    [SerializeField]
    float RayLength;

    LineRenderer lineRenderer;

    float targetAngle;

    // Use this for initialization
    void Start ()
    {
        lineRenderer = GetComponent<LineRenderer>();
        transform.position = Earth.transform.position + new Vector3(Earth.transform.localScale.x /2f + transform.localScale.x / 2f, 0, 0);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetMouseButton(1))
        {
            Debug.DrawLine(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane)), Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane)) + new Vector3(0, 0, 1));

            Vector3 mouseInWorld = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            mouseInWorld.z = Earth.transform.position.z;

            targetAngle = Vector3.SignedAngle(Earth.transform.position + new Vector3(1,0,0), Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane)), new Vector3(0,1));
            Debug.Log("Target Angle " + targetAngle);
            Debug.Log("Point " + Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.RotateAround(Earth.transform.position, new Vector3(0, 0, 1), RotateSpeed * Time.deltaTime);
        }
        else if(Input.GetAxis("Horizontal") < 0)
        {
            transform.RotateAround(Earth.transform.position, new Vector3(0, 0, 1), -RotateSpeed * Time.deltaTime);
        }
        Vector3[] points = new Vector3[2];
        points[0] = transform.position;
        points[1] = transform.position + (transform.position - Earth.transform.position).normalized * RayLength;
        lineRenderer.SetPositions(points);

    }
}
