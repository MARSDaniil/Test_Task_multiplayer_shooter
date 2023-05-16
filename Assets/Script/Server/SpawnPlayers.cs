using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SpawnPlayers : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float RightWallCoordinats = 9;
    [SerializeField]
    private float TopWallCoordinats = 5;
    private Vector3 generatedCoordinats;

   
    private float deviationFromWall = 1f;
    // Start is called before the first frame update
    void Start()
    {
        CoordinateGenerator();
      
        PhotonNetwork.Instantiate(player.name, generatedCoordinats, Quaternion.identity);
    }

    
    private void CoordinateGenerator()
    {
        generatedCoordinats = new Vector3(
            Random.Range(-RightWallCoordinats + deviationFromWall, RightWallCoordinats - deviationFromWall),
            Random.Range(-TopWallCoordinats + deviationFromWall, TopWallCoordinats - deviationFromWall),
            0
            );
    }

}
