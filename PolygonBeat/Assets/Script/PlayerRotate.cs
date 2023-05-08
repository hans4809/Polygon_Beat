using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static Unity.VisualScripting.AnnotationUtility;

public class PlayerRotate : MonoBehaviour
{  
    public Vector3 rotation;
    public List<GameObject> parentObject;
    public Vector3 parentPosition;
    public GameObject childObject;
    [SerializeField][Range(1f, 100f)] float rotateSpeed = 50f;
    float time = 0f;
    void SwapParent(GameObject childObject, GameObject preParentObject, GameObject nextParentObject)
    {
        parentPosition.x += 1;
        nextParentObject.transform.SetParent(null);
        nextParentObject.transform.localEulerAngles = Vector3.zero;
        childObject.transform.SetParent(nextParentObject.transform);
        preParentObject.transform.SetParent(childObject.transform);
        childObject.transform.parent.SetLocalPositionAndRotation(new Vector3(parentPosition.x, 0.11f, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
        childObject.transform.SetLocalPositionAndRotation(new Vector3(-5, 5, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
    }
    void SetRotation(GameObject childObject)
    {
        for(int i=0; i < 3; i++)
            childObject.transform.GetChild(i).localEulerAngles = Vector3.zero;
    }
    void Start()
    {
        parentObject[0].transform.SetParent(null);
        childObject.transform.SetParent(parentObject[0].transform);
        rotation = childObject.transform.parent.transform.localEulerAngles;
        parentPosition = childObject.transform.parent.localPosition;
    }
    void Update()
    {
        rotation = Vector3.Lerp(new Vector3(0,0,0), new Vector3(0,0,-90), time);
        childObject.transform.parent.transform.localEulerAngles = rotation;
        time += Time.deltaTime * rotateSpeed;
        if (time / rotateSpeed >= 1)
        {
            time = 0f;
            if (childObject.transform.parent == parentObject[0].transform)
            {
                SwapParent(childObject, parentObject[0], parentObject[1]);
                SetRotation(childObject);
            }
            else if (childObject.transform.parent == parentObject[1].transform)
            {
                SwapParent(childObject, parentObject[1], parentObject[2]);
                SetRotation(childObject);
            }
            else if (childObject.transform.parent == parentObject[2].transform)
            {
                SwapParent(childObject, parentObject[2], parentObject[3]);
                SetRotation(childObject);
            }
            else if (childObject.transform.parent == parentObject[3].transform)
            {
                SwapParent(childObject, parentObject[3], parentObject[0]);
                SetRotation(childObject);
            }
        }
            
    }
}
