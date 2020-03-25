using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

namespace Valve.VR.InteractionSystem.Sample
{
    public class BTNstart : MonoBehaviour
    {
        public void OnButtonDown(Hand fromHand)
        {
            SceneManager.LoadScene("Elon'sScene");
            //ColorSelf(Color.cyan);
            fromHand.TriggerHapticPulse(1000);
           
        }

        public void OnButtonUp(Hand fromHand)
        {
           // ColorSelf(Color.white);
        }




        // private void ColorSelf(Color newColor)
        //{

        // Renderer[] renderers = this.GetComponentsInChildren<Renderer>();
        // for (int rendererIndex = 0; rendererIndex < renderers.Length; rendererIndex++)
        //  {
        //  renderers[rendererIndex].material.color = newColor;
        // }


    }

}
