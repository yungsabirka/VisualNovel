using Naninovel;
using VisualNovel.Scripts.Services;

namespace VisualNovel.Scripts.Commands
{
    [CommandAlias("StartMiniGame")]
    public class StartMinigameCommand : Command
    {
        public override async UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            var inputManager = Engine.GetService<IInputManager>();
            inputManager.ProcessInput = false;
        
            var scriptPlayer = Engine.GetService<IScriptPlayer>();
            scriptPlayer.Stop();
        
            var naniCamera = Engine.GetService<ICameraManager>().Camera;
            naniCamera.enabled = false;

            var miniGameService = Engine.GetService<MinigameService>();
            await miniGameService.StartMinigameAsync();
        }
    }
}
