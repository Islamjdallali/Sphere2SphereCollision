using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSphereResponse : MonoBehaviour
{
    [Range(0f, 1f)]
    public float coefficientOfRestitution;

    public Vector3 CollisionResponse(float angle, float targetAngle, Transform sphereTransform, Transform targetSphereTransform, 
        Vector3 velocityVector, Vector3 targetVelocityVector, float mass, float targetMass)
    {
        Vector3 directionOfForce = targetSphereTransform.position - sphereTransform.position / Vector3.Magnitude(targetSphereTransform.position - sphereTransform.position);
        Vector3 targetDirectionOfForce = sphereTransform.position - targetSphereTransform.position / Vector3.Magnitude(sphereTransform.position - targetSphereTransform.position);
        float strength = (angle * velocityVector.magnitude * mass) / targetMass;
        float targetStrength = (targetAngle * targetVelocityVector.magnitude * targetMass) / mass;

        Vector3 responseVector = (velocityVector + strength * directionOfForce) - (targetDirectionOfForce * targetStrength);

        return responseVector;
    }
}
