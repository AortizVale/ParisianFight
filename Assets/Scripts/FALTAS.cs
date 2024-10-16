using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FALTAS : MonoBehaviour
{
    public float Faltas;
    private TextMeshProUGUI textFaltas;


    private void Start()
    {
        textFaltas = GetComponent<TextMeshProUGUI>();
        Faltas = 0;
    }
    private void Update()
    {
        textFaltas.text = Faltas.ToString("0");
    }
    public void SumarFaltas()
    {
        Faltas += 1;
    }

}