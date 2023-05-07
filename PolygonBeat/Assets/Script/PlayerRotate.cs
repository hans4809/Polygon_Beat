using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static Unity.VisualScripting.AnnotationUtility;

public class PlayerRotate : MonoBehaviour
{
    Quaternion aRotation = Quaternion.Euler(new Vector3(0, 0, 0));
    public Vector3 parentPosition;
    public Vector3 childPosition;
    public GameObject parentObject1;
    public GameObject childObject;
    public GameObject parentObject2;
    public GameObject parentObject3;
    public GameObject parentObject4;
    [SerializeField][Range(1f, 100f)] float rotateSpeed = 50f;
    void SwapParent(GameObject childObject, GameObject preParentObject, GameObject nextParentObject)
    {
        nextParentObject.transform.SetParent(null);
        childObject.transform.SetParent(nextParentObject.transform);
        //childPosition = childObject.transform.localPosition;
        preParentObject.transform.SetParent(childObject.transform);
        parentPosition = childObject.transform.parent.localPosition;
        Debug.Log(parentPosition);
        childObject.transform.parent.SetLocalPositionAndRotation(new Vector3(parentPosition.x, 0.08f, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
    }

    void Start()
    {
        parentObject1.transform.SetParent(null);
        childObject.transform.SetParent(parentObject1.transform);
        aRotation = childObject.transform.parent.transform.rotation;
    }
    void Update()
    {
        if ( (int)Time.time % 4 == 1 && childObject.transform.parent == parentObject1.transform)
        {
            SwapParent(childObject, parentObject1, parentObject2);
        }
        else if ((int)Time.time % 4 == 2 && childObject.transform.parent == parentObject2.transform)
        {
            SwapParent(childObject, parentObject2, parentObject3);
        }
        else if ((int)Time.time % 4 == 3 && childObject.transform.parent == parentObject3.transform)
        {
            SwapParent(childObject, parentObject3, parentObject4);
        }
        else if ((int)Time.time % 4 == 0 && childObject.transform.parent == parentObject4.transform)
        {
            SwapParent(childObject, parentObject4, parentObject1);
        }
        aRotation = aRotation * Quaternion.Euler(new Vector3(0, 0, -90) * Time.deltaTime * rotateSpeed);
        childObject.transform.parent.transform.rotation = aRotation;
    }
}
