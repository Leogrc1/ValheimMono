using System.Collections.Generic;
using UnityEngine;

namespace ValheimMono
{
    public class MenuManager : MonoBehaviour
    {
        private Hacks ESPManager;

        public GameObject menu;

        private bool isDrawMonstersESP = false;
        private bool isDrawAnimalsESP = false;
        private bool isDrawContainersESP = false;
        private bool isDrawTameablesESP = false;
        private bool isDrawPickablesESP = false;

        private bool isMenuEnabled = false;
        private bool isESPMenuEnabled = false;

        public void Start()
        {
            ESPManager = GetComponent<Hacks>();
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Insert))
            {
                isMenuEnabled = !isMenuEnabled;
            }

            if (Input.GetKeyDown(KeyCode.Delete))
            {
                Loader.Unload();
            }
        }

        public void OnGUI()
        {
            if (isMenuEnabled)
            {
                GUI.Box(new Rect(25, 25, 200, 400), "TinyVikingBoost");

                if (GUI.Button(new Rect(30, 45, 95, 40), "ESP"))
                {
                    isESPMenuEnabled = !isESPMenuEnabled;
                }
                if (isESPMenuEnabled)
                {
                    if (GUI.Button(new Rect(30, 85, 190, 40), "Monsters ESP"))
                    {
                        isDrawMonstersESP = !isDrawMonstersESP;
                    }
                    if(GUI.Button(new Rect(30, 125, 190, 40), "Animals ESP"))
                    {
                        isDrawAnimalsESP = !isDrawAnimalsESP;
                    }
                    if(GUI.Button(new Rect(30, 165, 190, 40), "Tameables ESP"))
                    {
                        isDrawTameablesESP = !isDrawTameablesESP;
                    }
                    if (GUI.Button(new Rect(30, 205, 190, 40), "Containers ESP"))
                    {
                        isDrawContainersESP = !isDrawContainersESP;
                    }
                    if(GUI.Button(new Rect(30, 245, 190, 40), "Pickables ESP"))
                    {
                        isDrawPickablesESP = !isDrawPickablesESP;
                    }
                }
                else
                {
                    if (GUI.Button(new Rect(125, 45, 95, 40), "Misc"))
                    {

                    }
                }
            }
            ESPValues();
        }
        public void ESPValues()
        {
            //Valeurs des ESP
            if (isDrawMonstersESP)
            {
                ESPManager.DrawMonstersTab();
            }
            if(isDrawAnimalsESP)
            {
                ESPManager.DrawAnimalsTab();
            }
            if(isDrawTameablesESP)
            {
                ESPManager.DrawTameablesTab();
            }
            if(isDrawContainersESP)
            {
                ESPManager.DrawContainersTab();
            }
            if(isDrawPickablesESP)
            {
                ESPManager.DrawPickablesTab();
            }
        }
    }
}
