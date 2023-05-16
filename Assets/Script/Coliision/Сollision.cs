using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Сollision : MonoBehaviour
{
    [SerializeField]
    private string[] tagOfOtherObjects;

    [SerializeField]
    private string nameOfObject;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(nameOfObject + " collision with " + other.gameObject.tag);

        for (int i = 0; i < tagOfOtherObjects.Length; i++)
        {
            if (other.gameObject.tag == tagOfOtherObjects[i])
            {
                gameObject.SetActive(false);
            }
        }

        if (gameObject.activeInHierarchy == false)
        {
            Debug.Log(nameOfObject + " set Active is false");
        }
    }
}
