Shader "Custom/DoubleSide"
{
	Properties
	{
		_Colour ("Colour", Color) = (1,1,1,1)
	}

	SubShader
	{
		Tags{ "Queue" = "Transparent" }

		Cull Off
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			uniform float4 _Colour;

			struct VIn
			{
				float4 pos : POSITION;
				float4 col : COLOR0;
			};

			struct VOut
			{
				float4 pos : SV_POSITION;
				float4 col : COLOR0;
			};

			VOut vert(VIn i)
			{
				VOut o;
				o.pos = mul(UNITY_MATRIX_MVP, i.pos);
				o.col = _Colour;

				return o;
			}

			float4 frag(VOut i) : COLOR
			{
				return i.col;
			}

			ENDCG
		}
	}

	FallBack "Diffuse"
}
