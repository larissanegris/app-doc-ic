Shader "Custom/OpaqueSphere"{
    Properties{
        _Color("Tint", Color) = (0, 0, 0, 1)
        _Brightness("Brightness", Range(0, 1)) = 0.8

    }

        SubShader{
            Tags{ "RenderType" = "Transparent" "Queue" = "Transparent"}

            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite off

            Pass{

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "AutoLight.cginc"

            float _Brightness;
            float4 _Color;

            //Preenchido automaticamente pela unity
            struct MeshData //per vertex mesh data
            {
                float4 vertex : POSITION;
                float3 normal: NORMAL;
                float4 uv0 : TEXCOORD0;
            };

            struct Interpolators
            {
                float4 vertex : SV_POSITION;
                float3 normal : TEXCOORD0;
                float3 wPos : TEXCOORD1;
            };

            Interpolators vert(MeshData v)
            {
                Interpolators o;
                o.vertex = UnityObjectToClipPos(v.vertex); //clip space position
                o.normal = UnityObjectToWorldNormal(v.normal);
                o.wPos = mul(unity_ObjectToWorld, v.vertex);
                return o;
            }


            float4 frag(Interpolators i) : SV_Target
            {
                float3 surfaceColor = _Color.rgb;
                _Brightness = (_Brightness * 0.8) + 0.5;

                float3 N = normalize(i.normal);
                float3 L = normalize(UnityWorldSpaceLightDir(i.wPos));
                float attenuation = LIGHT_ATTENUATION(i);
                float3 lambert = saturate(dot(N, L));
                float3 diffuseLight = (lambert * attenuation * _Brightness) * _LightColor0.xyz;

                float3 V = normalize(_WorldSpaceCameraPos - i.wPos);
                float3 H = normalize(L + V);


                return float4 (diffuseLight * surfaceColor, 1);
            }

                ENDCG
            }
    }
}