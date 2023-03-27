using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    [DefaultExecutionOrder(-10)]
    public class UIScore : MonoBehaviour
    {
        [SerializeField] private Text _text;
        public int ScoreValue;
        
        public void ScoreCount(int score)
        {
            ScoreValue += score;
            _text.text = "Score: " + ScoreValue;
        }
    }
}

