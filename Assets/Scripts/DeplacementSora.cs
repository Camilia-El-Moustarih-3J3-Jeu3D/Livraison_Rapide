using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


////////////////////////JE M'EXCUSE POUR LA REMISE BRISÉE :(////////////////////////

public class DeplacementSora : MonoBehaviour
{
    ///////////Déclaration des variables///////////
    
    ///Variables pour le personnage principal Sora
    public float vitesseAvantPerso; //La vitesse de déplacement de Sora
    public float vitesseHorizontalePerso; //La vitesse de rotation de Sora lorsque la souris est bougée
    public float vitesseVerticalePerso; //La vitesse de rotation de Sora lorsque la souris est bougée
    //Rigidbody rigidbodySora; //Référence au perso Principal pour éviter d'écrire toujours GetComponent.... etc. 

    //Variables pour les caméras
    public GameObject cameraSuiviSora; //La caméra qui suivra Sora tout au long du jeu
    //public Vector3 distanceCamera;
   // public bool curseurLock; //Afin de vérouiller le curseur

    //Variables pour les compteurs **** À définir bientôt ****
    public float tempsRestant; //Temps qu'il reste au joueur

    //Variables pour les sons 
    public AudioClip sonCollecteCollations;

    void Start()
    {
        //rigidbodySora = GetComponent<Rigidbody>();

        //Vérouiller le curseur dès le départ du jeu 
        //if (curseurLock) Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        //Afin de pouvoir faire tourner la caméra et le perso avec la souris
        //Droite et gauche
        float tournerVue = Input.GetAxis("Mouse X") * vitesseHorizontalePerso; 
        transform.Rotate(0f, tournerVue, 0f);

        //Fonction à arranger pour faire que Sora avance vers l'orientation de la caméra
        //OrienterSora();

        //cameraSuiviSora.transform.position = transform.position + distanceCamera;
        //cameraSuiviSora.transform.LookAt(transform.position);

        //***************** Haut et bas À ARRANGER ********************
        //float regarderHautBas = Input.GetAxis("Mouse Y") * vitesseVerticalePerso;
        //transform.Rotate(0f, 0f, regarderHautBas);

        //Récupérer les valeurs des axes vertical et horizontal pour pouvoir déplacer Sora
        float axeH = Input.GetAxisRaw("Horizontal");
        float axeV = Input.GetAxisRaw("Vertical");

        //Direction de Sora selon l'orientation de la souris



        //Vector3 orientation = cameraSuiviSora.transform.forward * axeV + cameraSuiviSora.transform.right * axeH;
        //orientation.y = 0;

        //if (orientation != Vector3.zero)
        //{
            //transform.forward = orientation;
            //GetComponent<Rigidbody>().velocity = (transform.forward * vitesseAvantPerso) + new Vector3(0, GetComponent<Rigidbody>().velocity.y, 0);
        //}
        

        //Déplacement de Sora avec normalize afin d'éviter un déplacement diagonal à vitesse exponentielle
        GetComponent<Rigidbody>().velocity = new Vector3(axeH, 0f, axeV).normalized * vitesseAvantPerso;

        ///////////// Gestions des animations de Sora /////////////
        //Si la vitesse/magnitude du personnage est plus grande que 0, l'animation de course de Sora devient vraie, sinon elle se remet à false
        if (GetComponent<Rigidbody>().velocity.magnitude > 0)
        {
            GetComponent<Animator>().SetBool("Course", true);
            GetComponent<Animator>().SetBool("Lance", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("Course", false);
        }
    }

    private void OnTriggerEnter(Collider ramasseCollations)
    {
        if (ramasseCollations.gameObject.tag == "Collations")
        {
            //Les collations vont disparaître
            Destroy(ramasseCollations.gameObject);

            //Ajouter du temps supplémentaire au joueur
            tempsRestant += 10;

            //Son de collecte sur les collations
            GetComponent<AudioSource>().PlayOneShot(sonCollecteCollations);
        }
    }

     //void OrienterSora() À ARRANGER
}
