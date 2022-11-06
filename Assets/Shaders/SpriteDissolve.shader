Shader "SiriusFutureQuiz/SpriteDissolve"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)

		_DissolveTex("Dissolve Texutre", 2D) = "white" {}
        
		_DissolveColor1 ("DissolveTint1", Color) = (1,1,1,1)
		_Size1("Size1", Range(0,1)) = 0.01
		_Softess1("Softess1", Range(0,1)) = 0.01
		
		_DissolveColor2 ("DissolveTint2", Color) = (1,1,1,1)
		_Size2("Size2", Range(0,1)) = 0.01
		_Softess2("Softess2", Range(0,1)) = 0.01

        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
        [HideInInspector] _RendererColor ("RendererColor", Color) = (1,1,1,1)
        [HideInInspector] _Flip ("Flip", Vector) = (1,1,1,1)
        [PerRendererData] _AlphaTex ("External Alpha", 2D) = "white" {}
        [PerRendererData] _EnableExternalAlpha ("Enable External Alpha", Float) = 0
		[Enum(UnityEngine.Rendering.BlendMode)] _SrcMode("SrcMode", Float) = 5
		[Enum(UnityEngine.Rendering.BlendMode)] _DstMode("DstMode", Float) = 10
        [Enum(UnityEngine.Rendering.CompareFunction)] _ZTest("ZTest", Float) = 4
    }

    SubShader
    {
        Tags
        {
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }

        Cull Off
        Lighting Off
        ZWrite Off
        ZTest[_ZTest]
        Blend[_SrcMode][_DstMode]

        Pass
        {
        CGPROGRAM
            #pragma vertex SpriteVert
            #pragma fragment SpriteFragDissolve
            #pragma target 2.0
            #pragma multi_compile_instancing
            #pragma multi_compile _ PIXELSNAP_ON
            #pragma multi_compile _ ETC1_EXTERNAL_ALPHA
            #include "UnitySprites.cginc"

			sampler2D _DissolveTex;
			
			half4 _DissolveColor1;
			half _Size1;
			half _Softess1;
			
			half4 _DissolveColor2;
			half _Size2;
			half _Softess2;

			fixed4 GetDissolve(fixed4 textureColor, fixed4 dissolve, fixed amount)
			{
				half t = (1 + 2 * _Size1 + 2 * _Softess1) *amount - _Size1 - _Softess1;
						
				fixed4 color = textureColor;
				fixed contourMin = smoothstep(t - _Size1 - _Softess1, t - _Size1, dissolve.a);
				fixed contourMax = smoothstep(t + _Size1 + _Softess1, t + _Size1, dissolve.a);

				fixed contourMin2 = smoothstep(t - _Size2 - _Softess2, t - _Size2, dissolve.a);
				fixed contourMax2 = smoothstep(t + _Size2 + _Softess2, t + _Size2, dissolve.a);

				color.rgb = lerp(color.rgb, _DissolveColor1.rgb, contourMax) + _DissolveColor2.rgb*contourMin2*contourMax2;
				color.a *= contourMin;
				return color;
			}

			fixed4 SpriteFragDissolve(v2f IN) : SV_Target
			{
				fixed4 textureColor = SampleSpriteTexture(IN.texcoord);
				fixed4 dissolve = tex2D(_DissolveTex, IN.texcoord);
				dissolve.a = dissolve.r;
				fixed4 finalColor = GetDissolve(textureColor, dissolve, 1.0 - IN.color.a);
				finalColor.rgb *= IN.color.rgb;
				return finalColor;
			}
		ENDCG
        }
    }
}