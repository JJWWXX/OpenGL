#version 330 core
out vec4 FragColor;

in vec2 TexCoord;

uniform sampler2D texture1;
void main()
{
  //vec4 texColor=texture(texture1,TexCoord);
  //if(texColor.a<0.1f)
  //{
    //discard;
  //}
  //FragColor=texColor;
  //FragColor = vec4(vec3(gl_FragCoord.z), 1.0);
  FragColor=texture(texture1,TexCoord);
}