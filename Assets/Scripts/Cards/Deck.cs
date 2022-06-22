using System.Collections.Generic;
using UnityEngine;

namespace Cards {
    public class Deck : MonoBehaviour {
        public List<GameObject> cardDeck;
        public List<GameObject> cardHand = new List<GameObject>();

        private const int DeckSize = 10;
        private GameObject container;
        public List<GameObject> cardType;

        private void Awake() {
            cardDeck = new List<GameObject>(DeckSize);

            for (var i = 0; i < DeckSize; i++) {
                cardDeck.Add(cardType[Random.Range(0, cardType.Capacity)]);
            }
        }

        private void DrawCard() {
            if (cardDeck.Count == 0) return;
            var card = cardDeck[0];
            cardDeck.Remove(cardDeck[0]); 
            cardHand.Add(card);
        }
        
        

        public void DrawCards(int drawQuantity) {
            for (var i = 0; i < drawQuantity; i++) {
                DrawCard();
            }
        }

        public void DeckShuffle() {
                for (var i = 0; i < cardDeck.Count; i++) {
                    container = cardDeck[i];
                    var rand = Random.Range(i, cardDeck.Count);
                    cardDeck[i] = cardDeck[rand];
                    cardDeck[rand] = container;
                }
        }
    } 
}
