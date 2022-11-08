using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCollisionResponse : MonoBehaviour
{
    public float firstSphereMass;
    public float secondSphereMass;

    public SphereCollision sphereCollision;

    public Vector3 responseVectorSphere2;
    public Vector3 responseVectorSphere1;

    [Range(0f,1f)]
    public float coefficientOfRestitution;

    /* Find the angle between the spheres, cos(a) and find the impulse
        p2 - p1 / |p2 - p1|

        work out the direction of response and multiply that by the impulse(magnitude)

        I = eCos(a)v if both masses are the same.
        If not then do I = ecos(a)|v2|m1 / m2
        Then, when I have found the impulse, find the vector using v2 = v1 - I
     */

    public void CollisionResponse(float angle, Vector3 velocity, Transform spherePos,Transform targetPos)
    {
        Vector3 responseDir =  spherePos.position - targetPos.position / (spherePos.position - targetPos.position).magnitude;

        float impulse = (coefficientOfRestitution * MathF.Cos(angle) * velocity.magnitude * firstSphereMass) / secondSphereMass;

        responseVectorSphere2 = velocity - (responseDir * impulse);
        responseVectorSphere1 = (velocity * firstSphereMass - responseVectorSphere2 * secondSphereMass) / firstSphereMass;
    }
}
