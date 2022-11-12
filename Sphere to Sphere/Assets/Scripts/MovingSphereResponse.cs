using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSphereResponse : MonoBehaviour
{
    [Range(0f, 1f)]
    public float coefficientOfRestitution;

    [SerializeField] private float mass;
    [SerializeField] private float targetMass;


    public Vector3 CollisionResponse(float angle, float targetAngle, Transform sphereTransform, Transform targetSphereTransform, 
        Vector3 velocityVector, Vector3 targetVelocityVector)
    {
        Vector3 directionOfForce = sphereTransform.position - targetSphereTransform.position / Vector3.Magnitude(sphereTransform.position - targetSphereTransform.position);
        Vector3 targetDirectionOfForce = targetSphereTransform.position - sphereTransform.position / Vector3.Magnitude(targetSphereTransform.position - sphereTransform.position);
        float strength = (Mathf.Cos(angle) * velocityVector.magnitude * mass) / targetMass;

        Debug.Log("Strength : " + strength);
        Debug.Log("direction : " + directionOfForce);
        float targetStrength = (targetAngle * targetVelocityVector.magnitude * targetMass) / mass;

        Vector3 responseVector = (velocityVector + (strength * directionOfForce)) - (targetDirectionOfForce * targetStrength);

        Debug.Log("Vector :  " + responseVector);

        return responseVector;
    }
}
