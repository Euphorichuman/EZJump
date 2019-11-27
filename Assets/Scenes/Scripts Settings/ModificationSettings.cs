using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModificationSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public Image ImagenUI;
    public Image ImagenM;
    public Image ImagenH;
    public Image ImagenSFXon;
    public Image ImagenSFXoff;
    public Image ImagenMusicOn;
    public Image ImagenMusicOff;
    int L = 0;
    public void LowClick(int x) {
        x = 0;
        //Sprite imageOn = Resources.Load<Sprite>("Pngs/Low-button");
        //Sprite imageOff= Resources.Load<Sprite>("Pngs/Low-button_OFF");
        

        ImagenUI = GameObject.Find("ButtonQLow").GetComponent<Image>();
        if (L==1)
        {
            ImagenUI.sprite = Resources.Load<Sprite>("Pngs/Low-button_OFF");
            L = 0;
        } else{
            setQuality(x);
            ImagenUI.sprite = Resources.Load<Sprite>("Pngs/Low-button");
            L = 1;
        }

    }
    int M = 0;

    public void MediumClick(int x)
    {
        x = 1;
        

        ImagenM = GameObject.Find("ButtonQMedium").GetComponent<Image>();
        if (M == 1)
        {
            ImagenM.sprite = Resources.Load<Sprite>("Pngs/Medium-button_OFF");
            M = 0;
        }
        else
        {
            setQuality(x);
            ImagenM.sprite = Resources.Load<Sprite>("Pngs/Medium-button");
            M = 1;
        }

    }

    int H = 0;
    public void HighClick(int x)
    {
        x = 2;


        ImagenH = GameObject.Find("ButtonQHigh").GetComponent<Image>();
        if (H == 1)
        {
            ImagenH.sprite = Resources.Load<Sprite>("Pngs/High-button_OFF");
            H = 0;
        }
        else
        {
            setQuality(x);
            ImagenH.sprite = Resources.Load<Sprite>("Pngs/High-button");
            H = 1;
        }

    }
    int sfxon = 1;
    public void SFXclickOn()
    {
         


        
        ImagenSFXon = GameObject.Find("ButtonSFXON").GetComponent<Image>();
                   if (sfxon == 1)
            {
                ImagenSFXon.sprite = Resources.Load<Sprite>("Pngs/On-button_OFF");
                sfxon = 0;
            }
            else
            {

                ImagenSFXon.sprite = Resources.Load<Sprite>("Pngs/On-button");
                sfxon = 1;
            }
        
    }
    int sfxoff = 1;
    public void SFXclickOff()
    {



                ImagenSFXoff = GameObject.Find("ButtonSFXOFF").GetComponent<Image>();
        if (sfxoff == 1)
        {
            ImagenSFXoff.sprite = Resources.Load<Sprite>("Pngs/Off-button_off");
            sfxoff = 0;
        }
        else
        {

            ImagenSFXoff.sprite = Resources.Load<Sprite>("Pngs/Off-button");
            sfxoff = 1;
        }

    }
    //int music = 1;
    //public void MusicOn()
    //{




    //    ImagenMusicOn = GameObject.Find("ButtonSFXON").GetComponent<Image>();
    //    if (music == 1)
    //    {
    //        ImagenMusicOn.sprite = Resources.Load<Sprite>("Pngs/On-button_OFF");
    //        sfxon = 0;
    //    }
    //    else
    //    {

    //        ImagenMusicOn.sprite = Resources.Load<Sprite>("Pngs/On-button");
    //        sfxon = 1;
    //    }

    //}
    //int sfxoff = 1;
    //public void SFXclickOff()
    //{



    //    ImagenSFXoff = GameObject.Find("ButtonSFXOFF").GetComponent<Image>();
    //    if (sfxoff == 1)
    //    {
    //        ImagenSFXoff.sprite = Resources.Load<Sprite>("Pngs/Off-button_off");
    //        sfxoff = 0;
    //    }
    //    else
    //    {

    //        ImagenSFXoff.sprite = Resources.Load<Sprite>("Pngs/Off-button");
    //        sfxoff = 1;
    //    }

    //}

    public void setQuality(int i)
    {
        QualitySettings.SetQualityLevel(i);
    }
}
    