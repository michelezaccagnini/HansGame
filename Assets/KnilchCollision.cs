using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnilchCollision : MonoBehaviour
{
    private BoxCollider2D bc1;
    private BoxCollider2D bc2;
    [SerializeField]
    GameObject gm2;

    Vector3 hash31(float p)
    {
        Vector3 pp = new Vector3(0.1031f, 0.1030f, 0.0973f);
        Vector3 p3 = new Vector3(p, p, p);
        p3 = Vector3.Scale(p3, pp);
        p3 = new Vector3(p3.x % 1f, p3.y % 1f, p3.z % 1f);
        Vector3 p3a = new Vector3(p3.y, p3.z, p3.x) + new Vector3(33.33f, 33.33f, 33.33f);
        float d = Vector3.Dot(p3, p3a);
        p3 = p3 + new Vector3(d, d, d);
        p3 = Vector3.Scale(new Vector3(p3.x, p3.x, p3.y) + new Vector3(p3.y, p3.z, p3.z), new Vector3(p3.z, p3.y, p3.x));
        p3 = new Vector3(p3.x % 1f, p3.y % 1f, p3.z % 1f);
        return p3;
    }
    void Start()
    {
        bc1 = GetComponent<BoxCollider2D>();
        bc2 = gm2.GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(bc1.bounds.Intersects(bc2.bounds))
        {
            Vector3 pos = hash31(Time.time);
            transform.position = pos;
            Debug.Log(pos);

        }
    }
}
