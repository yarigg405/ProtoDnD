using UnityEngine;
using Yrr.Utils;


namespace Game
{
    internal sealed class CharactersGenerationStorage : MonoBehaviour
    {
        [SerializeField] public Sprite[] MaleFaces;
        [SerializeField] public Sprite[] FemaleFaces;

        [Space]
        [TextArea]
        [SerializeField] private string maleNames;
        [SerializeField] public string[] MaleNames;
        [TextArea]
        [SerializeField] private string femaleNames;
        [SerializeField] public string[] FemaleNames;

        [Space]
        [TextArea]
        [SerializeField] private string surnames;
        [SerializeField] public string[] Surnames;



        [ContextMenu("RegenerateNames")]
        private void RegenerateNames()
        {
            MaleNames = maleNames.Replace(" ", "").Split(",", System.StringSplitOptions.RemoveEmptyEntries);
            FemaleNames = femaleNames.Split(",", System.StringSplitOptions.RemoveEmptyEntries);
            Surnames = surnames.Split(",", System.StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
