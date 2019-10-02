using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapperMenu : MonoBehaviour {
	// Update is called once per frame
	public void onLoadGameClick() {

        SceneLoaderSystem.instance.onLoadGame();
		
	}
    public void onOpenMenu()
    {
        MenuOiseau.instance.onOpenMenu();
    }
    public void onCloseMenu()
    {
        MenuOiseau.instance.onCloseMenu();
    }
    public void onMovingMenuLeft()
    {
        MenuOiseau.instance.moveMenuLeft();
    }
    public void onMovingMenuRight()
    {
        MenuOiseau.instance.moveMenuRight();
    }
}
