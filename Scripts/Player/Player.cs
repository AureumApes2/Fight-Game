using TMPro;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        public float points;
        public TMP_Text pointText;
        
        private void Update()
        {
            pointText.text = points.ToString();
        }
    }
}