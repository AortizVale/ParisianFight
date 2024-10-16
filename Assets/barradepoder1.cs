using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barradepoder1 : MonoBehaviour
{
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 0;
    }

    public void CambiarPoderActual1(float cantidad)
    {
        Debug.Log("subepoder1");
        slider.value = slider.value + cantidad;
    }

    public void InicializarBarradePoder1()
    {
        slider.value = 0;
    }
}
