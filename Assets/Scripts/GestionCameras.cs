using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCameras : MonoBehaviour
{
    public GameObject camSuiviSora;
    public GameObject camSurvol;

    // Start is called before the first frame update
    void Start()
    {
        //Activer la cam�ra de suivi au d�part du jeu
        camSuiviSora.SetActive(true);
        camSurvol.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Activer la cam�ra de suivi en appuyant sur la touche 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            camSuiviSora.SetActive(true);
            camSurvol.SetActive(false);
        }

        //Activer la cam�ra de survol en appuyant sur la touche 2
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            camSuiviSora.SetActive(false);
            camSurvol.SetActive(true);
        }
    }
}
