using UnityEngine;
using FYFY;
using System;

public class GestionEnvironnement : FSystem
{
    //Statistiques reproduction
    private float dampening;//Se multiplie au facteur des specificites et caracteres pour limiter la vitesse
    //Statistiques mutations
    private int propagationCaractereBase = 5;//%en plus par génération
    private float lastTimeSinceGen;
    private int timeBetweenGen;
    private Family __environnement = FamilyManager.getFamily(new AllOfComponents(typeof(Environnement)));
    private Family _player = FamilyManager.getFamily(new AllOfComponents(typeof(GameVariables)));
    public GestionEnvironnement()
    {
        lastTimeSinceGen = 0f;
        timeBetweenGen = 5;
        dampening = 0.25f;
    }
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
        if(Time.time > timeBetweenGen + lastTimeSinceGen)
        {
            _player.First().GetComponent<GameVariables>().generation += 1;
            lastTimeSinceGen = Time.time;
            evolution();
        }
	}
    public void evolution()
    {
        foreach (GameObject env in __environnement)
        {
            Environnement envir = env.GetComponent<Environnement>();
            foreach (Espece e in envir.especes)
            {
                reproductionAndDeath(envir, e);
            }

        }
    }


    public void reproductionAndDeath(Environnement env, Espece esp)
    {
        float rate = esp.reproductionRate;
        Specificite[] dim = env.specificites;
        Caractere[] augm = esp.caractere;
        /*Specificite[] dim = { };
        Array.Copy(env.specificites,dim,env.specificites.Length);
        Caractere[] augm = { };
        Array.Copy(esp.caractere, augm, esp.caractere.Length);*/
        foreach (Specificite d in dim)
        {
            foreach(Caractere a in augm)
            {
                if(Array.Exists(d.counter, x => x == a))
                {
                    rate =rate - d.facteur* dampening + a.facteur* dampening;
                    break;
                }
                else
                {
                    rate -= d.facteur* dampening;
                }
            }
        }
        foreach (Caractere a in augm)
        {
            if (a.type == "Reproduction")
            {
                rate += a.facteur* dampening;
            }
        }
        esp.population = Convert.ToInt64(esp.population * rate);
        Debug.Log("Rate / Pop");
        Debug.Log(rate);
        Debug.Log(esp.population);
    }
}