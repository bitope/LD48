using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCanvasController : MonoBehaviour
{
    public SubController playerSubmarine;

    public Image fuelUIPanel;
    public Image airUIPanel;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fuelUIPanel.fillAmount = playerSubmarine.GetFuelRatio();
        airUIPanel.fillAmount = playerSubmarine.GetAirRatio();
    }
}
