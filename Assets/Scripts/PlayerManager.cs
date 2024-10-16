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
    }
}
