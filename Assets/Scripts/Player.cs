using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.position += Vector3.right * horizontal * speed * Time.deltaTime;
    }
}
