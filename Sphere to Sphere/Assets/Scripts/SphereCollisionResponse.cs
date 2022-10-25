using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCollisionResponse : MonoBehaviour
{
    public float firstSphereMass;
    public float secondSphereMass;

    [Range(0f,1f)]
    public float coefficientOfRestitution;

    /* Find the angle between the spheres, cos(a) and find the impulse
        I = eCos(a)v if both masses are the same.
        If not then do I/m2 = eCos(a)vm1.
        Then, when I have found the impulse, find the vector using v2 = v1 - I
     */

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
