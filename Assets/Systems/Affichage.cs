using UnityEngine;
using FYFY;
using UnityEngine.UI;
using System;

public class Affichage : FSystem
{
    private Family _especes = FamilyManager.getFamily(new AllOfComponents(typeof(Espece)));
    private Family _player = FamilyManager.getFamily(new AllOfComponents(typeof(GameVariables)));
    // Use this to update member variables when system pause. 
    // Advice: avoid to update your families inside this function.
    protected override void onPause(int currentFrame) {
	}

	// Use this to update member variables when system resume.
	// Advice: avoid to update your families inside this function.
	protected override void onResume(int currentFrame){
	}

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
        GameObject text = GameObject.Find("Affichage");
        Espece e = _especes.First().GetComponent<Espece>();
        string t = "";
        if (e)
        {
             t = Convert.ToString(e.name) + "  :  Population de" + Convert.ToString(e.population) + "oiseaux \n";
            Debug.Log(e.name);
        }
        else
        {
            t = "";
        }
        
        text.GetComponent<Text>().text = t;

        GameObject genCnt = GameObject.Find("GenCounter");
        if (_player.Count>0)
        {
            Debug.Log(_player.Count);
            genCnt.GetComponent<Text>().text = "Génération : " + Convert.ToString(_player.First().GetComponentInChildren<GameVariables>().generation);
        }
    }
}