using Aura;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActiveAbility
{
    Dash,
    Scan
}

public class Abilities : MonoBehaviour
{
    public ActiveAbility activeAbility;
    PlayerMovement playerMovement;
    GroundChecker groundChecker;
    ScanController scanController;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        groundChecker = GetComponent<GroundChecker>();
        scanController = GetComponent<ScanController>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            switch (activeAbility)
            {
                case ActiveAbility.Dash:
                    if (groundChecker.GetGroundedStatus() == true)
                    {
                        playerMovement.SetIsJumping(true);
                    }
                    if (playerMovement.isInAir == true)
                    {
                        playerMovement.SetIsDashing(true);
                    }
                    break;
                case ActiveAbility.Scan:
                    scanController.FireScanFX();
                    break;
            }
        }

    }
}


