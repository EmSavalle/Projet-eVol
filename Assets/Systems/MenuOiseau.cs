﻿using FYFY;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuOiseau : FSystem
{
    public static MenuOiseau instance;
    public GameObject canvas;
    public GameObject menu;
    public GameObject panel;
    public bool started = false;
    public int menuMoveDistance = 5;
    public int nbEspece = 0;
    public float widthPanel = 0;
    public List<GameObject> listOiseauPanel = new List<GameObject>();
    public GameObject OiseauPanelBluePrint;
    public Vector3 initPositionPanel;
    private Family _espece = FamilyManager.getFamily(new AllOfComponents(typeof(Espece)));
    private Family _player = FamilyManager.getFamily(new AllOfComponents(typeof(GameVariables)));
    public MenuOiseau()
    {
    }
    public int move;

    // Use this to update member variables when system pause. 
    // Advice: avoid to update your families inside this function.
    protected override void onPause(int currentFrame)
    {
    }

    // Use this to update member variables when system resume.
    // Advice: avoid to update your families inside this function.
    protected override void onResume(int currentFrame)
    {
    }

    // Use to process your families.
    protected override void onProcess(int familiesUpdateCount)
    {
        if (!started)
        {
            instance = this;
            panel = GameObject.Find("PanelOiseau");
            OiseauPanelBluePrint = _player.First().GetComponent<GameVariables>().prefabPanelOiseau;
            canvas = GameObject.Find("Canvas");
            menu = canvas.GetComponentInChildren<PanelScript>(true).gameObject;

            //widthPanel = ((RectTransform)OiseauPanelBluePrint.transform).rect.width;
            widthPanel = 6;
            Debug.Log("Width");
            Debug.Log(widthPanel);
            started = true;
            initPositionPanel = new Vector3(-(GameObject.FindGameObjectWithTag("PanelOiseau").transform.position.x/2), -(GameObject.FindGameObjectWithTag("PanelOiseau").transform.position.y / 2), 0);
        }
        if(nbEspece < _espece.Count)
        {
            updateMenu();
        }
    }

    private void updateMenu()
    {
        if (nbEspece != 0)
        {
            foreach (GameObject go in listOiseauPanel)
            {
                GameObject.Destroy(go);
            }
            listOiseauPanel.Clear();
        }
        for(int i = 0; i < _espece.Count;i++)
        {
            GameObject g = GameObject.Instantiate(OiseauPanelBluePrint, GameObject.FindGameObjectWithTag("PanelOiseau").transform);

            g.transform.position = initPositionPanel;
            g.transform.Translate(new Vector3(widthPanel * i, 0, 0));
            Debug.Log("X pos");
            Debug.Log(g.transform.position.x);
            Debug.Log(widthPanel * i - (GameObject.FindGameObjectWithTag("PanelOiseau").transform.position.x / 2));
            foreach (Text t in g.GetComponentsInChildren<Text>())
            {
                if(t.name == "BirdName")
                {
                    t.text = "Name : " + _espece.getAt(i).GetComponent<Espece>().name;
                }
                if (t.name == "BirdPopulation")
                {
                    t.text = "Population : " + Convert.ToString(_espece.getAt(i).GetComponent<Espece>().population);
                }
            }
            listOiseauPanel.Add(g);

        }
        nbEspece = listOiseauPanel.Count;
    }

    public void onOpenMenu()
    {
        menu.SetActive(true);
    }
    public void onCloseMenu()
    {
        menu.SetActive(false);
    }
    public void moveMenuLeft()
    {
        menu.transform.Translate(new Vector2(-menuMoveDistance, 0));
    }
    public void moveMenuRight()
    {
        menu.transform.Translate(new Vector2(menuMoveDistance, 0));
    }
}
