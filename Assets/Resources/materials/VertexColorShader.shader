Shader "Custom/VertexColorShader" {	
	Properties {		
		_Color ("Color", Color) = (1.00, 1.00, 1.00, 1.00) // white
	}
	SubShader {		
		Tags { "RenderType"="Opaque" }
		LOD 200		
       
		CGPROGRAM		
		#pragma surface surf Lambert 
		
		fixed4 _Color; 
		
		struct Input {						
			float4 color : COLOR;
		}; 
		
		void surf (Input IN, inout SurfaceOutput o) {			
			o.Albedo = IN.color.rgb * _Color.rgb;			
		}
		ENDCG
	} 	
	FallBack "Diffuse"
}