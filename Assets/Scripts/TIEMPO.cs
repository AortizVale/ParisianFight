using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TIEMPO : MonoBehaviour
{
    [SerializeField] public circulotiempo circulotiempo;
    public float tiempo;
    private TextMeshProUGUI textTiempo;

    private void Start()
    {
        textTiempo = GetComponent<TextMeshProUGUI>();
        tiempo = 90;
    }
    private void Update()
    {
        tiempo -= Time.deltaTime;
        textTiempo.text = tiempo.ToString("0");
        circulotiempo.CambiarTiempo(tiempo);
    }
}
