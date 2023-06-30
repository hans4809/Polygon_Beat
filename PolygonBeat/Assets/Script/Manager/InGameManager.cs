using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] CreateGroundByJson createGroundByJson;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            DataManager.singleTon.wholeGameData._coin++;
            DataManager.singleTon.jsonManager.Save(DataManager.singleTon.wholeGameData);
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "SavePoint")
        {
            DataManager.singleTon.saveData.savePoint = createGroundByJson.savePosition;
        }
    }
    void Start()
    {
        createGroundByJson = FindAnyObjectByType<CreateGroundByJson>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
