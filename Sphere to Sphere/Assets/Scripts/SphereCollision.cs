using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCollision : MonoBehaviour
{
    public Transform secondSphere;

    public Vector3 velocityVector;

    public SphereCollisionResponse sphereCollisionResponse;

    float radius;

    // Start is called before the first frame update
    void Start()
    {
        //Get Sphere mesh radius
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Bounds bounds = mesh.bounds;
        radius = bounds.extents.x;
    }

    // Update is called once per frame
    void Update()
    {
        //this.gameObject.transform.Translate(velocityVector * Time.deltaTime);

        //find the Vector between sphere A and sphere B
        float ABDistanceX = Mathf.Abs(secondSphere.position.x - transform.position.x);
        float ABDistanceY = Mathf.Abs(secondSphere.position.y - transform.position.y);
        float ABDistanceZ = Mathf.Abs(secondSphere.position.z - transform.position.z);

        float ABLength = Mathf.Sqrt((ABDistanceX * ABDistanceX) + (ABDistanceY * ABDistanceY) + (ABDistanceZ * ABDistanceZ));

        //Find the angle for each respective axis
        float angleZ = Mathf.Acos(ABDistanceZ/ABLength);
        float angleX = Mathf.Acos(ABDistanceX/ABLength);
        float angleY = Mathf.Acos(ABDistanceY/ABLength);

        //Find the length between the centre of the 2 spheres at the closest approach along the path of the sphere's velocity
        float lengthDZ = Mathf.Sin(angleZ) * ABLength;
        float lengthDX = Mathf.Sin(angleX) * ABLength;
        float lengthDY = Mathf.Sin(angleY) * ABLength;

        //check if collision is possible in the Z axis
        if (lengthDZ < radius * 2)
        {
            float collisionPointLength = Mathf.Sqrt(((radius + radius) * (radius + radius)) - (lengthDZ * lengthDZ));

            float collisionPoint = ABDistanceZ - collisionPointLength;

            if (collisionPoint <= 0)
            {
                Debug.Log("Collision Detected");
                sphereCollisionResponse.CollisionResponse(1 - angleZ,velocityVector);
            }
        }

        //check if collision is possible in the X axis
        if (lengthDX < radius * 2)
        {
            float collisionPointLength = Mathf.Sqrt(((radius + radius) * (radius + radius)) - (lengthDX * lengthDX));

            float collisionPoint = ABDistanceX - collisionPointLength;

            if (collisionPoint <= 0)
            {
                Debug.Log("Collision Detected");
            }
        }

        //check if collision is possible in the Y axis
        if (lengthDY < radius * 2)
        {
            float collisionPointLength = Mathf.Sqrt(((radius + radius) * (radius + radius)) - (lengthDY * lengthDY));

            float collisionPoint = ABDistanceY - collisionPointLength;

            if (collisionPoint <= 0)
            {
                Debug.Log("Collision Detected");
            }
        }
    }
}
