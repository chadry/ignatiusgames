using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controlador : MonoBehaviour {

    private Rigidbody2D rb2d;//física del personaje
    public float velocidad = 10f;//velocidad movimiento
    public float salto = 15f;//altura salto
    private bool enSuelo = true;//estado del personaje(si toca suelo)
    public Transform comprobadorSuelo;//objeto comprobador de suelo creado en pies del personaje
    private float comprobadorRadio = 0.15f;//radio del comprobador
    public LayerMask mascaraSuelo;//capa a la que pertenece el suelo
    private bool dobleSalto = false;//capacidad para doble salto
    public bool talentoDobleSalto = true;//CAPACIDAD MANUAL PARA DOBLE SALTO
    public float velocidadDash = 40f;//velocidad dash
    public float tiempoDash = 0.1f;//tiempo que dura el dash
    private float inDash;//tiempo que queda en el dash
    public float cooldownDash = 1.5f;//cooldown del dash
    private float timeLeftDash;//cooldown restante del dash
    private bool dashR; //dash derecha
    private bool dashL; //dash izquierda
    public Text textoDash;//texto ingame del cooldown del dash

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();//asignacion del metodo getcomponent al atributo rb2d
    }

    void Start () {
	}

    private void FixedUpdate()
    {
        //comprobador suelo y doble salto
        enSuelo = Physics2D.OverlapCircle(comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);
        if (talentoDobleSalto && enSuelo)
        {
            dobleSalto = true;
        }
    }

    void Update () {
        //salto y doble salto
        rb2d.velocity = Vector2.up* rb2d.velocity.y;
        if ((enSuelo || dobleSalto) && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0)))
        {
            SoundSystem.instance.PlayJump();
            rb2d.velocity = new Vector2(rb2d.velocity.x, salto);
            if (dobleSalto && !enSuelo)
            {
                dobleSalto = false;
            }
        }

        //movimiento derecha
        if (Input.GetAxis("Horizontal") > 0)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                rb2d.velocity = new Vector2(velocidad * Input.GetAxis("Horizontal"), rb2d.velocity.y);
            }
            transform.localScale = new Vector3(1, 1, 1);
            //if (transform.rotation.y != 0)
            //{
            //    transform.Rotate(0, -180, 0);
            //}
        }

        //movimiento izquierda
        if (Input.GetAxis("Horizontal") < 0)
        {
                if (Input.GetAxis("Horizontal") < 0)
                {
                    rb2d.velocity = new Vector2(velocidad * Input.GetAxis("Horizontal"), rb2d.velocity.y);
                }
            transform.localScale = new Vector3(-1, 1, 1);
            //if (transform.rotation.y == 0)
            //{
            //    transform.Rotate(0, 180, 0);
            //}
        }

        //dash
        if (inDash > 0 && dashR)
        {
            rb2d.velocity = Vector2.right * velocidadDash;
            timeLeftDash = cooldownDash;
        }
        if (inDash > 0 && dashL)
        {
            rb2d.velocity = Vector2.left * velocidadDash;
            timeLeftDash = cooldownDash;
        }

        //condiciones dash
        if (inDash >= 0)
        {
            inDash -= Time.deltaTime;
        }
        if (timeLeftDash > 0)
        {
            timeLeftDash -= Time.deltaTime;
            if (timeLeftDash < 0)
            {
                timeLeftDash = 0;
                dashL = false;
                dashR = false;
            }
        }
        if (timeLeftDash == 0 && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button5)))
        {
            SoundSystem.instance.PlayDash();
            inDash = tiempoDash;
            dashR = true;
        }
        if (timeLeftDash == 0 && (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Joystick1Button4)))
        {
            SoundSystem.instance.PlayDash();
            inDash = tiempoDash;
            dashL = true;
        }
        textoDash.text = "Cooldown Dash: "+timeLeftDash;




    }

}
