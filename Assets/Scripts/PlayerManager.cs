using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    private List<PlayerInput> players = new List<PlayerInput>();
    [SerializeField]
    private List<Transform> startingPoints;
    [SerializeField]
    private List<LayerMask> playerLayers;
    [SerializeField]
    public Camera gameplayCamera;

    public CinemachineTargetGroup cinemachineTargetGroup;

    private PlayerInputManager playerInputManager;

    // Lista de tags para los jugadores.
    private readonly string[] playerTags = { "Player1", "Player2" };
    //Lista de layers para hitbox y hu
    private readonly string[] hitboxLayers = { "HitboxPlayer1", "HitboxPlayer2" };
    private readonly string[] hurtboxLayers = { "HurtboxPlayer1", "HurtboxPlayer2" };

    void Update()
    {

        // Con esto se verifica que los jugadores siempre se esten mirando entre si

        if (players.Count >= 2)
        {
            // Obtiene las posiciones en X de los dos elementos
            float x1 = players[0].transform.position.x;
            float x2 = players[1].transform.position.x;

            // Compara las posiciones y asigna rotaciones
            if (x1 < x2)
            {
                // El primer jugador está a la izquierda, rotación en Y = 0
                players[0].transform.rotation = Quaternion.Euler(0, 0, 0);
                // El segundo jugador está a la derecha, rotación en Y = 180
                players[1].transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                // El segundo jugador está a la izquierda, rotación en Y = 0
                players[1].transform.rotation = Quaternion.Euler(0, 0, 0);
                // El primer jugador está a la derecha, rotación en Y = 180
                players[0].transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
    private void Awake()
    {
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

    public void AddPlayer(PlayerInput player)
    {
        players.Add(player);

        // Ubicar al jugador en la posición inicial.
        Transform playerTransform = player.transform;
        playerTransform.position = startingPoints[players.Count - 1].position;
        playerTransform.rotation = startingPoints[players.Count - 1].rotation;

        cinemachineTargetGroup.RemoveMember(startingPoints[players.Count - 1]);
        cinemachineTargetGroup.AddMember(playerTransform, 1, 2);

        // Buscar el script PlayerController en el jugador.
        PlayerController playerController = player.GetComponent<PlayerController>();

        // Asignar la cámara gameplayCamera al PlayerController.
        if (playerController != null)
        {
            playerController.playerCamera = gameplayCamera;
        }
        else
        {
            Debug.LogError("El PlayerController no fue encontrado en el jugador.");
        }

        // Asignar el tag correspondiente al jugador.
        if (players.Count <= playerTags.Length)
        {
            player.gameObject.tag = playerTags[players.Count - 1];

        }
        else
        {
            Debug.LogError("No hay suficientes tags definidos para más jugadores.");
        }

        //Asignar los layers de hitbox hurtbox
        
    }
}
