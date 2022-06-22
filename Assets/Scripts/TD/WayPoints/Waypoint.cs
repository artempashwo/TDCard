using UnityEngine;

namespace TD.WayPoints {
    public class Waypoint : MonoBehaviour {
        public Vector3[] pointsArr;
        [HideInInspector] public Vector3 currentPosition;

        private bool gameStart;

        private void Start() {
            gameStart = true;
            currentPosition = transform.position;
        }

        public Vector3 GetWaypointsPosition(int index) {
            return currentPosition + pointsArr[index]; 
        }

        private void OnDrawGizmos() {
            if (!gameStart && transform.hasChanged) {
                currentPosition = transform.position;
            }

            for (var i = 0; i < pointsArr.Length; i++) {
                Gizmos.color = Color.black;
                Gizmos.DrawWireSphere(pointsArr[i] + currentPosition, .5f);

                if (i >= pointsArr.Length - 1) continue;
                Gizmos.color = Color.gray;
                Gizmos.DrawLine(pointsArr[i] + currentPosition, pointsArr[i + 1] + currentPosition);
            }
        }
    }
}
