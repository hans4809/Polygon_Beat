using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class CharacterChanger : MonoBehaviour
{
    public Button button;
    public Button button1;
    public RawImage image;
    public RawImage image1;

    void OnButton_Click()
    {
        image.gameObject.SetActive(true);
        image1.gameObject.SetActive(false);
    }

    void OnButton1Click()
    {
        image.gameObject.SetActive(false);
        image1.gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        button.onClick.AddListener(OnButton_Click);
        button1.onClick.AddListener(OnButton1Click);
    }
}