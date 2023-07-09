using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Animator hitAnimator = null;
    [SerializeField] Animator perfectAnimator = null;
    [SerializeField] Animator missAnimator = null;
    string hit = "Hit";

    public void HitEffect(int position)
    {
        hitAnimator.transform.localPosition = new Vector3(position, 0, 0);
        hitAnimator.SetTrigger(hit);
    }
    public void Perfect(int postion)
    {
        perfectAnimator.transform.localPosition = new Vector3(postion, 2, 0);
        perfectAnimator.SetTrigger(hit);
    }
    public void Miss(int postion)
    {
        missAnimator.transform.localPosition = new Vector3(postion, 2, 0);
        missAnimator.SetTrigger(hit);
    }
    void Start()
    {
        hitAnimator = GameObject.Find("Effect").GetComponent <Animator>();
        perfectAnimator = GameObject.Find("Perfect").GetComponent <Animator>();
        missAnimator = GameObject.Find("Miss").GetComponent <Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
