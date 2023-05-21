using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraAnim : MonoBehaviour
{
    Vector3 initPos;
    float timer;
    [SerializeField]
    float speed = 0.001f;
    void Start()
    {
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * speed;
        transform.position = new Vector3(timer, initPos.y, initPos.z);
    }
}
