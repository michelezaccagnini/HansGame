using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CmanAnim2 : MonoBehaviour
{
    [SerializeField] EasingFunction.Ease ease;
    EasingFunction.Function jumpFunc;
    [SerializeField] float jumpHeight = 2f;
    bool jDown = false;


    int pcount;
    [SerializeField] Slider slider;
    [SerializeField] float jumpSpeed = 50f;


    private float sli_val;
    private float x_pos;
    SpriteRenderer spriteRenderer;
    [SerializeField] float speed = 1f;
    [SerializeField] float waveSpeed = 1f;
    [SerializeField] float bounds = 2f;
    bool direction = false;
    Vector3 init_pos;

    bool jump;
    float jumpRamp;

    void Start()
    {
        jumpFunc = EasingFunction.GetEasingFunction(ease);
        slider.onValueChanged.AddListener((v) =>
        {
            sli_val = v;
        });
        spriteRenderer = GetComponent<SpriteRenderer>();
        //anim = gameObject.GetComponent<Animator>();
        init_pos = transform.position;
    }
    private void OnGUI()
    {
        jumpFunc = EasingFunction.GetEasingFunction(ease);
    }

    void Update()
    {
        Vector3 pos = transform.position;
        
        float wave_motion = 0;// Mathf.Sin(Time.time * Mathf.PI * 2f * waveSpeed);// data_in.GetCCbyIndex(cc_index);
        if (Input.GetKeyDown("space"))
        {
            jump = true;
            jDown = false;
        }
        if (jump && !jDown)
        {
            jumpRamp += jumpFunc(0,jumpHeight,Time.deltaTime*jumpSpeed);
            //Debug.Log(jumpRamp);
        }
        if(jumpRamp > jumpHeight -0.1f)
        {
            jDown = true;
       
        }
        if(jDown) 
        {
            jumpRamp -=  jumpFunc(0,jumpHeight,Time.deltaTime * jumpSpeed);
            if(jumpRamp < 0.1f)
            {
                jump = false;
                jDown = false;
            }
        }

        if (Mathf.Abs(x_pos) > bounds)
            direction = !direction;
        if (direction)
        {
            x_pos += Time.deltaTime * speed * sli_val;
        }
        else
        {
            x_pos -= Time.deltaTime * speed * sli_val;
        }
        //x_pos = (x_pos -  * sli_val+ bounds) % bounds;
        spriteRenderer.flipX = direction;
        transform.position = init_pos + new Vector3(x_pos,jumpRamp, 0);
    }
}
