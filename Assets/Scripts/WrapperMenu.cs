using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapperMenu : MonoBehaviour {
	// Update is called once per frame
	public void onLoadGameClick() {

        SceneLoaderSystem.instance.onLoadGame();
		
	}
    public void onMenuClick()
    {
        MenuOiseau.instance.onMenuClick();
    }
    /*public void onOpenMenu()
    {
        MenuOiseau.instance.onOpenMenu();
    }
    public void onCloseMenu()
    {
        MenuOiseau.instance.onCloseMenu();
    }*/
    public void onMovingMenuLeft()
    {
        MenuOiseau.instance.moveMenuLeft();
    }
    public void onMovingMenuRight()
    {
        MenuOiseau.instance.moveMenuRight();
    }
    public void closeDetailMenu()
    {
        MenuOiseau.instance.closeDetailMenu();
    }
    public void openDetailMenu()
    {
        MenuOiseau.instance.openDetailMenu(GetComponentInParent<ContainerEspece>().oiseau);
    }
}
