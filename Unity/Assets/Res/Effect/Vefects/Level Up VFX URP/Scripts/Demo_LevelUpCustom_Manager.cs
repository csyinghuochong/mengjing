using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Demo_LevelUpCustom_Manager : MonoBehaviour
{
    float m_Hue_01;
    float m_Hue_02;

    public ParticleSystem levelUpCustom;
    public GameObject leveUpText;

    public Slider m_SliderColor01, m_SliderColor02;
    public Toggle buttonSparkles, buttonGround, buttonArrows;

    bool addSparkles, addGround, addArrows;
    GameObject PSsparkles, PSground, PSarrows;


    public float loopTime;
    float currentTime;


    void Start()
    {

        m_SliderColor01.maxValue = 1;
        m_SliderColor01.minValue = 0;

        m_SliderColor02.maxValue = 1;
        m_SliderColor02.minValue = 0;

        PSarrows = levelUpCustom.transform.GetChild(1).gameObject;
        PSsparkles = levelUpCustom.transform.GetChild(2).gameObject;
        PSground = levelUpCustom.transform.GetChild(3).gameObject;
        Instantiate(leveUpText, levelUpCustom.transform.position, levelUpCustom.transform.rotation);



    }

    // Update is called once per frame
    void Update()
    {
        m_Hue_01 = m_SliderColor01.value;
        m_Hue_02 = m_SliderColor02.value;

        Shader.SetGlobalColor("Color_01", Color.HSVToRGB(m_Hue_01, 0.9f, 1));
        Shader.SetGlobalColor("Color_02", Color.HSVToRGB(m_Hue_02, 0.8f, 1));

        currentTime -= Time.deltaTime;


        if (currentTime <= 0)
        {
            Reset();
        }

    }

    void Reset()
    {
        levelUpCustom.Clear();
        levelUpCustom.Play();
        Instantiate(leveUpText, levelUpCustom.transform.position, levelUpCustom.transform.rotation);
        currentTime = loopTime;
    }

    public void AddSparkles(bool value)
    {
        addSparkles = value;

        if(addSparkles)
        {
            PSsparkles.SetActive(true);
        }
        else
        {
            PSsparkles.SetActive(false);

        }

        Reset();
    }

    public void AddArrows(bool value)
    {
        addArrows = value;

        if (addArrows)
        {
            PSarrows.SetActive(true);
        }
        else
        {
            PSarrows.SetActive(false);

        }

        Reset();

    }

    public void AddGround(bool value)
    {
        addGround = value;

        if (addGround)
        {
            PSground.SetActive(true);
        }
        else
        {
            PSground.SetActive(false);

        }

        Reset();

    }
}
