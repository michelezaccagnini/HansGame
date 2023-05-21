using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBckgr : MonoBehaviour
{
    private float length;
    private float startPos;
    [SerializeField] GameObject cam;
    [SerializeField]  float parallaxEffect;
    void Start()
    {
        //cam = GameObject.Find("MainCamera");
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float distance = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
        if(temp > startPos + length)
        {
            startPos += length;
        }else if(temp < startPos - length)
        {
            startPos -= length;
        }
    }
}
