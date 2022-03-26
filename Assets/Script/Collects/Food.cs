using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    // Start is called before the first frame update
   
    public GameObject  CanvasVida;
    void Start(){
        CanvasVida = GameObject.FindGameObjectWithTag("Canvas");
    }
    private void OnTriggerEnter(Collider other) {
         if (other.tag == "Player")
        {
            CanvasVida.GetComponent<LifePlayer>().health += 4f;
            Destroy(gameObject);

        }
        
    }
}
