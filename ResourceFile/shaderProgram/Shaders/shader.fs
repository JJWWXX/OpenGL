#version 330 core
out vec4 fragColor;
in vec3 ourColor;
in vec3 ourColor2;
void main()
{
   fragColor=vec4(ourColor2,1.0);
}