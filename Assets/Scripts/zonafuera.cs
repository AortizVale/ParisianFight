using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zonafuera : MonoBehaviour
{
    public GameObject posicionincial1;
    public GameObject posicionincial2;
    private GameObject jugador1;
    private GameObject jugador2;
    [SerializeField]
    public FALTAS faltas1;
    public FALTAS faltas2;




    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Player1"))
        {
            Debug.Log("jugador 1 salio");
            faltas1.SumarFaltas();

        }
        if (other.gameObject.CompareTag("Player2"))
        {
            Debug.Log("jugador 2 salio");
            faltas2.SumarFaltas();

        }

    }
}
