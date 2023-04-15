using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk_noMIDIRand : MonoBehaviour
{
    private float x_pos;
    SpriteRenderer spriteRenderer;
    [SerializeField] float speed = 1f;
    [SerializeField] float waveSpeed = 1f;
    
    [SerializeField] float bounds = 2f;
    [SerializeField] float waveHigh = 1f;
    [SerializeField]
    [Range (10,100)] int random_frequency = 10;
    bool direction = false;
    float rand_val;
    float target_rand_val;
    int frame_count;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        frame_count = frame_count % random_frequency;
        if(frame_count == 0)
            target_rand_val = Random.Range(0f, 8f);
        frame_count++;
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
        rand_val = Mathf.Lerp(rand_val, target_rand_val, 0.1f);
        spriteRenderer.flipX = direction;
        transform.position = new Vector3(x_pos, wave_motion * rand_val * waveHigh, 0);
    }
}
