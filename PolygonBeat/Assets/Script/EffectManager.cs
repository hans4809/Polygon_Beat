using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Animator hitAnimator = null;
    [SerializeField] Animator perfectAnimator = null;
    [SerializeField] Animator missAnimator = null;
    [SerializeField] List<Sprite> groundGlow;
    [SerializeField] CreateGroundByJson createGroundByJson;
    string hit = "Hit";

    public void HitEffect(int position)
    {
        switch (createGroundByJson.ground[position].name)
        {
            case "2":
                createGroundByJson.ground[position].GetComponent<SpriteRenderer>().sprite = groundGlow[1];
                break;
            case "3":
                createGroundByJson.ground[position].GetComponent<SpriteRenderer>().sprite = groundGlow[2];
                break;
            case "4":
                createGroundByJson.ground[position].GetComponent<SpriteRenderer>().sprite = groundGlow[3];
                break;
            default:
                createGroundByJson.ground[position].GetComponent<SpriteRenderer>().sprite = groundGlow[0];
                break;
        }
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
        createGroundByJson = FindAnyObjectByType<CreateGroundByJson>();
        if (DataManager.singleTon.wholeGameData._currentSong == 0)
        {
            groundGlow.Add(Resources.Load<Sprite>("block/bg1/bg1_glow01"));
            groundGlow.Add(Resources.Load<Sprite>("block/bg1/bg1_glow02"));
            groundGlow.Add(Resources.Load<Sprite>("block/bg1/bg1_glow03"));
            groundGlow.Add(Resources.Load<Sprite>("block/bg1/bg1_glow04"));
        }
        else
        {
            groundGlow.Add(Resources.Load<Sprite>("block/bg2/bg2_glow01"));
            groundGlow.Add(Resources.Load<Sprite>("block/bg2/bg2_glow02"));
            groundGlow.Add(Resources.Load<Sprite>("block/bg2/bg2_glow03"));
            groundGlow.Add(Resources.Load<Sprite>("block/bg2/bg2_glow04"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
