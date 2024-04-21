using Game.DnD;
using UnityEngine;


namespace Game
{
    internal sealed class Task : MonoBehaviour
    {
        [TextArea]
        [SerializeField] private string description;


        [Space]
        [SerializeField] private Character character;
        [SerializeField] private CharacterStats checkStat;
        [SerializeField] private int difficult = 10;


        [ContextMenu("Check")]
        public void CheckTask()
        {
            var value = Random.Range(1, 21);
            var modifier = character.GetStatBonus(checkStat);

            var result = value + modifier;





            var resultString = $"Dice result is: {value}. Result is: {result}. ";

            if (value == 20)
            {
                resultString += "<color=#39A439>CRITICAL SUCCESS!!</color>";
            }

            else if (value == 1)
            {
                resultString += "<color=red>CRITICAL FAILIRE!!</color>";
            }

            else if (result >= difficult)
            {
                resultString += "<color=#39A439>Success!!</color>";
            }

            else
            {
                resultString += "<color=red>Failure!!</color>";
            }

            Debug.Log(resultString);
        }
    }
}
