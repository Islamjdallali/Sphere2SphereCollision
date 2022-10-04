using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCollision : MonoBehaviour
{
    public Transform planeTransform;
    public Vector3 sphereStartPos;

    public Vector3 velocityVector;
    public float velocityVectorMagnitude;

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
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(velocityVector * Time.deltaTime);

        //find the Vector between the sphere and the plane
        SPVectorX = Mathf.Abs(planeTransform.position.x - transform.position.x);
        SPVectorY = Mathf.Abs(planeTransform.position.y - transform.position.y);
        SPVectorZ = Mathf.Abs(planeTransform.position.z - transform.position.z);

        velocityVectorMagnitude = Mathf.Sqrt((velocityVector.x * velocityVector.x) + (velocityVector.y * velocityVector.y) + (velocityVector.z * velocityVector.z));

        ABLength = Mathf.Sqrt((SPVectorX * SPVectorX) + (SPVectorY * SPVectorY) + (SPVectorZ * SPVectorZ));

        //find the angle between the sphere vector and the plane
        spherePlaneAngleZ = (Mathf.Acos(SPVectorZ / ABLength));
        spherePlaneAngleX = (Mathf.Acos(SPVectorX / ABLength));
        spherePlaneAngleY = (Mathf.Acos(SPVectorY / ABLength));

        float vCY = (SPVectorY - radius) / (Mathf.Cos(spherePlaneAngleY));

        //check to see if a collision is possible
        if (vCY <= velocityVectorMagnitude)
        {
            Vector3 addedvCY = vCY * velocityVector / velocityVectorMagnitude;
            float addedvCYMag = Mathf.Sqrt((addedvCY.x * addedvCY.x) + (addedvCY.y * addedvCY.y) + (addedvCY.z * addedvCY.z));

            if (addedvCYMag <= 0.01f)
            {
                Debug.Log("Collided");
                velocityVector = new Vector3(0,0,0);
            }
        }
    }
}
