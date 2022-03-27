using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTerrain : MonoBehaviour
{
    
    
    bool grounded = false;

    void Start()
    {
       // player = gameObject.GetComponentInParent<MovJogador>();

    }



  private void OnTriggerStay(Collider col)

   {       
            grounded = true;  
    }


   private void OnTriggerExit(Collider col)

    {
       grounded = false;
    }
}
