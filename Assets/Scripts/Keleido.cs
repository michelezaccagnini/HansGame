using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keleido : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    //Texture texture;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //texture = spriteRenderer.material.mainTexture;
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.material.mainTextureOffset = new Vector2(Time.time, 0.5f);
        //texture = new Vector3(Time.time, 0.5f,1f);
    }
}
