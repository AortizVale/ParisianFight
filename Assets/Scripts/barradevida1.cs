using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barradevida1 : MonoBehaviour 
{
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = slider.maxValue;
    }

    public void CambiarVidaActual1(float cantidad){
        slider.value = slider.value - cantidad;
    }

    public void InicializarBarradeVida1()
    {
        slider.value = slider.maxValue;
    }
}
