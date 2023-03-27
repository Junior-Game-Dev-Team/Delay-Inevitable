using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FMODUnity.StudioEventEmitter))]
public class PlayerFootsteps : MonoBehaviour
{
    private PlayerMovement player;
    private FMODUnity.StudioEventEmitter emitter;

    private void Awake()
    {
        player = GetComponentInParent<PlayerMovement>();
        emitter = GetComponent<FMODUnity.StudioEventEmitter>();
    }

    private void Update()
    {
        // Play one shot SFX audio when the player is moving
        if (!emitter.IsPlaying() && player.rb.velocity.magnitude > 0.3)
            emitter.Play();
    }
}
