using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] PlayerRotate playerRotate;
    void Start()
    {
        playerRotate = FindObjectOfType<PlayerRotate>();
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Cinemachine.CinemachineVirtualCamera>().Follow = playerRotate.GetPlayer().transform;
        //this.GetComponent<Cinemachine.CinemachineVirtualCamera>().LookAt = playerRotate.GetPlayer().transform;
    }
}
