using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GroundCreater : MonoBehaviour
{
    public AnalyzeExample analyzeExample;
    public GameObject myGameObject;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        for( int i = 0; i < analyzeExample.beats.Count; i++)
        {
            GameObject ground;
            ground = Instantiate(myGameObject);
            string str = i.ToString();
            ground.name = str;
            ground.transform.position = new Vector3(i - 4.504f, 0, 0);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
       /* for (int i = 0; i < analyzeExample.beats.Count; i++)
        {
           .transform.Translate(new Vector2(-1, 0) * Time.deltaTime * speed);
        }*/
    }
}
