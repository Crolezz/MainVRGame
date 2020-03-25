using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

namespace Valve.VR.InteractionSystem.Sample
{
    public class BTNquit : MonoBehaviour
    {
        public void OnButtonDown(Hand fromHand)
        {
            UnityEditor.EditorApplication.isPlaying = false; // Unity Editor Only
            Application.Quit();
            //ColorSelf(Color.cyan);
            fromHand.TriggerHapticPulse(1000);

        }

        public void OnButtonUp(Hand fromHand)
        {
           // ColorSelf(Color.white);
        }




        /*private void ColorSelf(Color newColor)
        {

            Renderer[] renderers = this.GetComponentsInChildren<Renderer>();
            for (int rendererIndex = 0; rendererIndex < renderers.Length; rendererIndex++)
            {
                renderers[rendererIndex].material.color = newColor;
            }


        }*/

    }

}
