using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private BoxCollider2D bc1;
    private BoxCollider2D bc2;
    private BoxCollider2D bc3;
    private SpriteRenderer sr;
    [SerializeField]
    GameObject gm2;
    [SerializeField]
    GameObject gm3;
    private bool was_hit = false;

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
    void Awake()
    {
        bc1 = GetComponent<BoxCollider2D>();
        bc2 = gm2.GetComponent<BoxCollider2D>();
        bc3 = gm3.GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (bc1.bounds.Intersects(bc2.bounds) && !was_hit)//new hit
        {
            Vector3 col = hash31(Time.time);
            sr.color = new Color(col.x,col.y,col.z,1f) ; 
            was_hit = true;
        }
        else if (bc1.bounds.Intersects(bc2.bounds) && was_hit)//it's hitting but it was already hitting before (old hit)
        {
            was_hit = true;
        }
        else//it's not hitting
        {
            was_hit = false;
        }

        //triangle object
        if (bc1.bounds.Intersects(bc3.bounds))
        {
            Vector3 col = hash31(Time.time);
            sr.color = Color.green;// new Color(col.x,col.y,col.z,1f) ;
            
        }


        /*
       if(bc1.bounds.Intersects(bc2.bounds) && !was_hit)
        {
            Vector3 h = hash31(Time.time);
            Color col = new Color(h.x, h.y, h.z, 1f);
            sr.color = col;
            was_hit = true;
        }
        else if(bc1.bounds.Intersects(bc2.bounds) && was_hit)
        {
            was_hit = true;
        }
       else
        {
            was_hit = false;
        }
        */
    }
}