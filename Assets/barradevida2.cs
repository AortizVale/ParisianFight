using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barradevida2 : MonoBehaviour
{
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = slider.maxValue;
    }

    public void CambiarVidaActual2(float cantidad)
    {
        slider.value = slider.value - cantidad;
    }

    public void InicializarBarradeVida2()
    {
        slider.value = slider.maxValue;
    }
}
