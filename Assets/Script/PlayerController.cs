using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float moveInputHorizontal;   
    [SerializeField]
    private float moveInputVertical;

    [SerializeField]
    private Joystick joystick;

    private Rigidbody2D _rb;


    [SerializeField]
    private float valueHorizontalInput;
    [SerializeField]
    private float valueVerticalInput;



    //just look values

    [SerializeField]
    float input;


    float radius;
    float tang;


    public float _speed, angle;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        inputJoystickData();
        movePlayer();
        RotatePlayer();
    }

    private void inputJoystickData()
    {
        moveInputHorizontal = joystick.Horizontal;
        moveInputVertical = joystick.Vertical;
    }

    private void movePlayer()
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




}
