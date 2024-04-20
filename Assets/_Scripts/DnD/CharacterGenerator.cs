using UnityEngine;


namespace Game.DnD
{

    internal sealed class CharacterGenerator : MonoBehaviour
    {
       
    }

    internal static class GameExtensions
    {
        public static int GetRandomIndex<T>(this T[] list)
        {
            return Random.Range(0, list.Length);
        }


    }

}