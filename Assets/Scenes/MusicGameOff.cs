using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicGameOff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MusicGOff() {
        GameObject.Find("MusicGame").GetComponent<AudioSource>().Stop();

    }
    public void MusicGON() {
        GameObject.Find("MusicGame").GetComponent<AudioSource>().Play();

    }




}
