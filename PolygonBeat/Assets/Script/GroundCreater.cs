using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GroundCreater : MonoBehaviour
{
    public AnalyzeExample analyzeExample;
    public List<GameObject> myGameObject;
    public Transform transformParent;
    // Start is called before the first frame update
    private void CreateObject(GameObject gameObject, string name, Vector3 vector3)
    {
        GameObject obj = Instantiate(gameObject, vector3, Quaternion.identity, transformParent);
        obj.name = name;
    }

    void Start()
    {
        for( int i = -10; i <= analyzeExample.beats.Count; i++)
        {
            CreateObject(myGameObject[0], i.ToString(), new Vector3(i, 0, 0));
        }
        CreateObject(myGameObject[1], "flag", new Vector3((int)analyzeExample.beats.Count / 2, 0.6f, 0));
    }


    // Update is called once per frame
    void Update()
    {
    }
}
