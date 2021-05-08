#version 330 core

in vec3 Normal;
in vec3 FragPos;

uniform vec3 viewPos;

struct Material{
   vec3 ambient; 
   vec3 diffuse;   
   vec3 specular; 
   float shininess; 
};


struct Light{
   vec3 position;
   
   vec3 ambient;
   vec3 diffuse;
   vec3 specular;
};


uniform Material material;
uniform Light light;


out vec4 FragColor;

void main()
{
    //环境光
	vec3 ambient=light.ambient * material.ambient;
	
	//漫反射
	vec3 norm=normalize(Normal);
	vec3 lightDir=normalize(light.position-FragPos);
	float diff=max(dot(norm,lightDir),0.0);
	vec3 duffuse=light.diffuse*(diff*material.diffuse);
	
	//高光反射
	vec3 viewDir=normalize(viewPos-FragPos);
	vec3 reflectDir=reflect(-lightDir,norm);
	float spec=pow(max(dot(viewDir,reflectDir),0.0),material.shininess);
	vec3 specular=light.specular*(spec*material.specular);
	
	vec3 res=ambient+duffuse+specular;
	FragColor=vec4(res,1.0);
}