using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Personaje : MonoBehaviour {

    public static Personaje instance;
    private bool isDead;
    private int vida = 3;
    public GameObject i3l;
    public GameObject i2l;
    public GameObject i1l;
    public Text textoInvencibilidad;
    public float tiempoInvencibilidad = 1f;
    private float invencibilidad;
    public bool accion;

    private void Awake()
    {
        if (Personaje.instance == null)
        {
            Personaje.instance = this;
        }
        else if (Personaje.instance != this)
        {
            Destroy(gameObject);
            Debug.LogWarning("Personaje instanciado por segunda vez");
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        accion = false;
        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            accion = true;
        }
        textoInvencibilidad.text = "Cooldown Daño: " + invencibilidad;
        if (invencibilidad > 0)
        {
            invencibilidad -= Time.deltaTime;
            if (invencibilidad < 0)
            {
                invencibilidad = 0;
            }
        }

        if (vida == 3)
        {
            i3l.SetActive(true);
            i2l.SetActive(false);
            i1l.SetActive(false);
        }
        if (vida == 2)
        {
            i3l.SetActive(false);
            i2l.SetActive(true);
            i1l.SetActive(false);
        }
        if (vida == 1)
        {
            i3l.SetActive(false);
            i2l.SetActive(false);
            i1l.SetActive(true);
        }
        if (vida == 0)
        {
            isDead = true;
        }
        if (isDead)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

	}

    //si no está en tiempo de invencibilidad, baja 1 la vida y reinicia el tiempo de invencibilidad
    public void Hit() {
        if (invencibilidad <= 0)
        {
            vida--;
            invencibilidad = tiempoInvencibilidad;
        }
    }
    private void OnDestroy()
    {
        if (Personaje.instance == this)
        {
            Personaje.instance = null;
        }
    }
}
