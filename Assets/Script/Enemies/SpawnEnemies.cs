using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject Candie1;
    public GameObject Candie2;
    public GameObject Candie3;
    public GameObject Candie4;
    public int xPos;
    public int zPos;

    public float SpawnTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
         InvokeRepeating("Spawn", SpawnTime, SpawnTime);
    }

    // Update is called once per frame

    private void Spawn() {
       int random = Random.Range(1,4);

       xPos = Random.Range(1,50);
       zPos = Random.Range(1,31);
       Vector3 CandiePosition = new Vector3(xPos,1,zPos);
       if(random==1){
         Instantiate(Candie1,CandiePosition, transform.rotation * Quaternion.Euler(90f,40f,0f));
       }
       else if(random==2){
         Instantiate(Candie2,CandiePosition, transform.rotation * Quaternion.Euler(90f,0f,0f));
       }
       else if(random==3){
         Instantiate(Candie3,CandiePosition, transform.rotation * Quaternion.Euler(90f,0f,0f));
       }
       else if(random==4){
         Instantiate(Candie4,CandiePosition, transform.rotation * Quaternion.Euler(90f,0f,0f));
       }
        
    }
}
