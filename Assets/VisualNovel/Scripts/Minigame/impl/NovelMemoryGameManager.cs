using System;
using DTT.MinigameMemory;
using UnityEngine;
using VisualNovel.Scripts.Minigame.api;

namespace VisualNovel.Scripts.Minigame.impl
{
    /// <summary>
    /// Class that functions as the minigame manager.
    /// </summary>
    public class NovelMemoryGameManager : MonoBehaviour, INovelMinigame<MemoryGameSettings>
    {
        /// <summary>
        /// Is called when the game has started.
        /// </summary>
        public event Action Started;


        /// <summary>
        /// Is called when the game has finished.
        /// </summary>
        public event Action Finished;


        /// <summary>
        /// Is true when the game is active.
        /// </summary>
        public bool IsGameActive => _isGameActive;

        /// <summary>
        /// The <see cref="Board"/> used for the minigame.
        /// </summary>
        [SerializeField] private Board _board;

        /// <summary>
        /// Is true when the game is paused.
        /// </summary>
        private bool _isPaused;

        /// <summary>
        /// Is true when the game has started and isn't finished.
        /// </summary>
        private bool _isGameActive;

        /// <summary>
        /// The GameSettings.
        /// </summary>
        private MemoryGameSettings _settings;

        /// <summary>
        /// The amount a player has tried to match two cards during the game.
        /// </summary>
        private int _amountOfTurns = 0;

        /// <summary>
        /// Starts the game with the given settings.
        /// </summary>
        /// <param name="settings">The settings used for this play session.</param>
        public void StartGame(MemoryGameSettings settings)
        {
            _settings = settings;
            _amountOfTurns = 0;
            _isPaused = false;
            _isGameActive = true;

            _board.SetupGame(_settings);
            Started?.Invoke();
        }


        /// <summary>
        /// Finishes the current game.
        /// </summary>
        public void ForceFinish()
        {
            _isGameActive = false;
            Finished?.Invoke();
            Destroy(transform.parent.gameObject);
        }

        /// <summary>
        /// Subscribe to board events.
        /// </summary>
        private void OnEnable()
        {
            _board.CardsTurned += IncreaseTurnAmount;
            _board.AllCardsMatched += ForceFinish;
        }

        /// <summary>
        /// Unsubscribe from board events.
        /// </summary>
        private void OnDisable()
        {
            _board.CardsTurned -= IncreaseTurnAmount;
            _board.AllCardsMatched -= ForceFinish;
        }

        /// <summary>
        /// Increases the amount of turns taken by one.
        /// </summary>
        private void IncreaseTurnAmount() => _amountOfTurns++;
    }
}