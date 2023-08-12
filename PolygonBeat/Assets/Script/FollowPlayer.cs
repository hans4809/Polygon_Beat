using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] PlayerRotate playerRotate;
    [SerializeField][Range(-5f, 5f)] public float xPosition = 2f;
    [SerializeField][Range(-5f, 5f)] public float yPosition = 2f;
    // Start is called before the first frame update
    void Start()
    {
        playerRotate = FindObjectOfType<PlayerRotate>();
    }

    // Update is called once per frame
    void Update()
    {
            transform.position = new Vector3(playerRotate.GetPlayer().transform.position.x + xPosition, yPosition, -10f);
    }
}
