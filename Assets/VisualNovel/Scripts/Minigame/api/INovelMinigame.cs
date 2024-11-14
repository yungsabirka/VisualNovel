using System;

namespace VisualNovel.Scripts.Minigame.api
{
    /// <summary>
    /// Contains the interface for handling a mini-game.
    /// </summary>
    /// <typeparam name="TConfig">The configuration of the mini-game.</typeparam>
    public interface INovelMinigame<in TConfig> : INovelMinigame
    {
        /// <summary>
        /// Is called when the game has started.
        /// </summary>
        event Action Started;
        
        /// <summary>
        /// Is called when the game has finished.
        /// </summary>
        event Action Finished;

        /// <summary>
        /// Is called when the user wants to start the game.
        /// </summary>
        void StartGame(TConfig config);
    }
    
    /// <summary>
    /// Contains the interface for handling a minigame.
    /// </summary>
    public interface INovelMinigame 
    {
        /// <summary>
        /// Is true when the game has started and isn't finished.
        /// </summary>
        bool IsGameActive { get; }
        
        /// <summary>
        /// Is called when the user want to force finish the game.
        /// </summary>
        void ForceFinish();
    }
}