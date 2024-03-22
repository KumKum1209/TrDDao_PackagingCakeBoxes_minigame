using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public List<GameObject> frames;
    public List<GameObject> characs;
    public List<Level> levels;
    public int currentLv;
    public TextAsset currentText;

    public GameObject cake;
    public GameObject box;
    public GameObject[] candy;
    public bool IsWin = false;
    public bool IsPause = true;
    public int[,] data;

    private void Awake ()
    {
        if (instance == null)
        {
            instance = this;
        }
       
    }
    private void Update()
    {
        if(!IsPause)
        {
            if (cake != null && box != null)
            {
                if (Vector2.Distance(cake.transform.position, box.transform.position) < 0.01)
                {

                    if (currentLv + 1 < levels.Count)
                    {
                        levels[currentLv + 1].Islock = true;
                    }
                    levels[currentLv].IsComplete = true;
                    levels[currentLv].Star();
                    SetLevel();
                    IsWin = true;
                }
            }
        }
        
        
    }
    
    public void Init(TextAsset text)
    {
        IsWin=false;
        IsPause = false;
        LoadTextAsset(text);
        LoadMap();
    }
    void LoadTextAsset(TextAsset text)
    {
        currentText = text;
        string[] lines = text.text.Split('\n');
        data = new int[lines.Length, lines[0].Length];
        for (int i = 0; i < lines.Length; i++)
        {

            for (int j = 0; j < lines[i].Length; j++)
            {
                int.TryParse(lines[i][j].ToString(), out int value);
                data[i, j] = value;
            }
        }
    }
    void LoadMap()
    {
        int index = 0;
        int k = 0;
        for (int i = 2; i < 5; i++)
        {
            for (int j = 2; j < 5; j++)
            {
                switch (data[i, j])
                {
                    case 0:
                        cake = Instantiate(characs[0], frames[index].transform, false);
                        cake.GetComponent<Cake>().posx = i;
                        cake.GetComponent<Cake>().posy = j;
                        break;
                    case 1:
                        box = Instantiate(characs[1], frames[index].transform, false);
                        box.GetComponent<Box>().posx = i;
                        box.GetComponent<Box>().posy = j;
                        break;

                    case 2:
                        candy[k] = Instantiate(characs[2], frames[index].transform, false);
                        k++;
                        break;

                }
                
                index++;
            }
        }
    }
    public void ReLoadMap()
    {
        Destroy(cake);
        Destroy(box);
        foreach(GameObject candy in candy)
        {
            Destroy(candy);
        }
    }
    public void SetLevel()
    {
        foreach(Level lv in levels)
        {
            if(lv.Islock)
            {
                if(lv.locked != null)
                {
                    lv.locked.SetActive(false);
                }             
                if(lv.IsComplete)
                {
                    lv.Star();
                }
            }
        }
    }
}
