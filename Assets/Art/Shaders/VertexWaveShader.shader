Shader "Custom/VertexWaveShader"
{
    Properties
     {
      _MainTex ("Texture", 2D) = "white" {}
      _BumpMap ("Bumpmap", 2D) = "bump" {}
      _Metal ("Metal", Float) = 1
      _Smooth ("Smooth", Float) = 1
	  _Speed ("Speed", Float) = 1
	  _Amount("Offset Amount", Float) = -1.1
    }
 
    SubShader
        {
      Tags { "RenderType" = "Opaque" }
     
            CGPROGRAM
            #pragma surface surf Standard fullforwardshadows vertex:vert
     
            struct Input {
				float2 uv_MainTex;
				float2 uv_BumpMap;
			};
     
            sampler2D _MainTex;
            sampler2D _BumpMap;
            float _Metal;
            float _Smooth;
            float _Amount;
			float _Speed;

	  void vert (inout appdata_full v) {
	      float phase = _Time * _Speed;
		  float4 wpos = mul(unity_ObjectToWorld, v.vertex);
		  float offset = (wpos.x + (wpos.z * 0.2)) * 0.5;

		  wpos.x = wpos.x + sin(phase - offset) * _Amount;
		  wpos.y = wpos.y + sin(phase + offset) * _Amount;
		  wpos.z = wpos.z + sin(phase) * _Amount;

		  v.vertex.xyz = mul(unity_WorldToObject, wpos);
	      
	  }
     
      void surf (Input IN, inout SurfaceOutputStandard o) {
      
      o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
      o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_BumpMap));
      o.Metallic = _Metal;
      o.Smoothness = _Smooth;

      }

      ENDCG
    }
    Fallback "Diffuse"
}
