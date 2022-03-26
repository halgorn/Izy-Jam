using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchPlayer : MonoBehaviour
{
    //public AudioClip somHit;
   // public GameObject CanvasVida;
    //public GameObject ScoreZombie;
    //public GameObject ScoreText;
    private UnityEngine.AI.NavMeshAgent agent;
    //private Animation anim;
    private GameObject Player;

    public float health = 100;

    public bool isDead = false;

    //public Text text;      
    //public int score;
    
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
       // ScoreZombie = GameObject.FindGameObjectWithTag("score_zombie");
       // CanvasVida = GameObject.FindGameObjectWithTag("Canvas");
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        if(isDead == false){
            //se a distancia do zombie for menor que 2, ele começa a atacar o jogador
            if(Vector3.Distance(transform.position,Player.transform.position) < 2f)
            {
                    attackZombie();
            }

            //verifica se a vida é menor ou igual a zero e elina o zombie
            if(health <= 0)
            {

                isDead = true;
                Die();
                //score += 1;
                //Debug.Log("score ="+score);
                
            }
             agent.SetDestination(GameObject.Find("Player").transform.position);
        }  
    }
    //aqui o doce irá atacar o jogador se destruindo e perdendo dano
    public void attackZombie(){
        //CanvasVida.GetComponent<HealthController>().health -= 0.3f;
        Destroy(this.gameObject,1);
        //CanvasVida.GetComponent<AudioSource>().PlayOneShot(somHit);
    }
    public void Die(){
        //CanvasVida.GetComponent<HealthController>().health -= 0.3f;
        Destroy(this.gameObject,1);
    }
    public void Hurt (float hp){
        health -= hp;
    }

    private void OnTriggerEnter(Collider other) {
         if (other.tag == "Caminhao")
        {
            //ScoreZombie.GetComponent<ScoreText>().scoreBool=true;
            Destroy(this.gameObject,1);
        }
    }
}
