using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj3_OSC_Ctrl : MonoBehaviour
{
    Material mat;
    [SerializeField] GameObject osc_receiver;
    [SerializeField] Color col_multiply;
    OSC_4_receiver osc;
    Color col;
    Vector2 pos;
    float rota;
    Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<SpriteRenderer>().material;
        osc = osc_receiver.GetComponent<OSC_4_receiver>();

    }

    // Update is called once per frame
    void Update()
    {
        col = osc.obj3_col * col_multiply;
        pos = osc.obj3_pos;
        rota = osc.obj3_rota;
        scale = osc.obj3_scale;
        //Debug.Log(pos);
        mat.color = col;
        transform.position = new Vector3(pos.x, pos.y, 0);
        transform.rotation = Quaternion.Euler(0, 0, rota * 360f);
        transform.localScale = scale;
    }
}
