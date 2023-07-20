using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CoinCount : MonoBehaviour
{
    public CoinCount Instance;
    public TextMeshProUGUI tmpUgui;
    public TMP_Text tmp_Text;
    float coin;
    // Start is called before the first frame update
    void Start()
    {
        CoinCounting();
    }

    public void CoinCounting()
    {
        tmp_Text.text = ": " + DataManager.singleTon.wholeGameData._coin.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        CoinCounting();
    }
}
