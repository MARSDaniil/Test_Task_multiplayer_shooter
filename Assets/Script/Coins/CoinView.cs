using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class CoinView : MonoBehaviourPun
{
    PhotonView viewCoin;
    void Start()
    {
        viewCoin = GetComponent<PhotonView>();
    }

    private void LateUpdate()
    {
        if(viewCoin.IsMine)
        {

        }
    }
}
