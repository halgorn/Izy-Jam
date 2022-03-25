using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
   public void StartGame(){
       SceneManager.LoadScene("Game");
   }

   public void ExitGame(){
       Application.Quit();
   }

   public void MenuGame(){
       SceneManager.LoadScene("Menu");
   }
}
