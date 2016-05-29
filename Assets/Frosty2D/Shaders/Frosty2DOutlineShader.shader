Shader "Frosty/Outline"
{
	Properties
	{
		[Header(Texture)]
		_MainTex ("Main Texture", 2D) = "white" {}
		[Header(Color)]
		_Color("Tint", Color) = (1,1,1,1)
	}
	SubShader
	{
		Pass
		{
			Name "Outline1"
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"
			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float2 screenPos:TEXCOORD2;
				UNITY_FOG_COORDS(1)
					float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _MainTex_TexelSize;
			fixed4 _Color;

			v2f vert(appdata v)
			{
				v2f o;
				UNITY_INITIALIZE_OUTPUT(v2f, o);

				v.vertex.x -= 2;
				v.vertex.x *= 1.1;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.vertex = UnityPixelSnap(o.vertex);
				o.screenPos = ComputeScreenPos(o.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);

				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv) * _Color;
				return fixed4(_Color.rgb, col.a);
			}

			ENDCG
		}		
	}
}