using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juego : MonoBehaviour {

    public static Juego instance;
    public Transform personaje;
    public GameObject lluvia;
    private bool noche;
    public Light sol;
    public Light[] lamps;

    private void Awake()
    {
        if (Juego.instance == null)
        {
            Juego.instance = this;
        }
        else if (Juego.instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
        
        transform.position = new Vector3(personaje.position.x, transform.position.y, -1f);
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

            if (transform.position.x < 0)
        {
            transform.position = new Vector3(0f, transform.position.y, -1f);
        }
        
                        if (transform.position.x > 53.52)
        {
            transform.position = new Vector3(53.52f, transform.position.y, -1f);
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            lluvia.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            if (noche)
            {
                sol.intensity = 1.30f;
                foreach (var lamp in lamps)
                {
                    lamp.intensity = 0;
                }
                noche = false;
            }
            else
            {
                sol.intensity = 0.1f;
                foreach (var lamp in lamps)
                {
                    lamp.intensity = 6.3f ;
                }
                noche = true;
            }
        }

    }
    private void OnDestroy()
    {
        if (Juego.instance == this)
        {
            Juego.instance = null;
        }
    }
}
