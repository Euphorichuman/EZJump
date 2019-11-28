using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicInicioOff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //public void StopMusicInicio() {
    //    Camera.main.GetComponent<AudioSource>().Stop();
    //}
    public void StopMusicSetting() {
        GameObject.Find("MusicSettings").GetComponent<AudioSource>().Stop();
    }
    public void PlayMusicSetting()
    {
        GameObject.Find("MusicSettings").GetComponent<AudioSource>().Play();
    }
    //public void StopMusicGame() {
    //    Camera.main.GetComponent<AudioSource>().Stop();

    //}


}
