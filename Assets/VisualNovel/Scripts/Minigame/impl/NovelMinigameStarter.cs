using DTT.MinigameMemory;
using UnityEngine;

namespace VisualNovel.Scripts.Minigame.impl
{
    /// <summary>
    /// Used to start the memory minigame throught the <see cref="MemoryGameManager"/>.
    /// </summary>
    public class NovelMinigameStarter : MonoBehaviour
    {
        /// <summary>
        /// Used to manipulate the game flow.
        /// </summary>
        [SerializeField] private NovelMemoryGameManager _memoryGameManager;

        /// <summary>
        /// Settings used for this game.
        /// </summary>
        [SerializeField] private MemoryGameSettings _gameSettings;


        /// <summary>
        /// Starts a new memory minigame.
        /// </summary>
        private void Start() => _memoryGameManager.StartGame(_gameSettings);
    }
}