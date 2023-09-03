using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OscJack;

public class TriangleColor : MonoBehaviour
{
    Material mat;

    OscServer _server;
    [SerializeField] int oscPort = 9000;
    float red;
    float green;
    float blue;
    float alpha;
    void Start()
    {
        mat = GetComponent<SpriteRenderer>().material;
        _server = new OscServer(oscPort); // Port number

        _server.MessageDispatcher.AddCallback(
            "/color", // OSC address
            (string address, OscDataHandle data) => {

                red = data.GetElementAsFloat(0);
                green = data.GetElementAsFloat(1);
                blue = data.GetElementAsFloat(2);
                alpha = data.GetElementAsFloat(3);
            }
        );
    }

    void OnDestroy()
    {
        _server?.Dispose();
        _server = null;
    }
    private void Update()
    {
        //Debug.Log(osc_in);
        mat.color = new Color(red, blue, green,alpha);
    }
}
