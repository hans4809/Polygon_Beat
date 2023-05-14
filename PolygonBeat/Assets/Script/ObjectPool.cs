using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ObjectInfo
{
    public GameObject goPrefab;
    public int count;
    public Transform tfPoolParent;

}
public class ObjectPool : MonoBehaviour
{
    [SerializeField] ObjectInfo[] objectInfo = null;

    public Queue<GameObject> groundQueue = new Queue<GameObject>();

    public static ObjectPool instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        groundQueue = InsertQueue(objectInfo[0]);
    }

    // Update is called once per frame
    Queue<GameObject> InsertQueue(ObjectInfo p_objectInfo)
    {
        Queue<GameObject> queue = new Queue<GameObject>();
        for(int i = 0; i< p_objectInfo.count; i++) { 
            GameObject clone = Instantiate(p_objectInfo.goPrefab, transform.position, Quaternion.identity);
            clone.SetActive(false);
            if(p_objectInfo.tfPoolParent != null)
            {
                clone.transform.SetParent(p_objectInfo.tfPoolParent);
            }
            else
            {
                clone.transform.SetParent(this.transform);
            }
            queue.Enqueue(clone);
        }
        return queue;
    }
}
