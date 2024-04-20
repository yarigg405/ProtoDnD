using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Game.DnD;


namespace Game
{
    internal sealed class Task : MonoBehaviour
    {
        [TextArea]
        [SerializeField] private string description;



        [SerializeField] private CharacterStats CheckStat;

    }
}
