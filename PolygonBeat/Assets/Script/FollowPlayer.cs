using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] PlayerRotate playerRotate;
    [SerializeField][Range(-5f, 5f)] float xPosition = 1f;
    // Start is called before the first frame update
    void Start()
    {
        playerRotate = FindObjectOfType<PlayerRotate>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerRotate.GetPlayer().transform.position + new Vector3(xPosition, -playerRotate.GetPlayer().transform.position.y, -10f);
    }
}
