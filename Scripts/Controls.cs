using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public GameObject ball;
    Player ballObj;

    // Start is called before the first frame update
    void Start()
    {
        ballObj = ball.GetComponent<Player>();
    }

    public void goBack()
    {
        ballObj.setMovement(new Vector2(-1, 0));
    }
    public void goForward()
    {
        ballObj.setMovement(new Vector2 (1, 0));
    }

    public void goJump()
    {
        ballObj.Jumping();
    }
}
