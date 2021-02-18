using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{

    [SerializeField] GameObject Player;

    void OnEnable()
    {
        PortalController.OnEnteringPortal += StartTeleport;
    }

    void StartTeleport(Vector2 PositionToTeleport)
    {
        Player.SetActive(false);
        Player.transform.position = PositionToTeleport;
        Player.SetActive(true);

    }

    void OnDisable()
    {
        PortalController.OnEnteringPortal -= StartTeleport;
    }
}
