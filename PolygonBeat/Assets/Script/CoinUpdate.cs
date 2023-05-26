using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinUpdate : MonoBehaviour
{
    Define.WholeGameData wholeGameData;
    private int coinNum;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Coin")
        {
            coinNum++;
            other.gameObject.SetActive(false);
        }
    }
    public int GetCoinNum()
    {
        return coinNum;
    }

}
