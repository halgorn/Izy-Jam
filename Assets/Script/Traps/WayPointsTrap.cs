using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointsTrap : MonoBehaviour
{
   public GameObject [] waypoints;
   public int num = 0;

   public float minDist;
   public float speed;

   public bool rand = false;
   public bool go = true;

   public int cont;
   void Start(){
       cont=0;
   }

   void Update(){
       if(cont==100){
           go=false;
           cont=0;  
       }
       
       float dist = Vector3.Distance(gameObject.transform.position, waypoints[num].transform.position);
       if(go){
           if(dist > minDist)
           {
               Move();
           }
           else
            {
                if(!rand){
                    if(num+1 == waypoints.Length)
                    {
                        num = 0;
                    }
                    else
                    {
                        num++;
                        if(num==waypoints.Length){
                            go=false;
                        }
                    }
                }else{
                    num = Random.Range(0, waypoints.Length);
                }
           }
       }
   }

   public void Move(){
       gameObject.transform.LookAt(waypoints[num].transform.position);
       gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
   }

   private void OnTriggerEnter(Collider other) {
        
        
         if (other.tag == "Enemy")
        {   
            cont++;

        }
    }
}
