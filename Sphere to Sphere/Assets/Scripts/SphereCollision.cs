using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCollision : MonoBehaviour
{
    public Transform secondSphere;

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

        //find the Vector between sphere A and sphere B
        float ABDistanceX = secondSphere.position.x - transform.position.x;
        float ABDistanceY = secondSphere.position.y - transform.position.y;
        float ABDistanceZ = secondSphere.position.z - transform.position.z;

        Vector3 ABVector = new Vector3(ABDistanceX,ABDistanceY,ABDistanceZ);

        float ABLength = Mathf.Sqrt((ABDistanceX * ABDistanceX) + (ABDistanceY * ABDistanceY) + (ABDistanceZ * ABDistanceZ));

        float angle = Mathf.Acos(ABDistanceZ/ABLength);

        float lengthD = Mathf.Sin(angle) * ABLength;

        if (lengthD < radius * 2)
        {
            float collisionPointLength = Mathf.Sqrt(((radius + radius) * 2) - (lengthD * 2));

            float collisionPoint = ABDistanceZ - collisionPointLength;

            if (collisionPoint <= 0)
            {
                Debug.Log("Collision Detected");
            }
        }
    }
}
