using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchPlayer : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    //private Animation anim;
    private GameObject Player; 
    public GameObject CanvasVida;

    public float health = 100;

    public bool isDead = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        CanvasVida = GameObject.FindGameObjectWithTag("Canvas");
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isDead == false){
            //se a distancia do Candy for menor que 2, ele começa a atacar o jogador
            if(Vector3.Distance(transform.position,Player.transform.position) < 3f)
            {
                attackCandy();
            }
            //verifica se a vida é menor ou igual a zero e elina o Candy 
             agent.SetDestination(GameObject.Find("Player").transform.position);
        } else if (isDead == true){
            Die();
        }
    }

    //aqui o doce irá atacar o jogador se destruindo e perdendo dano
    public void attackCandy(){
        CanvasVida.GetComponent<LifePlayer>().health -= 7f;
        Destroy(gameObject);
        //adiciona Dano de pontuação 
    }

    public void Die(){
        Destroy(gameObject,1);
    }
    public void Hurt (float hp){
        health -= hp;
    }

    private void OnTriggerEnter(Collider other) {
         if (other.tag == "Trap")
        {
            isDead = true;
        }
        
    }
}
