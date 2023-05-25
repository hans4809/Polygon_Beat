using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinUpdate : MonoBehaviour
{
    [SerializeField] GameObject myGameObject;
    WholeGameData wholeGameData;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Coin")
        {
            //wholeGameData.coin++;
            other.gameObject.SetActive(false);
        }
    }
}
