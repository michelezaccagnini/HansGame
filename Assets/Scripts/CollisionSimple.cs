using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OscJack;
public class CollisionSimple : MonoBehaviour
{
    OscClient _client;
    [SerializeField] GameObject colliding_object;
    private BoxCollider2D box_collider_colliding;
    private BoxCollider2D box_collider;
    void Start()
    {
        box_collider_colliding = colliding_object.GetComponent<BoxCollider2D>();
        box_collider = GetComponent<BoxCollider2D>();
        // IP address, port number
        _client = new OscClient("127.0.0.1", 9001);

    }
 

    // Update is called once per frame
    void Update()
    {
        if (box_collider.bounds.Intersects(box_collider_colliding.bounds))//new hit
        {
            //Debug.Log("Hit");
            _client.Send("/hit");
        }
        else if (!box_collider.bounds.Intersects(box_collider_colliding.bounds))
        {
           
        }
    }
    void OnDestroy()
    {
        _client?.Dispose();
        _client = null;
    }
}
