using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSphereCollision : MonoBehaviour
{
    public Transform otherSphere;
    public Vector3 velocityVector;
    public Vector3 secondSphereVelocityVector;

    private Vector3 collisionPoint;


    private float radius;

    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Bounds bounds = mesh.bounds;
        radius = bounds.extents.x;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(velocityVector * Time.deltaTime);

        otherSphere.Translate(secondSphereVelocityVector * Time.deltaTime);

        float xPositionDifference = transform.position.x - otherSphere.position.x;
        float yPositionDifference = transform.position.y - otherSphere.position.y;
        float zPositionDifference = transform.position.z - otherSphere.position.z;

        float angle = Vector3.Angle(velocityVector, otherSphere.position - transform.position);
        angle = angle * Mathf.Deg2Rad;

        float targetAngle = Vector3.Angle(secondSphereVelocityVector, transform.position - otherSphere.position);
        targetAngle = targetAngle * Mathf.Deg2Rad;

        float xVectorDifference = velocityVector.x - secondSphereVelocityVector.x;
        float yVectorDifference = velocityVector.y - secondSphereVelocityVector.y;
        float zVectorDifference = velocityVector.z - secondSphereVelocityVector.z;

        float a = Mathf.Pow(xVectorDifference,2) + Mathf.Pow(yVectorDifference,2) + Mathf.Pow(zVectorDifference,2);
        float b = (2 * xPositionDifference * xVectorDifference) + (2 * yPositionDifference * yVectorDifference) + (2 * zPositionDifference * zVectorDifference);
        float c = Mathf.Pow(xPositionDifference,2) + Mathf.Pow(yPositionDifference,2) + Mathf.Pow(zPositionDifference,2) - Mathf.Pow(radius + radius,2);

        float t = (-b + Mathf.Sqrt(Mathf.Pow(b,2) - (4 * a * c)))/(2 * a);
        float t2 = (-b - Mathf.Sqrt(Mathf.Pow(b,2) - (4 * a * c)))/(2 * a);

        Debug.Log("t1 : " + t);
        Debug.Log("t2 : " + t2);

        //if t is the correct solution
        if (t < t2)
        {
            if (t > 0 && t < 1)
            {
                Debug.Log("Collision possible");
                collisionPoint = transform.position + velocityVector * t;
            }
        }
        else if (t2 < t)
        {
            if (t2 > 0 && t2 < 1)
            {
                Debug.Log("Collision possible");
                collisionPoint = transform.position + velocityVector * t;
                Debug.Log("Collision Point : " + collisionPoint);
            }
        }
    }
}
