using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSphereCollision : MonoBehaviour
{
    public Transform otherSphere;
    public Vector3 velocityVector;

    private float radius;

    public float t = 0;

    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Bounds bounds = mesh.bounds;
        radius = bounds.extents.x;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(velocityVector * Time.deltaTime);

        t += Time.deltaTime;
        if (t >= 1)
        {
            velocityVector = new Vector3(0,0,0);
        }
    }
}
