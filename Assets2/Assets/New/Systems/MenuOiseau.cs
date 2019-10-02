using FYFY;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuOiseau : FSystem
{
    public static MenuOiseau instance;
    public GameObject canvas;
    public GameObject menu;
    public int menuMoveDistance = 5;
    public MenuOiseau()
    {
        instance = this;
        canvas = GameObject.Find("Canvas");
        menu = canvas.GetComponentInChildren<PanelScript>(true).gameObject;
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
