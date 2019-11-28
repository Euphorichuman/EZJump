using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    // los dos siguiente es lo mismo, uno click y el otro por enter
    {

        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return) )
            {
            Camera.main.GetComponent<AudioSource>().Stop();
            GameObject.Find("Button_Press").GetComponent<AudioSource>().Play();
            SceneManager.LoadScene("Game");

           
        }
    }
    public void cargarNivel(string SampleScene) {
        Camera.main.GetComponent<AudioSource>().Stop();
        GameObject.Find("Button_Press").GetComponent<AudioSource>().Play();
SceneManager.LoadScene("Game");


    }

    public void CargarSettings(string SettingScene) {
        Camera.main.GetComponent<AudioSource>().Stop();
        GameObject.Find("Button_Settings").GetComponent<AudioSource>().Play();

        SceneManager.LoadScene("SettingScene");
    }

    public void BacktoInicio(string Inicio)
    {
        
        
          SceneManager.LoadScene("Inicio");
    }

    public void Salir() {
        Camera.main.GetComponent<AudioSource>().Stop();
        GameObject.Find("Button_Exit").GetComponent<AudioSource>().Play();

        Application.Quit();
    }
    
}
