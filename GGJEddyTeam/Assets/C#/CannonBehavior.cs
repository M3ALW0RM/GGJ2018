using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehavior : MonoBehaviour {

    [SerializeField]
    GameObject Earth;

    [SerializeField]
    float PenetrationInEarth;

    [SerializeField]
    float RotateSpeed;

    [SerializeField]
    float RayLength;

    [SerializeField]
    float angleTolerance;

    LineRenderer lineRenderer;
    LineRenderer EarthLineRenderer;

    float targetAngle;
    float currentAngle = 0;

    // Use this for initialization
    void Start ()
    {
        lineRenderer = GetComponent<LineRenderer>();
        EarthLineRenderer = Earth.GetComponent<LineRenderer>();
        transform.position = Earth.transform.position + new Vector3(Earth.transform.localScale.x /2f - PenetrationInEarth + transform.localScale.x / 2f, 0, 0);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 mouseInWorld = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            mouseInWorld.z = Earth.transform.position.z;

            targetAngle = Mathf.Acos(Vector3.Dot(mouseInWorld - Earth.transform.position, new Vector3(1, 0, 0)) / ((mouseInWorld - Earth.transform.position).magnitude * new Vector3(1, 0, 0).magnitude)) * 180f / Mathf.PI;

            Vector3[] earthlinePoints = new Vector3[2];
            earthlinePoints[0] = Earth.transform.position;
            earthlinePoints[1] = (mouseInWorld - Earth.transform.position) * 50;
            EarthLineRenderer.SetPositions(earthlinePoints);
        }
        if (currentAngle < targetAngle - angleTolerance)
        {
            transform.RotateAround(Earth.transform.position, new Vector3(0, 0, 1), RotateSpeed * Time.deltaTime);
            currentAngle += RotateSpeed * Time.deltaTime;
        }
        else if(currentAngle > targetAngle + angleTolerance)
        {
            transform.RotateAround(Earth.transform.position, new Vector3(0, 0, 1), -RotateSpeed * Time.deltaTime);
            currentAngle -= RotateSpeed * Time.deltaTime;
        }
        Vector3[] points = new Vector3[2];
        points[0] = transform.position;
        points[1] = transform.position + (transform.position - Earth.transform.position).normalized * RayLength;
        lineRenderer.SetPositions(points);

    }
}
