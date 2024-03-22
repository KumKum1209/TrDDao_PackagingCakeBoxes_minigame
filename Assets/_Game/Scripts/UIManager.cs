using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public float time;
    public float retime = 46;
    public GameController game;
    public Text txttime;
    public GameObject lose;
    public GameObject htp;
    public GameObject complete;
    public GameObject level;
    public GameObject banner;
    public GameObject main;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Update()
    {

        if (!game.IsPause)
        {
            time -= Time.deltaTime;
            string formattedTime = FormatTime(Mathf.FloorToInt(time));

            txttime.text = formattedTime;
            if (game.IsWin)
            {
                complete.SetActive(true);
                main.SetActive(false);
                game.IsPause = true;
            }
            else
            if (time < 0 && !game.IsPause)
            {
                main.SetActive(false);
                lose.SetActive(true);
                game.IsPause = true;
            }
        }

    }
    public string FormatTime(int totalSeconds)
    {
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void Home()
    {

        game.IsPause = true;
        game.ReLoadMap();
        game.SetLevel();
        level.SetActive(true);
        main.SetActive(false);
        lose.SetActive(false);
        complete.SetActive(false);
    }
    public void Exit()
    {
        htp.SetActive(false);
    }
    public void BtnPlay()
    {
        banner.SetActive(false);
        level.SetActive(true);
    }
    public void NextLevel()
    {
        time = retime;
        level.SetActive(false);
        main.SetActive(true);
    }
    public void BtnNext()
    {
        game.currentLv++;
        if (game.currentLv < game.levels.Count)
        {
            var lv = game.levels[game.currentLv];
            time = retime;
          
            lv.textlv.text = (lv.index + 1).ToString();
            complete.SetActive(false);
            main.SetActive(true);
            game.ReLoadMap();
            game.SetLevel();
            //lv.Islock = true;

            //lv.locked.SetActive(false);
            game.Init(lv.text);
        }





    }
    public void BtnBack()
    {
        level.SetActive(false);
        banner.SetActive(true);
    }
    public void BtnReSet()
    {

        game.ReLoadMap();
        game.Init(game.currentText);
        time = retime;
        complete.SetActive(false);
        main.SetActive(true);
    }
    public void BtnHtp()
    {
        htp.gameObject.SetActive(true);
    }
}
