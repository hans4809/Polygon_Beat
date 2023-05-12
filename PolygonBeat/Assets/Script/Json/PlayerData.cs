using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public Vector3 playerSavePosition;
    public int playerCoin;

    public PlayerData()
    {
        playerSavePosition = Vector3.zero;
        playerCoin = 0;
    }
    public PlayerData(Vector3 player_save_position)
    {
        playerSavePosition = player_save_position;
        playerCoin = 0;
    }
    public PlayerData(Vector3 player_save_position, int player_coin)
    {
        playerSavePosition = player_save_position;
        playerCoin = player_coin;
    }

}

