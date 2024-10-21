using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class circulotiempo : MonoBehaviour
{
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 90;
    }

    public void CambiarTiempo(float cantidad)
    {
        slider.value = cantidad;
    }

    public void InicializarBarradePoder2()
    {
        slider.value = 90;
    }

}
