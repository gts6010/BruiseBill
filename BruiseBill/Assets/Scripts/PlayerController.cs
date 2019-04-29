using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour
{
    private Transform playertf;
    [Range(0.0f, 10.0f)] public float walkingspeed = 1.0f;
    [Range(0.0f, 10.0f)] public float strafingspeed = 0.4f;
    [Range(0.0f, 10.0f)] public float rotationspeed = 5.0f;
    [SerializeField] AudioSource step1, step2, step3, step4;
    private float audiotimer = 0.0f;
    private byte laststepfxplayed = 4;
    [SerializeField] GameObject startingArea;
    [SerializeField] DialogueSystem dialogueSystem;

    void Start()
    {
        playertf = gameObject.transform;
        audiotimer = Time.timeSinceLevelLoad;
    }

    void Update()
    {
        playertf.Translate(new Vector3(Input.GetAxis("Vertical") * walkingspeed, 0, Input.GetAxis("Horizontal") * -1.0f * strafingspeed));
        playertf.Rotate(0, Input.GetAxis("Mouse X") * rotationspeed, 0, Space.Self);
        if ((Input.GetAxis("Vertical") > 0.45f || Input.GetAxis("Horizontal") > 0.35f) && (Time.timeSinceLevelLoad - audiotimer > 0.33f))
        {
            switch (laststepfxplayed)
            {
                case 1:
                    step2.Play();
                    laststepfxplayed = 2;
                    break;
                case 2:
                    step3.Play();
                    laststepfxplayed = 3;
                    break;
                case 3:
                    step4.Play();
                    laststepfxplayed = 4;
                    break;
                case 4:
                    step1.Play();
                    laststepfxplayed = 1;
                    break;
                default:
                    break;
            }
            audiotimer = Time.timeSinceLevelLoad;
        }

    }

    private void OnTriggerExit(Collider triggerArea)
    {
        if (triggerArea.gameObject == startingArea)
        {
            dialogueSystem.HideInstructions();
        }
    }
}
