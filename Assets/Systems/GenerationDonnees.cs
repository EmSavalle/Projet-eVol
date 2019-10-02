using UnityEngine;
using FYFY;

public class GenerationDonnees : FSystem {

    public GenerationDonnees()
    {
        GameObject player = GameObject.Find("Player");
        GameObject envs = GameObject.Find("Environnements");
        GameObject spec = GameObject.Find("Specificites");
        GameObject esps = GameObject.Find("Especes");
        GameObject carac = GameObject.Find("Caracteres");
        //Initialisation du premier environnement
        Caractere volant = new Caractere();
        volant.name = "Vol";
        volant.facteur = 3;
        volant.type = "Defense";
        volant.pourcentagePopulation = 100;
        Caractere plume = new Caractere();
        plume.name = "Plumes Colorées";
        plume.facteur = 1;
        plume.type = "Reproduction";
        plume.pourcentagePopulation = 100;

        Espece pigeon = new Espece();
        pigeon.name = "Pigeon";
        pigeon.population = 10;
        pigeon.reproductionRate = 1.15f;
        pigeon.caractere.SetValue(volant, 0);

        Specificite predateur = new Specificite();
        predateur.name = "Lion";
        predateur.facteur = 3;
        predateur.counter.SetValue(volant, 0);
        predateur.type = "Mortalite";
        Environnement premier = new Environnement();
        premier.name = "Plaine tranquille";
        premier.specificites.SetValue(predateur, 0);
        premier.especes.SetValue(pigeon, 0);
        Debug.Log("Done");
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
	}
}