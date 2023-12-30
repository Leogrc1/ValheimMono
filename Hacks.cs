using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

namespace ValheimMono
{
    internal class Hacks : MonoBehaviour
    {
        private AnimalAI[] animals;
        private MonsterAI[] monsters;
        private Pickable[] pickables;
        private Tameable[] tameables;
        private Container[] containers;

        private bool animalsESP = false;
        private bool monstersESP = false;
        private bool pickablesESP = false;
        private bool tameablesESP = false;
        private bool containersESP = false;

        public float maxDistance = 75f;
        public void Start()
        {
            animals = FindObjectsOfType<AnimalAI>();
            monsters= FindObjectsOfType<MonsterAI>();
            pickables = FindObjectsOfType<Pickable>();
            tameables = FindObjectsOfType<Tameable>();
            containers = FindObjectsOfType<Container>();
        }

        public void OnGUI()
        {
            GUI.Box(new Rect(25, 25, 200, 400), "TinyVikingBoost");

            // Utilise un bouton pour activer ou désactiver l'ESP
            if (GUI.Button(new Rect(30, 45, 190, 40), "Monsters ESP"))
            {
                monstersESP = !monstersESP;
            }
            if (GUI.Button(new Rect(30, 85, 190, 40), "Animals ESP"))
            {
                animalsESP = !animalsESP;
            }
            if (GUI.Button(new Rect(30, 125, 190, 40), "Drop ESP"))
            {
                pickablesESP = !pickablesESP;
            }
            if (GUI.Button(new Rect(30, 165, 190, 40), "Tameables ESP"))
            {
                tameablesESP = !tameablesESP;
            }
            if (GUI.Button(new Rect(30, 205, 190, 40), "Containers ESP"))
            {
                containersESP = !containersESP;
            }

            // Affiche l'ESP seulement si la valeur est vrai
            if (monstersESP)
            {
                DrawObjectsESP(monsters, Color.red);
            }
            if(animalsESP)
            {
                DrawObjectsESP(animals, Color.green);
            }
            if(pickablesESP)
            {
                DrawObjectsESP(pickables, Color.blue);
            }
            if (tameablesESP)
            {
                DrawObjectsESP(tameables, Color.white);
            }
            if(containersESP)
            {
                DrawObjectsESP(containers, Color.yellow);
            }
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Delete))
            {
                Loader.Unload();
            }
        }

        private void DrawObjectsESP(IEnumerable<Component> objects, Color color)
        {
            foreach (var component in objects)
            {
                // Convertir le composant en GameObject
                GameObject obj = component.gameObject;

                // Exclure le joueur en vérifiant s'il a un composant spécifique (par exemple, Player)
                if (obj != null && obj.GetComponent<Player>() == null)
                {
                    Bounds bounds = obj.GetComponentInChildren<Renderer>().bounds;
                    Vector3 footPos = new Vector3(bounds.center.x, bounds.min.y, bounds.center.z);
                    Vector3 headPos = new Vector3(bounds.center.x, bounds.max.y, bounds.center.z);

                    Vector3 w2sFootPos = Camera.main.WorldToScreenPoint(footPos);
                    Vector3 w2sHeadPos = Camera.main.WorldToScreenPoint(headPos);

                    float distance = Vector3.Distance(Camera.main.transform.position, obj.transform.position);

                    if (w2sFootPos.z > 0f && distance <= maxDistance)
                    {
                        DrawBoxESP(w2sFootPos, w2sHeadPos, color);
                        DrawEntityName(obj, w2sHeadPos, obj.name);
                        DrawDistanceLabel(w2sHeadPos, distance.ToString("F1") + "m");
                    }
                }
            }
        }

        private void DrawBoxESP(Vector3 footPos, Vector3 headPos, Color color)
        {
            float height = headPos.y - footPos.y;
            float widthOffset = 2f;
            float width = height / widthOffset;

            // ESP Box
            Render.DrawBox(footPos.x - (width / 2), Screen.height - footPos.y - height, width, height, color, 2f);

            // Snapline
            Render.DrawLine(new Vector2(Screen.width / 2, Screen.height / 2), new Vector2(footPos.x, Screen.height - footPos.y), color, 2f);
        }

        private void DrawEntityName(GameObject entity, Vector3 headPosScreen, string entityName)
        {
            Vector2 labelPos = new Vector2(headPosScreen.x, Screen.height - headPosScreen.y);
            GUI.Label(new Rect(labelPos.x, labelPos.y, 100f, 30f), entityName);
        }

        private void DrawDistanceLabel(Vector3 position, string distance)
        {
            Vector2 labelPos = new Vector2(position.x, Screen.height - position.y + 35f);
            GUI.Label(new Rect(labelPos.x, labelPos.y, 100f, 30f), distance);
        }
    }
}
