using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChamaMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Menu",3);
    }

    public void Menu()
    {
       SceneManager.LoadScene("Menu");
    }
}
