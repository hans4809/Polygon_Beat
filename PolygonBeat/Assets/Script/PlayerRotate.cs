using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static Unity.VisualScripting.AnnotationUtility;

public class PlayerRotate : MonoBehaviour
{  
    public Vector3 rotation;
    public Vector3 parentPosition;
    public Vector3 childPosition;
    public List<GameObject> parentObject;
    public GameObject childObject;
    [SerializeField][Range(1f, 100f)] float rotateSpeed = 50f;
    float time = 0f;
    void SwapParent(GameObject childObject, GameObject preParentObject, GameObject nextParentObject)
    {
        nextParentObject.transform.SetParent(null);
        nextParentObject.transform.localEulerAngles = Vector3.zero;
        childObject.transform.SetParent(nextParentObject.transform);
        preParentObject.transform.SetParent(childObject.transform);
        //childObject.transform.parent.transform.position = parentPosition;
    }

    void Start()
    {
        parentObject[0].transform.SetParent(null);
        childObject.transform.SetParent(parentObject[0].transform);
        //parentPosition = childObject.transform.parent.transform.position;
        rotation = childObject.transform.parent.transform.localEulerAngles;
    }
    void Update()
    {
        rotation = Vector3.Lerp(new Vector3(0,0,0), new Vector3(0,0,-90), time);
        childObject.transform.parent.transform.localEulerAngles = rotation;
        time += Time.deltaTime * rotateSpeed;
        if (time > 1f)
        {
            time = 0f;
            if (childObject.transform.parent == parentObject[0].transform)
            {
                SwapParent(childObject, parentObject[0], parentObject[1]);
            }
            else if (childObject.transform.parent == parentObject[1].transform)
            {
                SwapParent(childObject, parentObject[1], parentObject[2]);
            }
            else if (childObject.transform.parent == parentObject[2].transform)
            {
                SwapParent(childObject, parentObject[2], parentObject[3]);
            }
            else if (childObject.transform.parent == parentObject[3].transform)
            {
                SwapParent(childObject, parentObject[3], parentObject[0]);
            }
        }
            
    }
}
