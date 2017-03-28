using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accionable : MonoBehaviour {
    private bool activo;
    public GameObject referencia;
    public GameObject pelota;
    public LayerMask mascaraPersonaje;
    private bool bolaExiste;
    public Transform spawnPelotas;
    public GameObject texto;

	void Update () {
        if (Physics2D.OverlapCircle(transform.position, 0.5f, mascaraPersonaje) && Personaje.instance.accion)
        {
            if(!bolaExiste && referencia.activeInHierarchy)
            {
                Instantiate(pelota, spawnPelotas.position, new Quaternion(0,0,0,0));
                bolaExiste = true;
            }else if(bolaExiste && referencia.activeInHierarchy)
            {
                referencia.SetActive(false);
            }else if (!referencia.activeInHierarchy)
            {
                referencia.SetActive(true);
                bolaExiste = false;
            }

        }
        if (Physics2D.OverlapCircle(transform.position, 0.5f, mascaraPersonaje))
        {
            texto.SetActive(true);
        }else { texto.SetActive(false); }
        }
}
