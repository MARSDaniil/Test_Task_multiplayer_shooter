using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinsText : MonoBehaviour
{

    public TextMeshProUGUI coinsText;


    [SerializeField]
    private GameObject Player;
    private PlayerController playerController;

    void Start()
    {
        playerController = Player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
 //       Debug.Log(playerController.health);
        if (playerController.health > 0)
        {
            coinsText.text = "Coins: " + playerController.coinOfPlayer;
        }
        else
        {
            coinsText.gameObject.SetActive(false);
        }
    }
}
