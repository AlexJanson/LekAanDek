// This script has been pulled from the Unity Wiki
// It fixes the layering of the 3D texts in the world by using the Z axis
//
// Source: http://wiki.unity3d.com/index.php?title=3DText

Shader "GUI/3D Text Shader - Cull Back" {
	Properties{
		_MainTex("Font Texture", 2D) = "white" {}
		_Color("Text Color", Color) = (1,1,1,1)
	}

		SubShader{
			Tags { "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
			Lighting Off Cull Back ZWrite Off Fog { Mode Off }
			Blend SrcAlpha OneMinusSrcAlpha
			Pass {
				Color[_Color]
				SetTexture[_MainTex] {
					combine primary, texture * primary
				}
			}
		}
}