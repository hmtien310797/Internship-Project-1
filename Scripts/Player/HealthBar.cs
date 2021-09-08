using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class HealthBar : MonoBehaviour
    {
        public Slider slider;

        public void SetMaxHP(int hitpoint)
        {
            slider.maxValue = hitpoint;
            slider.value = hitpoint;
        }

        public void SetHP(int hitpoint)
        {
            slider.value = hitpoint;
        }
    }
}

