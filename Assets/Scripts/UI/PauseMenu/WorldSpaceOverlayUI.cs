using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LekAanDek.UI
{
    /// <summary>
    /// This script is used to render UI infront of everything
    /// </summary>
    [ExecuteInEditMode] //Disable if you don't care about previewing outside of play mode
    public class WorldSpaceOverlayUI : MonoBehaviour
    {
        private const string _shaderTestMode = "unity_GUIZTestMode"; //The magic property we need to set

        [SerializeField]
        public UnityEngine.Rendering.CompareFunction desiredUIComparison = UnityEngine.Rendering.CompareFunction.Always; //If you want to try out other effects

        [Tooltip("Set to blank to automatically populate from the child UI elements")]
        [SerializeField]
        public Graphic[] uiElementsToApplyTo;
        //Allows us to reuse materials
        private Dictionary<Material, Material> materialMappings = new Dictionary<Material, Material>();
        protected virtual void Start()
        {
            if (uiElementsToApplyTo.Length == 0)
            {
                uiElementsToApplyTo = gameObject.GetComponentsInChildren<Graphic>();
            }
            foreach (var graphic in uiElementsToApplyTo)
            {
                Material material = graphic.materialForRendering;
                if (material == null)
                {
                    Debug.LogError($"{nameof(WorldSpaceOverlayUI)}: skipping target without material {graphic.name}.{graphic.GetType().Name}");
                    continue;
                }
                if (!materialMappings.TryGetValue(material, out Material materialCopy))
                {
                    materialCopy = new Material(material);
                    materialMappings.Add(material, materialCopy);
                }
                materialCopy.SetInt(_shaderTestMode, (int)desiredUIComparison);
                graphic.material = materialCopy;
            }
        }
    }
}
