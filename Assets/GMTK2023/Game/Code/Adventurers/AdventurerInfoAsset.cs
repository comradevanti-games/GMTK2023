﻿using UnityEngine;

namespace GMTK2023.Game
{
    [CreateAssetMenu(fileName = "New Adventurer-info", menuName = "GMTK2023/Adventurer-info")]
    public class AdventurerInfoAsset : ScriptableObject, IAdventurerInfo
    {
        [SerializeField] [Range(0, 1)] private float moveChance;
        [SerializeField] [Range(0, 1)] private float randomWalkChance;

        /// <remarks>We use the asset name as the adventurers title</remarks>>
        public string Title => name;

        public float MoveChance => moveChance;

        public float RandomWalkChance => randomWalkChance;
    }
}