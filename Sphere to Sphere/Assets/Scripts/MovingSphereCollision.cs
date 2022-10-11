using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSphereCollision : MonoBehaviour
{
    public Transform otherSphere;
    public Vector3 velocityVector;
    public Vector3 sphereStartPos;
    private Vector3 secondSphereStartPos;

    public int interpolatedFrames = 60;
    private int elapsedFrames = 0;


    private float radius;

    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Bounds bounds = mesh.bounds;
        radius = bounds.extents.x;

        sphereStartPos = new Vector3(gameObject.GetComponent<Transform>().position.x, gameObject.GetComponent<Transform>().position.y, gameObject.GetComponent<Transform>().position.z);
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(velocityVector * Time.deltaTime);

        //work out t, t is the interpolated time value, where t = 0 is the sphere's start pos and t = 1 is the sphere's end pos of their velocity vector
        float interpolationRatio = (float)elapsedFrames/interpolatedFrames;
        elapsedFrames = (elapsedFrames + 1) % (interpolatedFrames + 1);

        //once t >= 1, update the sphere's start position
        if (interpolationRatio >= 1)
        {
            sphereStartPos = new Vector3(gameObject.GetComponent<Transform>().position.x, gameObject.GetComponent<Transform>().position.y, gameObject.GetComponent<Transform>().position.z);
        }


    }
}
