using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class TeleportationSphere : MonoBehaviour
{
    public Transform teleportationDestination;
    public float fadeDuration;
    public static GameObject currentSphere;
    public bool isInitial = false;

    private void Start()
    {
        if (isInitial)
        {
            currentSphere = gameObject;
            currentSphere.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        StartCoroutine(TeleportationRoutine());
    }

    IEnumerator TeleportationRoutine()
    {
        SteamVR_Fade.Start(Color.black, fadeDuration / 2);
        yield return new WaitForSeconds(fadeDuration / 2);
        Player.instance.transform.position = teleportationDestination.position;
        SteamVR_Fade.Start(Color.clear, fadeDuration / 2);

        if (currentSphere)
        {
            currentSphere.SetActive(true);
        }
        currentSphere = gameObject;
        currentSphere.SetActive(false);
    }
}
