using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LifePlayer : MonoBehaviour
{
    
    public GameObject Jogador;

    private Animator anim;
    public float health = 100;
    public float healthMax = 100;
    //public GameObject textScore;
    public Image healthBar;

    //public GameObject Score;
    //public int score;
    // Start is called before the first frame update
    void Start()
    {
        anim = Jogador.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
         //score = Score.GetComponent<ScoreText>().score;
            UpdateHealthBar(); 
            if(health <= 0){
                anim.SetBool("Dead",true);
                Invoke("EndGame", 3);
            }
    }

    private void UpdateHealthBar(){
        healthBar.fillAmount = health / healthMax;
    }
    public void EndGame(){
        SceneManager.LoadScene("FimDeJogo");
    }
}
