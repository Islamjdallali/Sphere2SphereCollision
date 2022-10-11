using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSphereCollision : MonoBehaviour
{
    public Transform otherSphere;
    public Vector3 velocityVector;
    public Vector3 secondSphereVelocityVector;

    public Vector3 sphereStartPos;
    private Vector3 secondSphereStartPos;

    public int interpolatedFrames = 60;
    private int elapsedFrames = 0;


    private float radius;

    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Bounds bounds = mesh.bounds;
        radius = bounds.extents.x;

        sphereStartPos = new Vector3(gameObject.GetComponent<Transform>().position.x, gameObject.GetComponent<Transform>().position.y, gameObject.GetComponent<Transform>().position.z);
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(velocityVector * Time.deltaTime);

        otherSphere.Translate(secondSphereVelocityVector * Time.deltaTime);

        //work out t, t is the interpolated time value, where t = 0 is the sphere's start pos and t = 1 is the sphere's end pos of their velocity vector
        float interpolationRatio = (float)elapsedFrames/interpolatedFrames;
        elapsedFrames = (elapsedFrames + 1) % (interpolatedFrames + 1);

        //once t >= 1, update the sphere's start position
        if (interpolationRatio >= 1)
        {
            sphereStartPos = new Vector3(gameObject.GetComponent<Transform>().position.x, gameObject.GetComponent<Transform>().position.y, gameObject.GetComponent<Transform>().position.z);
            secondSphereStartPos = new Vector3(otherSphere.position.x,otherSphere.position.y,otherSphere.position.z);
        }

        float xPositionDifference = sphereStartPos.x - secondSphereStartPos.x;
        float yPositionDifference = sphereStartPos.y - secondSphereStartPos.y;
        float zPositionDifference = sphereStartPos.z - secondSphereStartPos.z;

        float xVectorDifference = sphereStartPos.x - secondSphereStartPos.x;
        float yVectorDifference = sphereStartPos.y - secondSphereStartPos.y;
        float zVectorDifference = sphereStartPos.z - secondSphereStartPos.z;

        float a = Mathf.Pow(xVectorDifference,2) + Mathf.Pow(yVectorDifference,2) + Mathf.Pow(zVectorDifference,2);
        float b = (2 * xPositionDifference * xVectorDifference) + (2 * yPositionDifference * yVectorDifference) + (2 * zPositionDifference * zVectorDifference);
        float c = Mathf.Pow(xPositionDifference,2) + Mathf.Pow(yPositionDifference,2) + Mathf.Pow(zPositionDifference,2) - Mathf.Pow(2 * radius,2);

        float t = (-b + Mathf.Sqrt(Mathf.Pow(b,2) - (4 * a * c))/2 * a);
        float t2 = (-b - Mathf.Sqrt(Mathf.Pow(b,2) - (4 * a * c))/2 * a);

        Debug.Log("solution 1 : " + t);
        Debug.Log("solution 2 : " + t2);

    }
}
