using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchGameOver : MonoBehaviour
{
    private int counter = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "JeffEnemy")
        {
            counter++;
            if (counter > 3)
            {
                Destroy(Valve.VR.InteractionSystem.Player.instance.gameObject);
                UnityEngine.SceneManagement.SceneManager.LoadScene(3);
            }
        }
    }
}
