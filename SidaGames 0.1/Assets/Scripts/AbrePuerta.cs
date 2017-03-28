using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrePuerta : MonoBehaviour
{
    public GameObject puerta;
    public float rangoActivacion;
    public LayerMask mascaraPersonaje;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapCircle(transform.position, rangoActivacion, mascaraPersonaje) && Personaje.instance.accion)
        {
            SoundSystem.instance.PlayAccion();
            puerta.SetActive(!puerta.activeInHierarchy);
        }
    }
}
