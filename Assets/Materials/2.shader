// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/2"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_NoiseTex("Noise", 2D) = "white" {}
		_Threshold("Threshold", Range(0.0, 1.0)) = 0.5
		_EdgeLength("Edge Length", Range(0.0, 0.2)) = 0.1
		_EdgeFirstColor("First Edge Color", Color) = (1,1,1,1)
		_EdgeSecondColor("Second Edge Color", Color) = (1,1,1,1)
	}
		SubShader
		{
			Tags { "Queue" = "Geometry" "RenderType" = "Opaque" }

			Pass
			{
				Cull Off //Ҫ��Ⱦ���汣֤Ч����ȷ

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
					float4 vertex : SV_POSITION;
					float2 uvMainTex : TEXCOORD0;
					float2 uvNoiseTex : TEXCOORD1;
				};

				sampler2D _MainTex;
				float4 _MainTex_ST;
				sampler2D _NoiseTex;
				float4 _NoiseTex_ST;
				float _Threshold;
				float _EdgeLength;
				fixed4 _EdgeFirstColor;
				fixed4 _EdgeSecondColor;

				v2f vert(appdata v)
				{
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.uvMainTex = TRANSFORM_TEX(v.uv, _MainTex);
					o.uvNoiseTex = TRANSFORM_TEX(v.uv, _NoiseTex);
					return o;
				}

				fixed4 frag(v2f i) : SV_Target
				{
					//�ο�
					fixed cutout = tex2D(_NoiseTex, i.uvNoiseTex).r;
					clip(cutout - _Threshold);

					float degree = saturate((cutout - _Threshold) / _EdgeLength);
					fixed4 edgeColor = lerp(_EdgeFirstColor, _EdgeSecondColor, degree);

					fixed4 col = tex2D(_MainTex, i.uvMainTex);

					fixed4 finalColor = lerp(edgeColor, col, degree);
					return fixed4(finalColor.rgb, 1);
				}
				ENDCG
			}
		}
}

