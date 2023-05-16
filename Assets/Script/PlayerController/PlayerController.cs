using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviourPun
{
    //setting of Photon

    PhotonView view;



    //setting of player in Unity
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    public int maxHealth = 10;
    [SerializeField]
    private float moveInputHorizontal;   
    [SerializeField]
    private float moveInputVertical;

    
    private Joystick joystick;
    
    private Rigidbody2D _rb;
    [SerializeField]
    private GameObject beakPrefab;

    public int coinOfPlayer;
    public int health;



    void Start()
    {
        coinOfPlayer = 0;
        health = maxHealth;
        _rb = GetComponent<Rigidbody2D>();
        joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();
     

        view = GetComponent<PhotonView>();
    }



    private void FixedUpdate()
    {
        InputJoystickData();    
        if (view.IsMine)
        {
            if (health > 0)
            {
               
                MovePlayer();

            }
            else
            {
                Death();
            }
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


   


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coinOfPlayer++;

        }
        if(other.gameObject.tag == "Bullet")
        {
            health--;
        }
    }

}
