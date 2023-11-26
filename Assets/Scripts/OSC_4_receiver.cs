using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OscJack;


public class OSC_4_receiver : MonoBehaviour
{
    Material mat;

    OscServer _server;
    private int oscPort = 9000;

    // Animator speedAnimaton; //drop in game object
    [SerializeField] Vector2 screenSize = new Vector2(2f,2f);
    public float scrollBackground;

    [Header("Man")]
    public Vector2 man_pos;

    [Header("Object 1")]
    public Color obj1_col;
    public Vector2 obj1_pos;
    public float obj1_rota;
    public Vector3 obj1_scale;
    public float obj1_scroll;

    [Header("Object 2")]
    public Color obj2_col;
    public Vector2 obj2_pos;
    public float obj2_rota;
    public Vector3 obj2_scale;

    [Header("Object 3")]
    public Color obj3_col;
    public Vector2 obj3_pos;
    public float obj3_rota;
    public Vector3 obj3_scale;
    public Animator obj3_speedAnimaton;

    [Header("Object 4")]
    public Color obj4_col;
    public Vector2 obj4_pos;
    public float obj4_rota;
    public Vector3 obj4_scale;
  


    void Start()
    {
        Vector2 background_scale =
            new Vector2(screenSize.x - screenSize.x * 0.5f,
                        screenSize.y - screenSize.y * 0.5f);
        _server = new OscServer(oscPort); // Port number
        
        //Scroll
        _server.MessageDispatcher.AddCallback(
           "/scrollBackground", // OSC address 
           (string address, OscDataHandle data) => {
               scrollBackground = data.GetElementAsFloat(0);
           }
       );
        //man


        _server.MessageDispatcher.AddCallback(
            "/man_pos", // OSC address
            (string address, OscDataHandle data) => {

               man_pos.x = data.GetElementAsFloat(0) * background_scale.x;
                man_pos.y = data.GetElementAsFloat(1) * background_scale.y;
            }
        );
        // Object 1

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

                obj1_pos.x = data.GetElementAsFloat(0)* background_scale.x;
                obj1_pos.y = data.GetElementAsFloat(1) * background_scale.y;
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
            "/scroll1", // OSC address
            (string address, OscDataHandle data) => {

             obj1_scroll = data.GetElementAsFloat(0);

            }
        );
        // Object 2

        _server.MessageDispatcher.AddCallback(
            "/color2", // OSC address
            (string address, OscDataHandle data) => {

                obj2_col.r = data.GetElementAsFloat(0); //where is the r g b a ?
                obj2_col.g = data.GetElementAsFloat(1);
                obj2_col.b = data.GetElementAsFloat(2);
                obj2_col.a = data.GetElementAsFloat(3);
            }
        );
        _server.MessageDispatcher.AddCallback(
            "/position2", // OSC address
            (string address, OscDataHandle data) => {
                
                obj2_pos.x = data.GetElementAsFloat(0)* background_scale.x;
                obj2_pos.y = data.GetElementAsFloat(1) * background_scale.y;
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

        // Object 3

        _server.MessageDispatcher.AddCallback(
            "/color3", // OSC address
            (string address, OscDataHandle data) => {

                obj3_col.r = data.GetElementAsFloat(0);
                obj3_col.g = data.GetElementAsFloat(1);
                obj3_col.b = data.GetElementAsFloat(2);
                obj3_col.a = data.GetElementAsFloat(3);
            }
        );
        _server.MessageDispatcher.AddCallback(
            "/position3", // OSC address
            (string address, OscDataHandle data) => {

                obj3_pos.x = data.GetElementAsFloat(0)* background_scale.x;
                obj3_pos.y = data.GetElementAsFloat(1) * background_scale.y;
            }
        );
        _server.MessageDispatcher.AddCallback(
            "/rotation3", // OSC address
            (string address, OscDataHandle data) => {

                obj3_rota = data.GetElementAsFloat(0); //why not x, y, z ?
            }
        );
        _server.MessageDispatcher.AddCallback(
            "/scale3", // OSC address
            (string address, OscDataHandle data) => {

                obj3_scale.x = data.GetElementAsFloat(0);
                obj3_scale.y = data.GetElementAsFloat(1);
                obj3_scale.z = data.GetElementAsFloat(2);
            }
        );

        _server.MessageDispatcher.AddCallback(
            "/speedAnimation3", // OSC address
            (string address, OscDataHandle data) => {

            //obj3_speedAnimation = data.GetElementAsFloat(0);  why mistake?
               
            }
        );

        

        // Object 4

        _server.MessageDispatcher.AddCallback(
            "/color4", // OSC address
            (string address, OscDataHandle data) => {

                obj4_col.r = data.GetElementAsFloat(0);
                obj4_col.g = data.GetElementAsFloat(1);
                obj4_col.b = data.GetElementAsFloat(2);
                obj4_col.a = data.GetElementAsFloat(3);
            }
        );
        _server.MessageDispatcher.AddCallback(
            "/position4", // OSC address
            (string address, OscDataHandle data) => {

                obj4_pos.x = data.GetElementAsFloat(0)* background_scale.x;
                obj4_pos.y = data.GetElementAsFloat(1) * background_scale.y;
            }
        );
        _server.MessageDispatcher.AddCallback(
            "/rotation4", // OSC address
            (string address, OscDataHandle data) => {

                obj4_rota = data.GetElementAsFloat(0);
            }
        );
        _server.MessageDispatcher.AddCallback(
            "/scale4", // OSC address
            (string address, OscDataHandle data) => {

                obj4_scale.x = data.GetElementAsFloat(0);
                obj4_scale.y = data.GetElementAsFloat(1);
                obj4_scale.z = data.GetElementAsFloat(2);
            }
        );

        _server.MessageDispatcher.AddCallback(
            "/scale4", // OSC address
            (string address, OscDataHandle data) => {

                obj4_scale.x = data.GetElementAsFloat(0);
                obj4_scale.y = data.GetElementAsFloat(1);
                obj4_scale.z = data.GetElementAsFloat(2);
            }
        );

        _server.MessageDispatcher.AddCallback(
            "/speedAnimation4", // OSC address
            (string address, OscDataHandle data) => {

             //obj4_speedAnimaton4 = data.GetElementAsFloat(0);
                
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

//Nur eine Portnummer (9000) möglich, Nur ein OSC_receiver Script im Projekt möglich
//Neues Game Object erstellen mit dem Namen OSC Receiver und das Script dort einfügen.
//Dieses Game Object in die verschiedenen Obj2_OSC_Ctrl Scripte einfügen.
//Für jeden Character (Game Object) muss ein neues anderes Obj2_OSC_Ctrl Script erstellt
//werden mit jeweils unterschiedlichen Variablennamen z.B. obj1_rota, obj1_rota usw.