using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barradepoder2 : MonoBehaviour
{
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 0;
    }

    public void CambiarPoderActual2(float cantidad)
    {
        Debug.Log("subepoder2");
        slider.value = slider.value + cantidad;
    }

    public void InicializarBarradePoder2()
    {
        slider.value = 0;
    }
}
