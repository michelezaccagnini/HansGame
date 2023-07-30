using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CmanAnim3 : MonoBehaviour
{
    [SerializeField] EasingFunction.Ease easeUp;
    [SerializeField] EasingFunction.Ease easeDown;
    EasingFunction.Function jumpFuncUp;
    EasingFunction.Function jumpFuncDown;
    [SerializeField] float jumpHeight = 2f;
    bool jDown = false;


    int pcount;
    [SerializeField] Slider slider;
    [SerializeField] float jumpSpeed = 50f;


    private float sli_val;
    private float x_pos;
    private float y_pos;
    SpriteRenderer spriteRenderer;
    [SerializeField] float speed = 1f;
    [SerializeField] float waveSpeed = 1f;
    [SerializeField] float bounds = 2f;
    bool direction = false;
    Vector3 init_pos;

    bool jump;
    float timer;

    void Start()
    {
        jumpFuncUp = EasingFunction.GetEasingFunction(easeUp);
        jumpFuncDown = EasingFunction.GetEasingFunction(easeDown);
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
        jumpFuncUp = EasingFunction.GetEasingFunction(easeUp);
        jumpFuncDown = EasingFunction.GetEasingFunction(easeDown);
    }

    void Update()
    {
        Vector3 pos = transform.position;
        if (Input.GetKeyDown("space"))
        {
            timer = 0;
            jump = true;
            jDown = false;
        }
        if (jump && !jDown)
        {
            timer += Time.deltaTime * jumpSpeed;
            y_pos = jumpFuncUp(0, jumpHeight, timer);
            //Debug.Log(timer);
        }
        if (timer > jumpHeight - 0.01f)
        {
            jDown = true;

        }
        if (jDown)
        {
            timer -= Time.deltaTime * jumpSpeed;
            y_pos =jumpFuncDown( 0,jumpHeight,  timer );
            if (timer < 0.01f)
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
        transform.position = init_pos + new Vector3(x_pos, y_pos, 0);
    }
}
