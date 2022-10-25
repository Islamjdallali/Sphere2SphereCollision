using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCollisionResponse : MonoBehaviour
{
    public float firstSphereMass;
    public float secondSphereMass;

    public SphereCollision sphereCollision;

    [Range(0f,1f)]
    public float coefficientOfRestitution;

    /* Find the angle between the spheres, cos(a) and find the impulse
        p2 - p1 / |p2 - p1|

        work out the direction of response and multiply that by the impulse(magnitude)

        I = eCos(a)v if both masses are the same.
        If not then do I/m2 = eCos(a)vm1.
        Then, when I have found the impulse, find the vector using v2 = v1 - I
     */

    public void CollisionResponse(float angle, Vector3 velocity)
    {
        Vector3 impulse = velocity * firstSphereMass * angle * coefficientOfRestitution;

        Vector3 finalImpulse = impulse / secondSphereMass;

        Vector3 responseVectorSphere1 = new Vector3(0,0,0);

        Vector3 responseVectorSphere2 = velocity - finalImpulse;

        sphereCollision.velocityVector = responseVectorSphere1;
        sphereCollision.secondSphereVelocityVector = responseVectorSphere2;
    }
}
