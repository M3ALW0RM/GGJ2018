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
    //Ration of window width
    float lefthandBorder;

    [SerializeField]
    GameObject messagePrefab;

    [SerializeField]
    float EarthLazerLength;

    //[SerializeField]
   // GameObject panel;
    //[SerializeField]
    //Canvas UICanvas;
    [SerializeField]
    Camera screenCamera;

    LineRenderer lineRenderer;
    LineRenderer EarthLineRenderer;

    float targetAngle;
    float currentAngle = 0;
    float minMouseX;

    // Use this for initialization
    void Start ()
    {
        minMouseX = lefthandBorder*Screen.width;
        lineRenderer = GetComponent<LineRenderer>();
        EarthLineRenderer = Earth.GetComponent<LineRenderer>();
	}
	
    public void FireCannon(AlertAnswer answer)
    {
        GameObject message = Instantiate(messagePrefab, transform.position, Quaternion.LookRotation(transform.forward));
        message.GetComponent<MessageBehaviour>().answer = answer;
    }

    public void MoveCannon()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Earth.transform.position.z - screenCamera.transform.position.z;
        Vector3 mouseInWorld = screenCamera.ScreenToWorldPoint(mousePos);

        targetAngle = Mathf.Acos(Vector3.Dot(mouseInWorld - Earth.transform.position, new Vector3(1, 0, 0)) / ((mouseInWorld - Earth.transform.position).magnitude * new Vector3(1, 0, 0).magnitude)) * 180f / Mathf.PI;

        Vector3[] earthlinePoints = new Vector3[2];
        earthlinePoints[0] = Earth.transform.position;
        earthlinePoints[1] = mouseInWorld + (mouseInWorld - Earth.transform.position).normalized * 10;
        EarthLineRenderer.SetPositions(earthlinePoints);

        Vector3[] points = new Vector3[2];
        points[0] = transform.position;
        points[1] = transform.position + (transform.position - Earth.transform.position).normalized * RayLength;
        lineRenderer.SetPositions(points);

        StartCoroutine("Rotate");
    }

    IEnumerator Rotate()
    {
        while (currentAngle != targetAngle)
        {
            if (currentAngle < targetAngle - angleTolerance)
            {
                transform.RotateAround(transform.position, new Vector3(0, 0, 1), RotateSpeed * (1 - currentAngle / targetAngle) * Time.deltaTime);
                currentAngle += RotateSpeed * (1 - currentAngle / targetAngle) * Time.deltaTime;
            }
            else if (currentAngle > targetAngle + angleTolerance)
            {
                transform.RotateAround(transform.position, new Vector3(0, 0, 1), -RotateSpeed * (1 - targetAngle / currentAngle) * Time.deltaTime);
                currentAngle -= RotateSpeed * (1 - targetAngle / currentAngle) * Time.deltaTime;
            }
            yield return null;
        }
    }

	// Update is called once per frame
	void Update ()
    {
    }
}