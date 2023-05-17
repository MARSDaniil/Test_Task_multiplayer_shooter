using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class RotatePlayer : MonoBehaviourPun
{
    //setting of Photon

    PhotonView viewRotate;



    private Joystick joystick;

    [SerializeField]
    private float moveInputHorizontal;
    [SerializeField]
    private float moveInputVertical;

    private void Start()
    {
        joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();

        viewRotate = GetComponent<PhotonView>();
    }

    private void FixedUpdate()
    {
        InputJoystickData();

        if (viewRotate.IsMine)
        {
            PlayerRotate();
        }  

    }
    //rotation of the player's head in the direction of movement
    private void PlayerRotate()
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

    private void InputJoystickData()
    {
        moveInputHorizontal = joystick.Horizontal;
        moveInputVertical = joystick.Vertical;
    }
}
