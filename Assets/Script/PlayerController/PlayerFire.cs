using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFire : MonoBehaviour
{
    public GameObject BulletsParent;

    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private GameObject bulletPrefab;

   

    public float bulletForce;
    public List<GameObject> bulletsList;
    
   
   

    private void Awake()
    {
        bulletsList = new List<GameObject>();

    }


    // Start is called before the first frame update
    void Start()
    {
       if(bulletPrefab == null)
        {
            Debug.Log("Prefab == 0");
        }

       if(firePoint == null)
        {
            Debug.Log("Point == 0");
        }

      
    }

   

    public void Shoot()
    {


        bool freeBullet = false;

        //if there are free (non-active) bullets in the sheet,
        //it makes them active and shoots them
        //checking the whole sheet

        for (int i = 0; i < bulletsList.Count; i++)
        {
            if(!bulletsList[i].activeInHierarchy)
            {
                bulletsList[i].transform.position = firePoint.position;
                bulletsList[i].transform.rotation = firePoint.rotation;
                bulletsList[i].SetActive(true);
                freeBullet = true;


                setForceToBullet(i);
                break;
            }
        }
        //if there are no inactive bullets, then a new one is created
        if (!freeBullet)
        {
           // bulletsList.Add(Instantiate((GameObject)Resources.Load("Prefab/Bullet"), firePoint.position, firePoint.rotation));
            bulletsList.Add(Instantiate(bulletPrefab, firePoint.position, firePoint.rotation));

            setForceToBullet(bulletsList.Count - 1);
        }
    }

    //a rigidbody is taken from a bullet and its flight speed is set by adding force
    private void setForceToBullet(int index)
    {
        Rigidbody2D rb = bulletsList[index].GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }
    
}
