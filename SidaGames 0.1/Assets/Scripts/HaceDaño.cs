using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaceDaño : MonoBehaviour {

    //cuando un objeto con tag "Player" entra en el trigger, llama al metodo Hit del Personaje
    private void OnTriggerStay2D(Collider2D collider)
    {
            if (collider.CompareTag("Player"))
            {
            SoundSystem.instance.PlayHit();
            Personaje.instance.Hit();
            }
    }
}
