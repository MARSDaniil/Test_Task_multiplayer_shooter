using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun; 
public class PlayerFire : MonoBehaviourPun
{
    PhotonView view;


    public GameObject BulletsParent;

    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private GameObject bulletPrefab;

    public float bulletForce;
    public List<GameObject> bulletsList;

    private List<PhotonRigidbody2DView> rbPhoton;
    public Button fireBotton;

    // Start is called before the first frame update
    void Start()
    {

       
        bulletsList = new List<GameObject>();

       
        FindItemInChild();

        fireBotton = GameObject.FindGameObjectWithTag("FireBotton").GetComponent<Button>();
        fireBotton.onClick.AddListener(Shoot);


        view = GetComponent<PhotonView>();
    }


    private void Update()
    {
     //   Debug.Log("fire point pos " + firePoint.transform.position);

        /*
        if(fireBotton != null)
        {
           Debug.Log("fire botton is founded");
        }
        */

       
    }

    public void Shoot()
    {

        if (view.IsMine)
        {
            bool freeBullet = false;

            //if there are free (non-active) bullets in the sheet,
            //it makes them active and shoots them
            //checking the whole sheet

            for (int i = 0; i < bulletsList.Count; i++)
            {
                if (!bulletsList[i].activeInHierarchy)
                {
                    bulletsList[i].transform.position = firePoint.transform.position;
                    bulletsList[i].transform.rotation = firePoint.transform.rotation;
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
                bulletsList.Add(PhotonNetwork.Instantiate(bulletPrefab.name, firePoint.transform.position, firePoint.transform.rotation));

                setForceToBullet(bulletsList.Count - 1);
            }
        }
    }

    //iterate through the child objects of the prefab, if a child object with the Items tag was added to the prefab at startup, then assign this object to the item variable
    void FindItemInChild()
    {
        foreach (Transform child in gameObject.transform) 
        {
            if (child.tag == "FirePoint")
            {
                firePoint = child;
                Debug.Log("I founded FirePoint");
            }
        }
    }


    //a rigidbody is taken from a bullet and its flight speed is set by adding force
    private void setForceToBullet(int index)
    {
        Rigidbody2D rb = bulletsList[index].GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.transform.right* bulletForce, ForceMode2D.Impulse);
    }
    
    public void click()
    {
        Debug.Log("U click to botton");
    }
}
