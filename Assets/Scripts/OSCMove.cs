using UnityEngine;
using System.Collections;
using OscJack;


public class OSCMove : MonoBehaviour
{
    OscServer _server;
    float osc_in;
    void Start()
    {
        _server = new OscServer(9000); // Port number

        _server.MessageDispatcher.AddCallback(
            "/test", // OSC address
            (string address, OscDataHandle data) => {
                
                osc_in = data.GetElementAsFloat(0);
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
        transform.position = new Vector3(osc_in, 0, 0);
    }
}
