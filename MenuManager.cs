using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

namespace ValheimMono
{
    public class MenuManager : MonoBehaviour
    {
        private Hacks ESPManager;

        public GameObject menu;

        //ESP bool
        private bool isDrawMonstersESP = false;
        private bool isDrawAnimalsESP = false;
        private bool isDrawContainersESP = false;
        private bool isDrawTameablesESP = false;
        private bool isDrawPickablesESP = false;

        //Menu bool
        private bool isMenuEnabled = false;
        private bool isESPMenuEnabled = false;
        private bool isPlayerMenuEnabled = false;
        private bool isMiscMenuEnabled = false;

        //Player bool
        private bool isHealthHackEnabled = false;

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
                GUI.Box(new Rect(25, 25, 300, 400), "TinyVikingBoost");

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
                    if (GUI.Button(new Rect(225, 45, 95, 40), "Misc"))
                    {

                    }
                    else
                    {
                        if (GUI.Button(new Rect(127.6f, 45, 95, 40), "Player"))
                        {
                            isPlayerMenuEnabled = !isPlayerMenuEnabled;
                        }

                        if (isPlayerMenuEnabled)
                        {
                            if (GUI.Button(new Rect(30, 85, 190, 40), "Health Hack"))
                            {
                                isHealthHackEnabled = !isHealthHackEnabled;
                            }
                            PlayerValues();
                        }
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
        public void PlayerValues()
        {
            if(isHealthHackEnabled)
            {
                ESPManager.HealthHack();
            }
        }
    }
}
