Shader "Unlit/BackgroundShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color", color) = (1,1,1,1)
        _Amp("Amp", float) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }
        LOD 100

        Pass
        {
                                    
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"

            #define TAU 6.28318530718
            float4 _Color;
            float _Amp;
                   
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            float4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv;
                float center = uv * 2 - 1;
                float radialDistance = length(center);
                
                // uv.y = cos(_Time.y*2)* i.uv.y + _Time.y * 0.5 * _Amp; //jump
                uv.y += _Time.y * _Amp;
                
                float4 tex = tex2D(_MainTex, uv);

                float wave = radialDistance - 1 * cos((uv.y - _Time.y * 0  +1) * TAU) * 1.5 + 1.5;
                                
                return wave * tex * _Color * 1;
            }
            ENDCG
        }
    }
}
