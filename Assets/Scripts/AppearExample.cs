using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearExample : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    private float timer = 0;
    public float interval = 2f;
    bool appear;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >=  interval)
        {
            spriteRenderer.enabled = appear;
            appear = !appear;
            timer = 0;
        }
        
    }
}
