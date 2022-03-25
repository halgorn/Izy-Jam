using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
     public GameObject Bullet;
        public GameObject spawn;
        public float speed = .5f;

        void Update()
        {

            turning();
             if (Input.GetKeyDown(KeyCode.Mouse0))
         {
             shootPlayer();

         }

        }

        void turning()
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            Vector2 direc = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

            transform.right = direc;


        }

       public void shootPlayer()
        {
            GameObject projectile = (GameObject)Instantiate(Bullet, spawn.transform.position, Quaternion.identity);
            projectile.transform.right = transform.right;

        }

}
