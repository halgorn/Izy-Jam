using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTerrain : MonoBehaviour
{
    //variaveis de valida��o 
    [SerializeField] int width, height;
    [SerializeField] int minHeight, maxHeight;
    [SerializeField] int repeatNum;//5
   // [SerializeField] int spikeSpawnHeight, coinsSpawnHeight, mobTerrestreHeight,ComidaHeight;
    //variaveis de cenario principal
    [SerializeField] GameObject dirt;
    //variaveis de mob e npc;
   // [SerializeField] GameObject aguia, rato;
    //variaveis de comida
   // [SerializeField] GameObject CoxaFrango, Bacon, Bebida, Queijo, Tomate;
    //variaveis de cenario de fundo
   // [SerializeField] GameObject arvores, arvores1, abusto, arbutos1, flor, flor1, pedra;
    
    //valida��o para ordem do trigo no cenario
   // [SerializeField] GameObject trigo1, trigo2, trigo3;

    public GameObject Player;

  //  public GameObject ParedeInicio;
   // public GameObject ParedeFim;

    void Start()
    {
        Generation();
    }

    void Generation()
    {
        int repeatValue = 1;
        for (int x = 0; x < width; x++)//This will help spawn a tile on the x axis
        {
         if(repeatValue == 1)
            {
                height = Random.Range(minHeight, maxHeight);
                GenerateFlatPlatform(x);
                repeatValue = repeatNum;
            }
            else
            {
                GenerateFlatPlatform(x);
                repeatValue--;
            }
        }
    }
  
    //gera a plataforma
    void GenerateFlatPlatform(int x)
    {
        for (int y = 0; y < height; y++)//This will help spawn a tile on the y axis
        {
            spawnObj(dirt, x, y);
        }

    }
       

    void spawnObj(GameObject obj, int width, int height)//What ever we spawn will be a child of our procedural generation gameObj
    {
        obj = Instantiate(obj, new Vector2(width, height), Quaternion.identity);
        obj.transform.parent = this.transform;
    }

}
