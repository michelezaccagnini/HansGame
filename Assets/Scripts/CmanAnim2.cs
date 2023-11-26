using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CmanAnim2 : MonoBehaviour
{
    //OSC variables
    [SerializeField] GameObject osc_receiver;
    OSC_4_receiver osc;




    void Start()
    {
        osc = osc_receiver.GetComponent<OSC_4_receiver>();

    }

    void Update()
    {
        Vector2 pos = osc.man_pos;
      
        transform.position = new Vector3(pos.x,pos.y,0);
    }
}
