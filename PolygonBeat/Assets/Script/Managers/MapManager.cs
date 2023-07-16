using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    CreateGroundByJson createGround;
    // Start is called before the first frame update
    void Start()
    {
        createGround = FindObjectOfType<CreateGroundByJson>();
    }

    // Update is called once per frame
    //public void OnUpdate()
    //{
    //    if(createGround.ground.Count == 0)
    //    {
    //        return;
    //    }
    //    else
    //    {
    //        for (int i = 0; i < createGround.ground.Count; i++)
    //        {
    //            if (createGround.ground[i].transform.position.x < Camera.main.transform.position.x - 30)
    //            {
    //                Managers.Resource.Destroy(createGround.ground[i]);
    //            }
    //        }
    //    }
    //}
}
