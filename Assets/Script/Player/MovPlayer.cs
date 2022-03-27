using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MovPlayer : MonoBehaviour
{
    //public GameObject botao;
    //protected Joystick  joystick;
   // protected JoyButton joybutton;

    public FixedJoystick movJoystick;
    Rigidbody rig;

    private Animator anim;
    public float speed = 5f;

    Vector3 forward;
    Vector3 right;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("No menu Start está com "+ rig.isKinematic);
        //joystick = FindObjectOfType<Joystick>();
       // joybutton = FindObjectOfType<JoyButton>();
        GetComponent<Rigidbody>().isKinematic = true;
        //rig.isKinematic = true;
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0,90,0)) * forward;
        anim = gameObject.GetComponent<Animator>();
    }

     void FixedUpdate()
    {
        
        if(Input.anyKey){
            Move();
            anim.SetBool("Run", true);
            anim.SetBool("Idle",false);
            anim.SetBool("Hit",false);
        }else {
            anim.SetBool("Idle",true);
            anim.SetBool("Run", false);
            anim.SetBool("Hit",false);
        }
         
        if(Input.GetKey(KeyCode.C)){
            //Instantiate(bomba, transform.position, transform.rotation);
            Attack();
        }
        
       // if(botao.GetComponent<JoyButton>().Pressed == true){
            speed = 10f;
       // }else{
           // speed = 5f;
       // }
    }
     public void Move(){

        var rigidbody = GetComponent<Rigidbody>();

        rigidbody.velocity = new Vector3(movJoystick.Horizontal *5f, rigidbody.velocity.y,movJoystick.Vertical * 5f);
        Vector3 direction = new Vector3(movJoystick.Horizontal * 5f, 0,movJoystick.Horizontal* 5f);
        Vector3 rightMovement = right * speed * Time.deltaTime * movJoystick.Horizontal;

        Vector3 upMovement = forward * speed * Time.deltaTime * movJoystick.Vertical;

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        transform.forward = heading;
        transform.position += rightMovement;
        transform.position +=upMovement;
    }

    public void Attack(){
        anim.SetBool("Hit",true);
        anim.SetBool("Run", false);
        anim.SetBool("Idle",false);
    }
     public void Die(){
        anim.SetBool("Hit",false);
        anim.SetBool("Run", false);
        anim.SetBool("Idle",false);
        anim.SetBool("Dead",true);
        Invoke("EndGame",2);
    }
    public void EndGame(){
        SceneManager.LoadScene("FimDeJogo");
    }
    private void OnTriggerEnter(Collider other) {
        
        if(other.gameObject.layer ==3){
            //Debug.Log("colidiu com a layer");
            GetComponent<Rigidbody>().isKinematic = true;
        }else{
           //Debug.Log("Parou de colidir com a layer");
            
        }
        if(other.tag == "Limite_chao"){
            SceneManager.LoadScene("FimDeJogo");
        }
        if(other.tag == "Final"){
            SceneManager.LoadScene("Vitoria");
        }

        if(other.tag == "Trap"){
            Die();
        }
        
        if (other.tag == "Caminho")
        {
            Debug.Log("Colidiu");
        }
        
    }

    private void OnTriggerExit(Collider other) {
        Debug.Log("Parou de colidir com a layer");
       GetComponent<Rigidbody>().isKinematic = false;
    }
   
}
