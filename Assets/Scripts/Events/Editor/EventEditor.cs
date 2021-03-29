using UnityEditor;
using UnityEngine;

namespace Beweegmaatje.Events
{
    [CustomEditor(typeof(BaseGameEvent<>), editorForChildClasses: true)]
    public class EventEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            var e = target as VoidEvent;
            if (GUILayout.Button("Raise"))
                e.Raise();
        }
    }
}