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
        private UnityEngine.Rendering.CompareFunction _desiredUIComparison = UnityEngine.Rendering.CompareFunction.Always; //If you want to try out other effects

        [Tooltip("Set to blank to automatically populate from the child UI elements")]
        [SerializeField]
        private Graphic[] _uiElementsToApplyTo;
        //Allows us to reuse materials
        private Dictionary<Material, Material> _materialMappings = new Dictionary<Material, Material>();
        protected virtual void Start()
        {
            if (_uiElementsToApplyTo.Length == 0)
            {
                _uiElementsToApplyTo = gameObject.GetComponentsInChildren<Graphic>();
            }
            foreach (var graphic in _uiElementsToApplyTo)
            {
                Material material = graphic.materialForRendering;
                if (material == null)
                {
                    continue;
                }
                if (!_materialMappings.TryGetValue(material, out Material materialCopy))
                {
                    materialCopy = new Material(material);
                    _materialMappings.Add(material, materialCopy);
                }
                materialCopy.SetInt(_shaderTestMode, (int)_desiredUIComparison);
                graphic.material = materialCopy;
            }
        }
    }
}
