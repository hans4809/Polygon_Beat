using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Animator hitAnimator = null;
    string hit = "Hit";

    public void HitEffect()
    {
        hitAnimator.SetTrigger(hit);
    }
    void Start()
    {
        hitAnimator = GameObject.Find("HitEffect").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
