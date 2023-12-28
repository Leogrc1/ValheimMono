using UnityEngine;

namespace ValheimMono
{
    public class Loader
    {

        private static GameObject Load;

        public static void Init()
        {
            Loader.Load = new GameObject("ValheimMonoLoader");
            Loader.Load.AddComponent<Hacks>();
            Object.DontDestroyOnLoad(Load);
        }

        //When calling, destroy the gameObject that have the script in it
        public static void Unload()
        {
            _Unload();
        }
        private static void _Unload()
        {
            if(Load != null)
            {
                GameObject.Destroy(Load);
            }
        }
    }
}
