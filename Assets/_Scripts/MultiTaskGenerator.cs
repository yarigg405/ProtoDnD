using Game.DnD;
using Sirenix.OdinInspector;
using System;
using UnityEngine;
using Yrr.Utils;


namespace Game
{
    internal sealed class MultiTaskGenerator : MonoBehaviour
    {
        [SerializeField] private UnityDictionary<CharacterStats, float> statsSetup;
        [SerializeField] private Transform newTaskParent;
        private RandomizerByWeight<CharacterStats> _randomizator = new();


        [Button]
        public void GenerateMultitask()
        {
            FillRandomizator();

            var go = new GameObject("MultiTask");
            go.transform.parent = newTaskParent;
            var task = go.AddComponent<MultiTask>();
            task.difficult = UnityEngine.Random.Range(8, 17);
            task.targetCount = UnityEngine.Random.Range(20, 75);
            var stat = _randomizator.GetRandom();
            task.checkStat = stat;
        }

        private void FillRandomizator()
        {
            if (_randomizator.Count == 0)
            {
                foreach (CharacterStats item in (CharacterStats[])Enum.GetValues(typeof(CharacterStats)))
                {
                    if (statsSetup.TryGet(item, out var weight))
                    {
                        _randomizator.AddVariant(item, weight);
                    }
                }
            }
        }
    }
}
