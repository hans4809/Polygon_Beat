using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinUpdate : MonoBehaviour
{

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Coin")
        {
            DataManager.singleTon.wholeGameData._coin++;
            DataManager.singleTon.jsonManager.Save(DataManager.singleTon.wholeGameData);
            other.gameObject.SetActive(false);
        }
        if(other.gameObject.tag == "SavePoint")
        {

        }
    }
}
