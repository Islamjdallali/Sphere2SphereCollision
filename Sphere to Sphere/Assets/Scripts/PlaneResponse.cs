using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneResponse : MonoBehaviour
{

    [Range(0f, 1f)]
    public float coefficientOfRestitution;

    public Vector3 CollisionResponse(Vector3 velocity, Transform planeTransform)
    {
        Vector3 unitVelocity = velocity / velocity.magnitude;

        Vector3 unitResponseVelocity = ((2 * planeTransform.up) * Vector3.Dot(planeTransform.up, -unitVelocity)) + unitVelocity;

        return unitResponseVelocity * velocity.magnitude;
    }
}
