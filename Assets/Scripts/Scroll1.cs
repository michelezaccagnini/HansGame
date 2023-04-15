using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll1 : MonoBehaviour
{
    Material mat;
    [SerializeField] float speed = 0.1f;
    [SerializeField] float kaleidoSize = 4f;
    private float offset;
    
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }
    void Update()
    {
        offset -= Time.deltaTime * speed;
        mat.mainTextureScale = new Vector2(kaleidoSize, kaleidoSize);
        mat.mainTextureOffset = new Vector2(offset,0);
    }
}
