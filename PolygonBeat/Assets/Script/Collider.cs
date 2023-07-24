using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            DataManager.singleTon.wholeGameData._coin++;
            Managers.Sound.Play("Sounds/SFX/Coin");
            DataManager.singleTon.jsonManager.Save<DataDefine.WholeGameData>(DataManager.singleTon.wholeGameData);
            Managers.Resource.Destroy(other.gameObject);
        }
    }
}
