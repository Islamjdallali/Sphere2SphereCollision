using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCollision : MonoBehaviour
{
    public Transform planeTransform;

    public Vector3 velocityVector;

    float radius;

    // Start is called before the first frame update
    void Start()
    {
        //Get Sphere mesh radius
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        radius = Vector3.Distance(transform.position, vertices[0]);
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(velocityVector * Time.deltaTime);

        //find the Vector between the sphere and the plane
        float ABDistanceX = Mathf.Abs(planeTransform.position.x - transform.position.x);
        float ABDistanceY = Mathf.Abs(planeTransform.position.y - transform.position.y);
        float ABDistanceZ = Mathf.Abs(planeTransform.position.z - transform.position.z);

        float ABLength = Mathf.Sqrt((ABDistanceX * ABDistanceX) + (ABDistanceY * ABDistanceY) + (ABDistanceZ * ABDistanceZ));

        float angleZ = Mathf.Acos(ABDistanceZ / ABLength);
        float angleX = Mathf.Acos(ABDistanceX / ABLength);
        float angleY = Mathf.Acos(ABDistanceY / ABLength);

        float lengthD = Mathf.Sin(90 - (angleY * Mathf.Rad2Deg)) * ABLength;

        Debug.Log(lengthD);
    }
}
