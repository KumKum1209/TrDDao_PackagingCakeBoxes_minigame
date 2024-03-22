using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Level : MonoBehaviour
{
    public int index;
    public TextAsset text;
    public bool Islock;
    public bool IsComplete = false;
    public GameObject locked;
    public Text textlv;
    public GameObject[] star;

    private void Start()
    {
        if (!Islock)
        {
            //textlv.text = (index + 1).ToString();
            locked.SetActive(true);
        }
    }
    private void Update()
    {
        
        if (Islock)
        {
            textlv.text = (index + 1).ToString();
            //locked.SetActive(false);
            if(IsComplete)
            {
                Star();
            }
            else
            {
                foreach (GameObject go in star)
                {
                    go.SetActive(false);
                }
            }
        }
        else
        {
            textlv.text = null;
            locked.SetActive(true);
        }
    }
    public void Star()
    {
        foreach (GameObject go in star)
        {
            go.SetActive(true);
        }
    }
    public void Init(TextAsset text)
    {
        if(Islock)
        {
            GameController.instance.currentLv = index;
            GameController.instance.Init(text);
            UIManager.instance.NextLevel();
        }
        
    }
}
