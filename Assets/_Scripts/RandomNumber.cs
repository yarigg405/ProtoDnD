using UnityEngine;


namespace Game
{
    internal sealed class RandomNumber : MonoBehaviour
    {
        [SerializeField] private int minNumber = 1;
        [SerializeField] private int maxNumber = 20;

        [ContextMenu("Randomize")]
        public void Randomize()
        {
            var num = Random.Range(minNumber, maxNumber + 1);
            Debug.Log(num);
        }

    }
}
