using Naninovel;

namespace VisualNovel.Scripts.Commands
{
    public class SwitchToNovelMode : Command
    {
        private readonly StringParameter _scriptName;
        private readonly StringParameter _label;

        public SwitchToNovelMode(StringParameter scriptName, StringParameter label)
        {
            _scriptName = scriptName;
            _label = label;
        }
        
        public override async UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            var naniCamera = Engine.GetService<ICameraManager>().Camera;
            naniCamera.enabled = true;
            
            if (Assigned(_scriptName))
            {
                var scriptPlayer = Engine.GetService<IScriptPlayer>();
                await scriptPlayer.PreloadAndPlayAsync(_scriptName, label: _label);
            }
            
            var inputManager = Engine.GetService<IInputManager>();
            inputManager.ProcessInput = true;
        }
    }
}