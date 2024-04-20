using UnityEngine;
using Yrr.Utils;


namespace Game.DnD
{

    [CreateAssetMenu(fileName = "NewCharacter", menuName = "Characters/Character", order = 51)]
    [System.Serializable]
    internal sealed class Character : ScriptableObject
    {
        public bool IsFemale;
        public int NameIndex;
        public int SurnameIndex;
        public int IconIndex;
        public UnityDictionary<CharacterStats, int> Stats = new();

        [Space]
        [Space]

        public string VisualName;

        [ReadOnly]
        public Sprite VisualIcon;


        [Header("Заметки, описание")]
        [TextArea]
        [SerializeField] private string notes;
    }
}
