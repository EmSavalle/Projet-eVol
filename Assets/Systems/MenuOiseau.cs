using FYFY;
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
    public GameObject panelDetail;
    public bool started = false;
    public int menuMoveDistance = 5;
    public int nbEspece = 0;
    public float widthPanel = 0;
    public List<GameObject> listOiseauPanel = new List<GameObject>();
    public GameObject OiseauPanelBluePrint;
    public GameObject OiseauPanelBluePrintDetail;
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
        GameObject g = GameObject.FindGameObjectWithTag("PanelOiseau");
        if (!started)
        {
            instance = this;
            OiseauPanelBluePrint = _player.First().GetComponent<GameVariables>().prefabPanelOiseau;
            OiseauPanelBluePrintDetail = _player.First().GetComponent<GameVariables>().prefabPanelOiseauDetail;
            canvas = GameObject.Find("Canvas");
            menu = canvas.GetComponentInChildren<ObjectContainer>(true).menu;
            panel = canvas.GetComponentInChildren<ObjectContainer>(true).panel;

            //widthPanel = ((RectTransform)OiseauPanelBluePrint.transform).rect.width;
            widthPanel = 6;
            Debug.Log("Width");
            Debug.Log(widthPanel);
            started = true;
        }
        if (g)
        {
            initPositionPanel = new Vector3(-(GameObject.FindGameObjectWithTag("PanelOiseau").transform.position.x / 2), -(GameObject.FindGameObjectWithTag("PanelOiseau").transform.position.y / 2), 0);
            if (nbEspece < _espece.Count)
            {            
                updateMenu();
            }
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
            g.GetComponent<ContainerEspece>().oiseau = _espece.getAt(i).GetComponent<Espece>();
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
    public void openDetailMenu(Espece e)
    {
        if(panelDetail == null) { 
            panelDetail = GameObject.Instantiate(OiseauPanelBluePrintDetail, canvas.transform);
            panelDetail.transform.position = new Vector3(-(canvas.transform.position.x / 2), -(canvas.transform.position.y / 2), 0); ;
            foreach (Text t in panelDetail.GetComponentsInChildren<Text>())
            {
                if (t.name == "TextName")
                {
                    t.text = "Name : " + e.name;
                }
                if (t.name == "TextPopulation")
                {
                    t.text = "Population : " + Convert.ToString(e.population);
                }
                if (t.name == "TextEnvironnement")
                {
                    t.text = "Environnement :  a remplir";
                }
                if(t.name == "TextCaractere")
                {
                    string str = "Caractere : \n";
                    foreach(Caractere c in e.caractere)
                    {
                        str += "-" + c.name+"\n";
                        str += "\t Type : " +c.type + "\n";
                        str += "\t Facteur : " + Convert.ToString(c.facteur) + "\n"; 
                        str += "\t Propagation dans l'espece : " + Convert.ToString(c.pourcentagePopulation) + "\n";
                    }
                    t.text = str;
                }
            }
        }
    }
    public void closeDetailMenu()
    {
        GameObject.Destroy(panelDetail);
        panelDetail = null;
    }
    public void onMenuClick()
    {
        if (menu.activeSelf)
        {
            onCloseMenu();
        }
        else
        {
            onOpenMenu();
        }
    }
    public void onOpenMenu()
    {
        menu.SetActive(true);
        updateMenu();
    }
    public void onCloseMenu()
    {
        menu.SetActive(false);
    }
    public void moveMenuLeft()
    {
        panel.transform.Translate(new Vector2(-menuMoveDistance, 0));
    }
    public void moveMenuRight()
    {
        panel.transform.Translate(new Vector2(menuMoveDistance, 0));
    }
}
