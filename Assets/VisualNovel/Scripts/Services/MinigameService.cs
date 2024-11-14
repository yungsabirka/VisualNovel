using System;
using Naninovel;
using UnityEngine;
using VisualNovel.Scripts.Commands;
using VisualNovel.Scripts.Minigame.impl;
using Object = UnityEngine.Object;

namespace VisualNovel.Scripts.Services
{
    [InitializeAtRuntime]
    public class MinigameService : IEngineService
    {
        private const string MinigamePath = "Minigame/MinigamePrefab";
        private const string NextNovelScriptName = "Bar";
        private const string NextNovelLabelName = "MinigameEnded";

        private GameObject _minigamePrefab;
        private bool _isInitialized;
        
        public UniTask InitializeServiceAsync()
        {
            _minigamePrefab = Resources.Load<GameObject>(MinigamePath);
            
            if(_minigamePrefab == null)
                throw new Exception("Minigame Prefab could not be loaded.");

            _isInitialized = true;
            return UniTask.CompletedTask;
        }

        public UniTask StartMinigameAsync()
        {
            if(_isInitialized == false) throw new Exception("Minigame service is not initialized.");
                
            var minigame = Object.Instantiate(_minigamePrefab);
            var gameManager = minigame.GetComponentInChildren<NovelMemoryGameManager>();

            gameManager.Finished += OnFinishMinigame;
            
            void OnFinishMinigame()
            {
                var switchCommand = new SwitchToNovelMode(NextNovelScriptName, NextNovelLabelName);
                switchCommand.ExecuteAsync().Forget();
                gameManager.Finished -= OnFinishMinigame;
            }
            
            return UniTask.CompletedTask;
        }

        public void ResetService()
        {
            
        }

        public void DestroyService()
        {
            
        }
    }
}