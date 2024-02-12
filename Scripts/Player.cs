using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float ballSpeed = 160;
    private Rigidbody2D rb;
    private Vector2 vector;

    private int jumpNumber;
    public float jumpSpeed;

    private int collectedCoin = 0;
    public TextMeshProUGUI textMeshProUGUI;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        float hor = Input.GetAxis("Horizontal");
        vector = new Vector2(hor, 0);
        
        //if (Input.GetKeyDown(KeyCode.RightArrow)){
            //setMovement(new Vector2(1, 0));
        //}

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            setMovement(new Vector2(-1, 0));
        }

        //for jump as most 2 jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jumping();
        }
    }

    public void setMovement(Vector2 keyboard)
    {
        vector = keyboard;
        rb.AddForce(vector * ballSpeed);
    }

    private void FixedUpdate()
    {
        rb.AddForce(vector * 8);
    }

    public void Jumping()
    {
        if (jumpNumber < 2)
        {
            rb.velocity += new Vector2(0, jumpSpeed); //can use += or =
            jumpNumber++;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            transform.rotation = Quaternion.identity;
            jumpNumber = 0;
        }else if (collision.gameObject.tag == "Danger")
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene("Home");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            collectedCoin++;
            textMeshProUGUI.text = "Total Coin : " + collectedCoin.ToString();
            if(collectedCoin == 10)
            {
                SceneManager.LoadScene("Finished");
            }
        }
    }

}
