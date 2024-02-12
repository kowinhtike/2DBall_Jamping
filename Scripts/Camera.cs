using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform ball;
    public Vector2 vector;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        vector = ball.position;
        transform.position = new Vector3(vector.x, vector.y,-30);
    }
}
