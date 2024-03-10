Shader "Hidden/Test"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _rand("Random Seed", Vector) = (12.9898,78.233,43758.5453)
        _sparkleSize("Sparkle Size", Range(0.01, 0.1)) = 0.02
        _sparkleColor("Sparkle Color", Color) = (1, 1, 1, 1)
        _sparkleIntensity("Sparkle Intensity", Range(0, 1)) = 0.5
        _sparkleFrequency("Sparkle Frequency", Range(0, 1)) = 0.5

    }
    SubShader
    {
        Cull Off ZWrite Off ZTest Always

        Pass
        {
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
                float4 vertex : SV_POSITION;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            uniform sampler2D _MainTex;
            uniform float3 _rand;
            uniform float _sparkleSize;
            uniform fixed4 _sparkleColor;
            uniform float _sparkleIntensity;
            uniform float _sparkleFrequency;

            float rand(float2 co)
            {
                return frac(sin(dot(co.xy, _rand.xy)) * _rand.z);
            }

            fixed4 applySparkleEffect(fixed4 col, float2 uv)
            {
                float2 sparkle_pos = float2(rand(uv.x + _Time * .5f), rand(uv.y + _Time * .5f));
                float sparkleBrightness = rand(uv.x + uv.y + _Time * .5f) * _sparkleIntensity;
                float dist = distance(uv, sparkle_pos);
                float freq = rand(uv + _Time * .5f);
                float mask = step(dist, _sparkleSize) * step(freq, _sparkleFrequency);
                col.rgb += _sparkleColor.rgb * sparkleBrightness * mask;
                return col;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                col = applySparkleEffect(col, i.uv);
                return col;
            }
            ENDCG
        }
    }
}