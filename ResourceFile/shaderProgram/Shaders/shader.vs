#version 330 core
layout(location = 0) in vec3 aPos;
layout(location = 1) in vec3 aColor;
uniform float ourOffset;
out vec3 ourColor;
out vec3 ourColor2;
void main()
{
   gl_Position=vec4(aPos.x,aPos.y,aPos.z,1.0)+vec4(ourOffset,0,0,0);
   ourColor=aColor;
   ourColor2=aPos;
}