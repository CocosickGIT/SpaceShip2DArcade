using UnityEngine;

namespace Api
{
    public class GameState : MonoBehaviour
    {
        public static bool IsGamePaused;

        private void Awake() => IsGamePaused = false;
    }
}
