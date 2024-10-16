using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private List<PlayerInput> players = new List<PlayerInput>();
    private List<EventSystem> eventSystems = new List<EventSystem>();
    // Array de Pantallas a manejar
    public GameObject[] screens;
    public GameObject canvas;
    public GameObject firstButton;  
    public PlayerInputManager playerInputManager;

    // Índice del objeto que quieres activar
    public int indexToActivate;

    private void Awake()
    {
        SetActiveScreen(indexToActivate);
        playerInputManager = FindObjectOfType<PlayerInputManager>();
    }

    private void OnEnable()
    {
        playerInputManager.onPlayerJoined += AddPlayer;
    }

    private void OnDisable()
    {
        playerInputManager.onPlayerJoined -= AddPlayer;
    }

    private void AddPlayer(PlayerInput player)
    {
        players.Add(player);
        // Busca al hijo llamado 'EventSystem'
        Transform eventSystemTransform = player.transform.Find("EventSystem");

        if (eventSystemTransform != null)
        {
            // Obtén el componente EventSystem del GameObject hijo
            EventSystem eventSystem = eventSystemTransform.GetComponent<EventSystem>();

            if (eventSystem != null)
            {
                Debug.Log("EventSystem encontrado.");
                eventSystems.Add(eventSystem);
                eventSystem.SetSelectedGameObject(firstButton);
            }
            else
            {
                Debug.Log("El componente EventSystem no se encontró en el GameObject hijo.");
            }
        }
        else
        {
            Debug.Log("El GameObject 'EventSystem' no fue encontrado como hijo.");
        }

    }

    public void SetCurrentUIComponent(GameObject UIcomponent)
    {
        firstButton = UIcomponent;
        eventSystems[0].SetSelectedGameObject(firstButton);
        eventSystems[1].SetSelectedGameObject(firstButton);
    
    }
    public void SetActiveScreen(int index)
    {
        // Recorremos el array de GameObjects
        for (int i = 0; i < screens.Length; i++)
        {
            if (i == index)
            {
                screens[i].SetActive(true);  // Activa el objeto en el índice especificado
            }
            else
            {
                screens[i].SetActive(false); // Desactiva el resto
            }
        }
    }

    public void SetScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
