using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll1 : MonoBehaviour
{
    Material mat;
    [SerializeField] GameObject osc_receiver;
    OSC_4_receiver osc;
    [SerializeField] float speed = 0.1f;
    [SerializeField] float kaleidoSize = 4f;
    private float offset;
    
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        osc = osc_receiver.GetComponent<OSC_4_receiver>();
    }
    void Update()
    {
        offset = osc.scrollBackground;// * speed;
        mat.mainTextureScale = new Vector2(kaleidoSize, kaleidoSize);
        mat.mainTextureOffset = new Vector2(offset,0);
    }
}
