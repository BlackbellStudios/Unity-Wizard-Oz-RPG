
Shader "twosided" {
    Properties {
        _Color ("Main Color", Color) = (0,0,0,0)
        _MainTex ("Base (RGB)", 2D) = "black" {}
        //_BumpMap ("Bump (RGB) Illumin (A)", 2D) = "bump" {}
    }
    SubShader {    
        //UsePass "Self-Illumin/VertexLit/BASE"
        //UsePass "Bumped Diffuse/PPL"
       
        // Ambient pass
        Pass {
        Name "BASE"
        Tags {"LightMode" = "Always" /* Upgrade NOTE: changed from PixelOrNone to Always */}
        Color [_PPLAmbient]
        SetTexture [_BumpMap] {
            constantColor (.10,.5,.5)
            combine constant lerp (texture) previous
            }
        SetTexture [_MainTex] {
            constantColor [_Color]
            Combine texture * previous DOUBLE, texture*constant
            }
        }
   
    // Vertex lights
    Pass {
        Name "BASE"
        Tags {"LightMode" = "Vertex"}
        Material {
            Diffuse [_Color]
            Emission [_PPLAmbient]
            Shininess [_Shininess]
            Specular [_SpecColor]
            }
        SeparateSpecular On
        Lighting On
        Cull Off
        SetTexture [_BumpMap] {
            constantColor (.3,.3,.3)
            combine constant lerp (texture) previous
            }
        SetTexture [_MainTex] {
            Combine texture * previous DOUBLE, texture*primary
            }
        }
    }
    FallBack "Diffuse", 0
}