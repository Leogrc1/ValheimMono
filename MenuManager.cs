using System.Collections.Generic;
using UnityEngine;

namespace ValheimMono
{
    public class MenuManager : MonoBehaviour
    {
        private Hacks ESPManager;

        public GameObject menu;

        private bool isMenuEnabled = false;

        private int selectedTab = 0;

        public void Start()
        {
            ESPManager = GetComponent<Hacks>();
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Insert))
            {
                isMenuEnabled = !isMenuEnabled;
                Debug.Log("Menu state toggled. isMenuEnabled: " + isMenuEnabled);
            }

            if (Input.GetKeyDown(KeyCode.Delete))
            {
                Loader.Unload();
            }
        }

        public void OnGUI()
        {
            Debug.Log("OnGUI is Called");
            if (isMenuEnabled)
            {
                GUI.Box(new Rect(25, 25, 200, 400), "TinyVikingBoost");

                DrawTabs();

                switch (selectedTab)
                {
                    case 0:
                        ESPManager.DrawMonstersTab();
                        break;
                    case 1:
                        ESPManager.DrawAnimalsTab();
                        break;

                    default: break;
                }
            }
        }

        void DrawTabs()
        {
            for (int i = 0; i < 2; i++)
            {
                if (GUI.Button(new Rect(30 + i * 70, 45, 70, 40), "Tab " + i))
                {
                    selectedTab = i;
                }
            }
        }
    }
}
