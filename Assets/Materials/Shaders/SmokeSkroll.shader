// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/SmokeSkroll"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color", color) = (1,1,1,1)
        _Amp("SkrollSpeed", float) = 0.1
        _Transparency("Transparency" , float) = 0.3
    }
    SubShader
    {
        Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
//        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha
//        Cull front 
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
            float _Transparency;
            
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

            fixed4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv;

                float center = uv * 2 - 1;
                float radialDistance = length(center);
                
                uv.x += _Time.y * _Amp;
                
                float4 tex = tex2D(_MainTex, uv) * _Color * _Transparency * cos(pow(_Time.y,-2));
                float wave = radialDistance - 1.3 * cos((uv.x + 1) * TAU) * 2.2 + 2;
                float wave2 = cos((uv.x + 1) * TAU) * 2.2 + 2  * tan(cos(cos(cos(pow(_Time.y * 0.2, 0.3)*0.2)*15)*1.5));
                                
                return wave * wave2 * tex ;
            }
            ENDCG
        }
    }
}
