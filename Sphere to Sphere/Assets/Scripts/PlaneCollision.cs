using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCollision : MonoBehaviour
{
    public Transform planeTransform;
    public Vector3 sphereStartPos;

    public Vector3 velocityVector;

    float radius;

    float startSpherePlaneDistance;

    float SPVectorX;
    float SPVectorY;
    float SPVectorZ;

    float ABLength;

    float vectorSpherePlaneDistanceAngleY;

    float spherePlaneAngleY;
    float spherePlaneAngleZ;
    float spherePlaneAngleX;

    // Start is called before the first frame update
    void Start()
    {
        //Get Sphere mesh radius
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Bounds bounds = mesh.bounds;
        radius = bounds.extents.x;

        sphereStartPos = new Vector3(gameObject.GetComponent<Transform>().position.x, gameObject.GetComponent<Transform>().position.y, gameObject.GetComponent<Transform>().position.z);

        //find the Vector between the sphere and the plane
        SPVectorX = Mathf.Abs(planeTransform.position.x - transform.position.x);
        SPVectorY = Mathf.Abs(planeTransform.position.y - transform.position.y);
        SPVectorZ = Mathf.Abs(planeTransform.position.z - transform.position.z);

        ABLength = Mathf.Sqrt((SPVectorX * SPVectorX) + (SPVectorY * SPVectorY) + (SPVectorZ * SPVectorZ));

        //find the angle between the sphere vector and the plane
        spherePlaneAngleZ = 90 - (Mathf.Acos(SPVectorZ / ABLength) * Mathf.Rad2Deg);
        spherePlaneAngleX = 90 - (Mathf.Acos(SPVectorX / ABLength) * Mathf.Rad2Deg);
        spherePlaneAngleY = 90 - (Mathf.Acos(SPVectorY / ABLength) * Mathf.Rad2Deg);

        //this gives us the shortest distance betweent the sphere and the plane at its start position
        startSpherePlaneDistance = Mathf.Sin(spherePlaneAngleY) * ABLength;

        //this gives us the angle between the sphere vector and the startSpherePlaneDistance
        vectorSpherePlaneDistanceAngleY = 180 - (90 + spherePlaneAngleY);
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(velocityVector * Time.deltaTime);

        float vCY = (startSpherePlaneDistance - radius) / Mathf.Cos(vectorSpherePlaneDistanceAngleY);

        //check to see if a collision is possible
        if (vCY <= ABLength)
        {
            float expectedYPos = (sphereStartPos.y) - (SPVectorY * (1/ABLength) * vCY);

            //Debug.Log("SPVectorY : " + SPVectorY);
            //Debug.Log("AB Length : " + ABLength);
            //Debug.Log("VCY : " + vCY);

            Debug.Log("Expected Pos : " + expectedYPos);

            if (transform.position.y <= expectedYPos)
            {
                Debug.Log("Collided");
            }
        }
    }
}
