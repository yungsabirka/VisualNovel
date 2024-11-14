using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace VisualNovel.Scripts.UI
{
    [RequireComponent(typeof(Button))]
    public class MapButtonLocker : MonoBehaviour
    {
        [SerializeField] private GameObject _lockState;
        private Button _button;

        public void ToggleLockState(bool isLocked)
        {
            if(_button == null)
                _button = GetComponent<Button>();
            
            _lockState.SetActive(isLocked);
            _button.interactable = !isLocked;
        }
    }
}
