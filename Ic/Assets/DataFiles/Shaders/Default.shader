Shader "Unlit/Default"
{
    Properties
    {
        _Color("Color", Color) = (1, 1, 1, 1)
        _Brightness("Brightness", Range(0.5, 1.1)) = 0.8
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
            };

            Interpolators vert (MeshData v)
            {
                Interpolators o;
                o.vertex = UnityObjectToClipPos( v.vertex ); //clip space position
                o.normal = UnityObjectToWorldNormal( v.normal );
                return o;
            }


            float4 frag (Interpolators i) : SV_Target
            {
                return float4 ( _Color.rgb * _Brightness, 1 );
            }
            ENDCG
        }
    }
}
