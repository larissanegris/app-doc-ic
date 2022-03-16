Shader "Custom/TransparentCube"{
    Properties{
        _Color("Tint", Color) = (0, 0, 0, 1)
        _Transparency("Transparency", Range(0, 1)) = 1
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

            float _Transparency, _Brightness;
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
                float3 N = normalize(i.normal);
                float3 V = normalize(_WorldSpaceCameraPos - i.wPos);

                float fresnel = dot(V, N*2.5f);

                _Brightness = (_Brightness * 0.8) + 0.5;
                float4 saida = fresnel * _Brightness * _Color;
                saida.a = _Transparency;
                return (saida);
            }

				ENDCG
			}
	}
}