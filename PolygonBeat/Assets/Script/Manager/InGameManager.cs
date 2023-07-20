using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            DataManager.singleTon.wholeGameData._coin++;
            DataManager.singleTon.jsonManager.Save(DataManager.singleTon.wholeGameData);
            other.gameObject.SetActive(false);
        }
    }
}
