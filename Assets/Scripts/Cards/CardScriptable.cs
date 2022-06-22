using UnityEngine;

namespace Cards {
    [CreateAssetMenu (fileName = "Card data", menuName = "Cards")]
    public class CardScriptable : ScriptableObject {
        public string cardName;
        public int cost;
        public int speed;
        public int sellCost;
        public int range;

        public Sprite image;
    }
}
