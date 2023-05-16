using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    public int maxHealth = 10;
    [SerializeField]
    private float moveInputHorizontal;   
    [SerializeField]
    private float moveInputVertical;

    [SerializeField]
    private Joystick joystick;
    private Rigidbody2D _rb;
    [SerializeField]
    private GameObject beakPrefab;

    public TextMeshProUGUI coinsText;
    public int coinOfPlayer;
    public int health;



    void Start()
    {
        coinOfPlayer = 0;
        health = maxHealth;
        _rb = GetComponent<Rigidbody2D>();
    }



    private void FixedUpdate()
    {
        if (health > 0)
        {
            InputJoystickData();
            MovePlayer();
            RotatePlayer();
        }
        else
        {
            Death();
        }
    }

    //turn off player moving
    private void Death()
    {
        beakPrefab.SetActive(false);
        _rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        _rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        _rb.isKinematic = true;
    }
    private void InputJoystickData()
    {
        moveInputHorizontal = joystick.Horizontal;
        moveInputVertical = joystick.Vertical;
    }

    private void MovePlayer()
    {
        _rb.velocity = new Vector2(moveInputHorizontal * speed, moveInputVertical*speed); 
    }


    //rotation of the player's head in the direction of movement
    private void RotatePlayer()
    {
        if (moveInputHorizontal != 0 && moveInputVertical != 0)
        {
            if (moveInputHorizontal >= 0)
            {


                transform.rotation = Quaternion.AngleAxis(Mathf.Asin(moveInputVertical) * 180 / Mathf.PI, Vector3.forward);
            }
            else
            {
                transform.rotation = Quaternion.AngleAxis(Mathf.Asin(moveInputVertical) * 180 / Mathf.PI + 180, Vector3.back);
            }
        }    
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coinOfPlayer++;
            coinsText.text = "Coins: " + coinOfPlayer;
        }
        if(other.gameObject.tag == "Bullet")
        {
            health--;
        }
    }

}
