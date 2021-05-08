#version 330 core
in vec3 Normal;
in vec3 fragPos;

out vec4 FragColor;

uniform vec3 objectColor;
uniform vec3 lightColor;
uniform vec3 lightPos;
uniform vec3 viewPos;

void main()
{  
   vec3 norm=normalize(Normal);
   vec3 lightDir=normalize(lightPos-fragPos);
   float diff=max(dot(norm,lightDir),0.0);
   vec3 duffuse=diff*lightColor;
   
   float specularStrength = 0.5;
   vec3 viewDir=normalize(viewPos-fragPos);
   vec3 reflectDir = reflect(-lightDir, norm);
   float spec = pow(max(dot(viewDir, reflectDir), 0.0), 32);
   vec3 specular = specularStrength * spec * lightColor;
   
   float ambientStrength=0.1;
   vec3 ambient=ambientStrength*lightColor;
   
   vec3 res=objectColor*(ambient+duffuse+specular);
   FragColor = vec4(res, 1.0);
}