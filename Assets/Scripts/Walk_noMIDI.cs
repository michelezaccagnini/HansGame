using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk_noMIDI : MonoBehaviour
{
    private float x_pos;
    SpriteRenderer spriteRenderer;
    [SerializeField] float speed = 1f;
    [SerializeField] float waveSpeed = 1f;
    [SerializeField] float bounds = 2f;
    bool direction = false;
    Transform childTransform;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
        //childTransform = gameObject.transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        float wave_motion = Mathf.Sin(Time.time * Mathf.PI * 2f * waveSpeed);// data_in.GetCCbyIndex(cc_index);

        if (Mathf.Abs(x_pos) > bounds)
            direction = !direction;
        if (direction)
        {
            x_pos += Time.deltaTime* speed;
        }
        else
        {
            x_pos -= Time.deltaTime * speed;
        }
        //x_pos = (x_pos - data_in.GetCCbyIndex(0) * speed + bounds) % bounds;
        spriteRenderer.flipX = direction;
        transform.position = new Vector3(x_pos, wave_motion * 1f, 0);
    }
}
