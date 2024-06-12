using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aura
{
    public class QuitButton : MonoBehaviour
    {
        public void HandleQuitButton()
        {
            Application.Quit();
        }
    } 
}
