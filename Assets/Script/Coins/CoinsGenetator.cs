using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class CoinsGenetator : MonoBehaviourPun
{
  //  PhotonView view;


    [SerializeField]
    private float RightWallCoordinats;
    [SerializeField]
    private float TopWallCoordinats;
    private float deviationFromWall = 0.5f;
    private Vector3 generatedCoordinats;
    private Quaternion zeroRotation;

    [SerializeField]
    private float bottomTimeBorder;
    [SerializeField]
    private float upperTimeBorder;
    private float timeOfWait;

    [SerializeField]
    private int maxCoinInThisBattle;

    [SerializeField]
    private GameObject coinPrefab;

   
    
    [SerializeField]
    private List<GameObject> coinsList;

    
    
    private void Awake()
    {
        coinsList = new List<GameObject>();
        zeroRotation = new Quaternion(transform.rotation.w, transform.rotation.x, transform.rotation.y, transform.rotation.z);
        CoordinateGenerator();

    }

    private void Update()
    {

        setCoinToScene();
    }

    private void setCoinToScene()
    {


        bool freeBullet = false;


        for (int i = 0; i < coinsList.Count; i++)
        {
            if (!coinsList[i].activeInHierarchy)
            {
                CoordinateGenerator();
                coinsList[i].transform.position = generatedCoordinats;
                coinsList[i].transform.rotation = zeroRotation;
                coinsList[i].SetActive(true);
                freeBullet = true;

                break;
            }
        }
        
        if (!freeBullet && coinsList.Count < maxCoinInThisBattle)
        {
            CoordinateGenerator();
            coinsList.Add(PhotonNetwork.Instantiate(coinPrefab.name, generatedCoordinats, zeroRotation));
        }
   
    }

    private void CoordinateGenerator()
    {
        generatedCoordinats = new Vector3(
            Random.Range(-RightWallCoordinats + deviationFromWall, RightWallCoordinats- deviationFromWall),
            Random.Range(-TopWallCoordinats+ deviationFromWall, TopWallCoordinats- deviationFromWall),
            0
            );
    }





    private void WaitTimeGenetator()
    {
        timeOfWait = Random.Range(bottomTimeBorder, upperTimeBorder);
    }

    IEnumerator GenerateCoin()
    {

        yield return new WaitForSeconds(timeOfWait);
       
    }
}
