Shader "Custom/1" {
    Properties{
        _Color("��ɫ", Color) = (1,1,1,1)
        _MainTex("����ͼ (RGB)", 2D) = "white" {}
        _Glossiness("ƽ����", Range(0,1)) = 0.5
        _Metallic("������", Range(0,1)) = 0.0
        _NoiseTex("������ͼ (R)",2D) = "white"{}
        _EdgeWidth("��Ե���",Range(0,0.5)) = 0.1
        _EdgeColor("��Ե��ɫ",Color) = (1,1,1,1)
        _EdgeThresholdValue("Ӳ��Ե��ֵ(0Ϊ��ʹ��)",Range(0,1)) = 0.5
        _DissolvePercentage("�ܽ�ٷֱ�",Range(0,1)) = 0
    }

        SubShader{
                Tags { "RenderType" = "Opaque" }
                LOD 200
                CGPROGRAM
            // Physically based Standard lighting model, and enable shadows on all light types
            //ԭ����ָ��
            //#pragma surface surf Standard fullforwardshadows
            //����addshadow�Ի����ȷ����Ӱ
            #pragma surface surf Standard fullforwardshadows addshadow
            // Use shader model 3.0 target, to get nicer looking lighting
            #pragma target 3.0
            sampler2D _MainTex;
            sampler2D _NoiseTex;
            float _EdgeWidth;
            float4 _EdgeColor;
            float _EdgeThresholdValue;
            float _DissolvePercentage;

            struct Input {
                float2 uv_MainTex;
                float3 worldPos;
            };

            half _Glossiness;
            half _Metallic;
            fixed4 _Color;

            void surf(Input IN, inout SurfaceOutputStandard o) {

                // Albedo comes from a texture tinted by color
                fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
                o.Albedo = c.rgb;
                // Metallic and smoothness come from slider variables
                o.Metallic = _Metallic;
                o.Smoothness = _Glossiness;
                o.Alpha = c.a;
                float DissolveFactor = saturate(_DissolvePercentage);
                //ʹ�ù̶�����
                // float noiseValue = tex2D(_NoiseTex,IN.uv_MainTex).r;   
                //ʹ����������
                float noiseValue = tex2D(_NoiseTex,IN.worldPos.rg).r;

                //�����ֵ��Ӧ����ͼ��ֵ����������

                if (noiseValue <= DissolveFactor)
                {
                    discard;
                }
                float4 texColor = tex2D(_MainTex,IN.uv_MainTex) * _Color;
                float EdgeFactor = saturate((noiseValue - DissolveFactor) / (_EdgeWidth * DissolveFactor));
                float4 BlendColor = texColor * _EdgeColor;

                if (_EdgeThresholdValue > 0) {
                    //��ʹ�ý��䣨Ӳ��Ե��
                    float HardEdgeFactor = EdgeFactor;
                    if (HardEdgeFactor > _EdgeThresholdValue) {
                        HardEdgeFactor = 1;
                        o.Emission = 0;
                    }
    else {
       HardEdgeFactor = 0;
       o.Emission = _EdgeColor;
   }
       o.Albedo = lerp(texColor,BlendColor,1 - EdgeFactor);
   }
else {
   o.Emission = 0;
   //ʹ�ý��䣨���Ե��
if (_EdgeThresholdValue >= 1) {
    o.Albedo = BlendColor;
    o.Alpha = 0;
}
else {
   o.Albedo = lerp(texColor,BlendColor,1 - EdgeFactor);
}
}
}
ENDCG
        }
            FallBack "Diffuse"
}
��������������������������������
��Ȩ����������ΪCSDN����������ĳ�ˡ���ԭ�����£���ѭCC 4.0 BY - SA��ȨЭ�飬ת���븽��ԭ�ĳ������Ӽ���������
ԭ�����ӣ�https ://blog.csdn.net/qq_27534999/article/details/79452620