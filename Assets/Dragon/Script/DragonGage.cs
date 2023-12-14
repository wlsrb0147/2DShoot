using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonGage : MonoBehaviour
{
    public Image Energy;
    public Image Energy_Max;
    public static float gage;

    // Update is called once per frame
    void Update()
    {
        if (gage >= 1)
        {
            gage = 1;
            Energy_Max.enabled = true;
        }
        else
        {
            Energy_Max.enabled = false;
        }

        if (gage < 0)
        { gage = 0; }
       Energy.fillAmount = gage;
    }
}
