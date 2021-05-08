#version 330 core

in vec3 Normal;
in vec3 FragPos;
in vec2 TexCoords;

uniform vec3 viewPos;

struct Material{
   sampler2D diffuse;
   sampler2D specular; 
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
	//vec3 ambient=light.ambient * material.ambient;
	//vec3 ambient=light.ambient * vec3(texture(material.diffuse,TexCoords));
	vec3 ambient=light.ambient * vec3(texture(material.diffuse,TexCoords));
	
	
	//漫反射
	vec3 norm=normalize(Normal);
	vec3 lightDir=normalize(light.position-FragPos);
	float diff=max(dot(norm,lightDir),0.0);
	//vec3 duffuse=light.diffuse*(diff*material.diffuse);
	//vec3 duffuse=light.diffuse*diff*vec3(texture(material.diffuse,TexCoords));
	vec3 duffuse=light.diffuse*diff*vec3(texture(material.diffuse,TexCoords));
	
	//高光反射
	vec3 viewDir=normalize(viewPos-FragPos);
	vec3 reflectDir=reflect(-lightDir,norm);
	float spec=pow(max(dot(viewDir,reflectDir),0.0),material.shininess);
	//vec3 specular=light.specular*(spec*material.specular);
	vec3 specular=light.specular*spec*vec3(texture(material.specular,TexCoords));
	
	
	vec3 res=ambient+duffuse+specular;
	FragColor=vec4(res,1.0);
}