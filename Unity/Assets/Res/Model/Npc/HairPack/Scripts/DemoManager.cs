using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityChan;
public class DemoManager : MonoBehaviour
{
    public Toggle windToggle;
    private List<GameObject> hairs;
    private int hairCount;
    private int currentHairId;
    void Start()
    {
        hairs = new List<GameObject>();
        foreach (Transform child in transform)
        {
            hairs.Add(child.gameObject);
        }
        hairCount = hairs.Count;
    }

    public void NextHair()
    {
        hairs[currentHairId].SetActive(false);
        currentHairId = (currentHairId+1) % hairCount;      
        hairs[currentHairId].SetActive(true);
        OnActiveWind(windToggle);
    }
    public void PreviousHair()
    {
        hairs[currentHairId].SetActive(false);      
        if (currentHairId == 0) currentHairId = hairCount;
        currentHairId = --currentHairId ; 
        hairs[currentHairId].SetActive(true);
        OnActiveWind(windToggle);
    }
    void OnActiveWind(Toggle toggle)
    {
        RandomWind wind = hairs[currentHairId].GetComponent<RandomWind>();
        if (wind != null)
        {
            wind.isWindActive = toggle.isOn;
        }
    }
    void FixedUpdate()
    {
        windToggle.onValueChanged.AddListener(delegate { OnActiveWind(windToggle);});

    }
}
