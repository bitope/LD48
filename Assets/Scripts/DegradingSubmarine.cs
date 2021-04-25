using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DegradingSubmarine : MonoBehaviour
{
    public int sailorsLeft = 100;
    public float air = 200;

    public float tickInterval = 10f;
    public float tick;

    public TMPro.TextMeshProUGUI uiSailorCount;
    
    // Start is called before the first frame update
    void Start()
    {
        tick = tickInterval;
    }

    // Update is called once per frame
    void Update()
    {
        tick -= Time.deltaTime;
        if (tick <= 0)
        {
            tick = tickInterval;
            air -= sailorsLeft/2f;

            if (air <= 0)
            {
                sailorsLeft -= 1;
                air = 200;
            }

            uiSailorCount.text = sailorsLeft.ToString();
        }
    }
}
