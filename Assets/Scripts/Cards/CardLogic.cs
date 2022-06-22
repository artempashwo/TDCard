using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Cards {
    public class CardLogic : MonoBehaviour {
        public CardScriptable cardData;

        public TextMeshProUGUI cost;
        public TextMeshProUGUI sellCost;
        public TextMeshProUGUI speed;
        public TextMeshProUGUI range;
        public TextMeshProUGUI cardName;

        public Image image;

        private void Start() {
            cost.text = cardData.cost.ToString();
            speed.text = cardData.speed.ToString();
            range.text = cardData.range.ToString();
            cardName.text = cardData.cardName;
            sellCost.text = cardData.sellCost.ToString();
            image.sprite = cardData.image;
        }
    }
}
