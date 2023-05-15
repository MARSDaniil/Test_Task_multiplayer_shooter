using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletСollision : MonoBehaviour
{
    [SerializeField]
    private Transform firePoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("you shot and hit " + other.gameObject.tag);

        if(other.gameObject.tag == "Obstacle")
        {
            gameObject.SetActive(false);
        }

        if (gameObject.activeInHierarchy == false)
        {
            Debug.Log("Bullet set Active is false");
            //    gameObject.transform.position = firePoint.position;
        }
    }



}
