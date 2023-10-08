using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OscJack;

public class OSC_receiver : MonoBehaviour
{
    Material mat;

    OscServer _server;
    [SerializeField] int oscPort = 9000;
    public Color obj1_col;
    public Vector2 obj1_pos;
    public float obj1_rota;
    public Vector3 obj1_scale;
    public Color obj2_col;
    public Vector2 obj2_pos;
    public float obj2_rota;
    public Vector3 obj2_scale;
    void Start()
    {
        _server = new OscServer(oscPort); // Port number

        _server.MessageDispatcher.AddCallback(
            "/color1", // OSC address
            (string address, OscDataHandle data) => {

                obj1_col.r = data.GetElementAsFloat(0);
                obj1_col.g = data.GetElementAsFloat(1);
                obj1_col.b = data.GetElementAsFloat(2);
                obj1_col.a = data.GetElementAsFloat(3);
            }
        );
        _server.MessageDispatcher.AddCallback(
            "/position1", // OSC address
            (string address, OscDataHandle data) => {

                obj1_pos.x = data.GetElementAsFloat(0);
                obj1_pos.y = data.GetElementAsFloat(1);
            }
        );
        _server.MessageDispatcher.AddCallback(
            "/rotation1", // OSC address
            (string address, OscDataHandle data) => {

                obj1_rota = data.GetElementAsFloat(0);
            }
        );
        _server.MessageDispatcher.AddCallback(
            "/scale1", // OSC address
            (string address, OscDataHandle data) => {

                obj1_scale.x = data.GetElementAsFloat(0);
                obj1_scale.y = data.GetElementAsFloat(1);
                obj1_scale.z = data.GetElementAsFloat(2);
            }
        );
        _server.MessageDispatcher.AddCallback(
            "/color2", // OSC address
            (string address, OscDataHandle data) => {

                obj2_col.r = data.GetElementAsFloat(0);
                obj2_col.g = data.GetElementAsFloat(1);
                obj2_col.b = data.GetElementAsFloat(2);
                obj2_col.a = data.GetElementAsFloat(3);
            }
        );
        _server.MessageDispatcher.AddCallback(
            "/position2", // OSC address
            (string address, OscDataHandle data) => {
                
                obj2_pos.x = data.GetElementAsFloat(0);
                obj2_pos.y = data.GetElementAsFloat(1);
            }
        );
        _server.MessageDispatcher.AddCallback(
            "/rotation2", // OSC address
            (string address, OscDataHandle data) => {

                obj2_rota = data.GetElementAsFloat(0);
            }
        );
        _server.MessageDispatcher.AddCallback(
            "/scale2", // OSC address
            (string address, OscDataHandle data) => {

                obj2_scale.x = data.GetElementAsFloat(0);
                obj2_scale.y = data.GetElementAsFloat(1);
                obj2_scale.z = data.GetElementAsFloat(2);
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

    }
}
