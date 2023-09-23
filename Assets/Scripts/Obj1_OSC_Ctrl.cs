using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj1_OSC_Ctrl : MonoBehaviour
{
    Material mat;
    [SerializeField] GameObject osc_receiver;
    OSC_receiver osc;
    Color col;
    Vector2 pos;
    float rota;
    Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<SpriteRenderer>().material;
        osc = osc_receiver.GetComponent<OSC_receiver>();
        
    }

    // Update is called once per frame
    void Update()
    {
        col = osc.obj1_col;
        pos = osc.obj1_pos;
        rota = osc.obj1_rota;
        scale = osc.obj1_scale;
        //Debug.Log(osc_in);
        mat.color = col;
        transform.position = new Vector3(pos.x, pos.y, 0);
        transform.rotation = Quaternion.Euler(0, 0, rota * 360f);
        transform.localScale = scale;
    }
}
