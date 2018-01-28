using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonBehavior : MonoBehaviour {

    [SerializeField]
    GameObject Earth;

    [SerializeField]
    float PenetrationInEarth;

    [SerializeField]
    float RotateSpeed;

    [SerializeField]
    float smoothingParameter;

    [SerializeField]
    float RayLength;

    [SerializeField]
    float angleTolerance;

    [SerializeField]
    GameObject panel;
    [SerializeField]
    Canvas UICanvas;

    LineRenderer lineRenderer;
    LineRenderer EarthLineRenderer;

    float targetAngle;
    float currentAngle = 0;
    float minMouseX;

    // Use this for initialization
    void Start ()
    {
        minMouseX = panel.GetComponent<RectTransform>().rect.width * UICanvas.scaleFactor;
        lineRenderer = GetComponent<LineRenderer>();
        EarthLineRenderer = Earth.GetComponent<LineRenderer>();
        transform.position = Earth.transform.position + new Vector3(Earth.transform.localScale.x /2f - PenetrationInEarth + transform.localScale.x / 2f, 0, 0);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButton(0) && Input.mousePosition.x > minMouseX)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Earth.transform.position.z - Camera.main.transform.position.z;
            Vector3 mouseInWorld = Camera.main.ScreenToWorldPoint(mousePos);
            Debug.DrawLine(mouseInWorld, mouseInWorld + new Vector3(0, 0, 1));

            targetAngle = Mathf.Acos(Vector3.Dot(mouseInWorld - Earth.transform.position, new Vector3(1, 0, 0)) / ((mouseInWorld - Earth.transform.position).magnitude * new Vector3(1, 0, 0).magnitude)) * 180f / Mathf.PI;

            Vector3[] earthlinePoints = new Vector3[2];
            earthlinePoints[0] = Earth.transform.position;
            earthlinePoints[1] = (mouseInWorld - Earth.transform.position) * 50;
            EarthLineRenderer.SetPositions(earthlinePoints);
        }
        if (currentAngle < targetAngle - angleTolerance)
        {
            transform.RotateAround(Earth.transform.position, new Vector3(0, 0, 1), RotateSpeed * (1-currentAngle/targetAngle) * Time.deltaTime);
            currentAngle += RotateSpeed *(1 - currentAngle / targetAngle) * Time.deltaTime;
        }
        else if(currentAngle > targetAngle + angleTolerance)
        {
            transform.RotateAround(Earth.transform.position, new Vector3(0, 0, 1), -RotateSpeed * (1 - targetAngle/currentAngle) * Time.deltaTime);
            currentAngle -= RotateSpeed * (1 - targetAngle / currentAngle) * Time.deltaTime;
        }
        Vector3[] points = new Vector3[2];
        points[0] = transform.position;
        points[1] = transform.position + (transform.position - Earth.transform.position).normalized * RayLength;
        lineRenderer.SetPositions(points);
    }
}