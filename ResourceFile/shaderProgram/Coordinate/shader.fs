#version 330 core
out vec4 fragColor;

in vec2 TexCoord;

uniform sampler2D texture1;
uniform sampler2D texture2;
void main()
{  
   fragColor=  mix(texture(texture1,TexCoord),texture(texture2,TexCoord),0.2);
}