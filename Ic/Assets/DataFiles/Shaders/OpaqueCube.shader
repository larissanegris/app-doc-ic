Shader "Custom/OpaqueCube"
{
    Properties
    {
        _Color("Color", Color) = (1, 1, 1, 1)
        _Brightness("Brightness", Range(0, 1)) = 0.8
    }
    SubShader
    {
        //Shader tags
        Tags { "RenderType"="Opaque" }

        Pass
        {

            //pass tags

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

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

            Interpolators vert (MeshData v)
            {
                Interpolators o;
                o.vertex = UnityObjectToClipPos( v.vertex ); //clip space position
                o.normal = UnityObjectToWorldNormal( v.normal );
                o.wPos = mul(unity_ObjectToWorld, v.vertex);
                return o;
            }


            float4 frag (Interpolators i) : SV_Target
            {
                float3 N = normalize(i.normal);
                float3 V = normalize(_WorldSpaceCameraPos - i.wPos);

                float fresnel = dot(V, N*2);
                _Brightness = (_Brightness * 0.8) + 0.5;
                float4 saida = fresnel * _Brightness  * _Color;
                return saida;
            }
            ENDCG
        }
    }
}
