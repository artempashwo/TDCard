using TD.WayPoints;
using UnityEditor;
using UnityEngine;

namespace Editor {
    [CustomEditor(typeof(Waypoint))]
    public class WaypointEditor : UnityEditor.Editor {
        private Waypoint Waypoint => target as Waypoint;
        
        private void OnSceneGUI() {
            Handles.color = Color.cyan;
            
            for (var i = 0; i < Waypoint.pointsArr.Length; i++) {
                EditorGUI.BeginChangeCheck();
                
                //Create Handles
                var currentWaypointPoint = Waypoint.currentPosition + Waypoint.pointsArr[i];
                var newWaypointPoint = Handles.FreeMoveHandle(currentWaypointPoint,
                    Quaternion.identity, .7f, new Vector3(.3f, .3f, .3f), Handles.SphereHandleCap);
                
                //Create text
                var textStyle = new GUIStyle {
                    fontStyle = FontStyle.Bold,
                    fontSize = 16,
                    normal = {
                        textColor = Color.white
                    }
                };
                var textAlignment = Vector3.down * .35f + Vector3.right * .35f;
                Handles.Label(Waypoint.currentPosition + Waypoint.pointsArr[i] + textAlignment, 
                    $"{i + 1}", textStyle);
                EditorGUI.EndChangeCheck();

                if (!EditorGUI.EndChangeCheck()) continue;
                Undo.RecordObject(target, "Free Move Handle");
                Waypoint.pointsArr[i] = newWaypointPoint - Waypoint.currentPosition;
            }
        }
    }
}