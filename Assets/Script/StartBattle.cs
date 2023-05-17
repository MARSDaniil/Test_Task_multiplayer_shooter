using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartBattle : MonoBehaviour
{
    [SerializeField]
    private GameObject BottonStartGame;

    public bool isBattleStart = false;
    // Start is called before the first frame update
    public void BattleStart()
    {
        isBattleStart = true;

        BottonStartGame.SetActive(false);
    }
}
