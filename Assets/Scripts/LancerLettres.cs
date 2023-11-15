using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancerLettres : MonoBehaviour
{
    /////////D�claration des variables/////////

    //Pour lancer les lettres ou les colis sous forme de projectiles
    public GameObject lettreProjectile; //R�f�rence au gameObject de la lettre 
    public GameObject colisProjectile; //R�f�rence au gameObject du colis
    public GameObject sacColis; //Les projectiles sortiront du sac � dos de Sora
    public float vitesseProjectile; 

    //public GameObject particulesLettre; //Pour g�n�rer des particules lorsque Sora lance les lettres 
    //public GameObject particulesCollision; //Cr�er des particules lorsque les lettres frappent un objet/NPC
    
    private bool peutLancer; // V�rifier si Sora peut effectivement lancer les items

    //Faire r�f�rence � Sora pour l'animator plus tard
    public GameObject soraRigidbody;

    void Start()
    {
        peutLancer = true;
    }

    // Update is called once per frame
    void Update()
    {
        //peutLancer sera true pour la deuxi�me partie de la remise lorsque Sora sera en mesure de voler jusqu'au bureau de poste pour ramasser les items

        //� AJOUTER POUR LA REMISE FINALE && peutLancer = true;

        //Lancer une lettre avec le bouton gauche de la souris
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Fonction pour lancer la lettre et g�rer les instances
            LancerLettre();            

            //Activer l'animation de lancer de Sora
            soraRigidbody.GetComponent<Animator>().SetBool("Lance", true);
        }

        //Lancer le colis avec le bouton droit de la souris
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            //Fonction pour lancer le colis et g�rer les instances
            LancerColis();

            //Activer l'animation de lancer de Sora
            soraRigidbody.GetComponent<Animator>().SetBool("Lance", true);
        }
    }

    void LancerLettre()
    {
        peutLancer = false;

        //Appeler la fonction pour activer le lancer au d�lai de 1 seconde
        Invoke("ActiverLancer", 0.1f);

        //Activer l'effet de particules au lancer des lettres ou des colis
        //particulesLettre.SetActive(true);

        //Jouer le son de lancer de lettre
        GetComponent<AudioSource>().Play();

        //Activer l'animation de lancer de Sora
        //soraRigidbody.GetComponent<Animator>().SetBool("Lance", true);

        //Cl�ner la lettre et le colis plus tard avec des instances 
        GameObject nouvelleLettre = Instantiate(lettreProjectile, sacColis.transform.position, sacColis.transform.rotation);
        nouvelleLettre.SetActive(true);

        //Mettre la vitesse qui a �t� donn�e dans l'inspector
        nouvelleLettre.GetComponent<Rigidbody>().velocity = sacColis.transform.forward * vitesseProjectile;
    }

    void LancerColis()
    {
        peutLancer = false;

        //Appeler la fonction pour activer le lancer au d�lai de 1 seconde
        Invoke("ActiverLancer", 0.1f);

        //Activer l'effet de particules au lancer des lettres ou des colis
        //particulesLettre.SetActive(true);

        //Jouer le son de lancer de lettre
        GetComponent<AudioSource>().Play();        

        //Cl�ner la lettre (et le colis plus tard) avec des instances 
        GameObject nouveauColis = Instantiate(colisProjectile, sacColis.transform.position, sacColis.transform.rotation);
        nouveauColis.SetActive(true);

        //Mettre la vitesse qui a �t� donn�e dans l'inspector
        nouveauColis.GetComponent<Rigidbody>().velocity = nouveauColis.transform.forward * vitesseProjectile;
    }

    void ActiverLancer()
    {
        peutLancer = true;

        //Activer les particules
        //particulesLettre.SetActive(false);
    }
    

}
