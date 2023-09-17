using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OscJack;

public class OSC_receiver : MonoBehaviour
{
    Material mat;

    OscServer _server;
    [SerializeField] int oscPort = 9000;
    float red;
    float green;
    float blue;
    float alpha;
    Vector2 pos;
    float rota;
    Vector3 scale;
    void Start()
    {
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
        _server.MessageDispatcher.AddCallback(
            "/position", // OSC address
            (string address, OscDataHandle data) => {

                pos.x = data.GetElementAsFloat(0);
                pos.y = data.GetElementAsFloat(1);
            }
        );
        _server.MessageDispatcher.AddCallback(
            "/rotation", // OSC address
            (string address, OscDataHandle data) => {

                rota = data.GetElementAsFloat(0);
            }
        );
        _server.MessageDispatcher.AddCallback(
            "/scale", // OSC address
            (string address, OscDataHandle data) => {

                scale.x = data.GetElementAsFloat(0);
                scale.y = data.GetElementAsFloat(1);
                scale.z = data.GetElementAsFloat(2);
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
       /* //Debug.Log(osc_in);
        mat.color = new Color(red, blue, green, alpha);
        transform.position = new Vector3(pos.x, pos.y, 0);
        transform.rotation = Quaternion.Euler(0, 0, rota * 360f);
        transform.localScale = scale;*/
    }
}
