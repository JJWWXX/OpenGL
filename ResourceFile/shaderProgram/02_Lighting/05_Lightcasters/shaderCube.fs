#version 330 core

in vec3 Normal;
in vec3 FragPos;
in vec2 TexCoord;

uniform vec3 viewPos;

struct Material
{
   sampler2D diffuse;
   sampler2D specular;
   float shininess;
};

struct Light
{
   //vec3 direction;
   
   vec3 position;
   vec3 direction;
   float cutOff;
   float outerCutOff;
   
   vec3 ambient;
   vec3 diffuse;
   vec3 specular;
    
   
   float constant;
   float linear;
   float quadratic;
};

uniform Material material;
uniform Light light;

out vec4 FragColor;
void main()
{    	 
     //float distance=length(light.position-FragPos);
	 //float attenuation=1.0/(light.constant+light.linear*distance+light.quadratic*(distance*distance));
	 
     vec3 lightDir=normalize(light.position-FragPos);
     //环境光
     vec3 ambient=light.ambient*vec3(texture(material.diffuse,TexCoord));
	 
	 //漫反射
	 vec3 norm=normalize(Normal);
	 float diff=max(dot(norm,lightDir),0.0);
	 vec3 duffuse=light.diffuse*diff*vec3(texture(material.diffuse,TexCoord));
	 
	 //镜面高光
	 vec3 viewDir=normalize(viewPos-FragPos);
	 vec3 reflectDir=reflect(-lightDir,norm);
	 float spec=pow(max(dot(viewDir,reflectDir),0.0),material.shininess);
	 vec3 specular=light.specular*spec*vec3(texture(material.specular,TexCoord));
	 
	 //ambient*=attenuation;
	 //duffuse*=attenuation;
	 //specular*=attenuation;
	 
	 float theat=dot(lightDir,normalize(-light.direction));
	 float epsilon=light.cutOff-light.outerCutOff;
	 float intensity = clamp((theat - light.outerCutOff) / epsilon, 0.0, 1.0);  
	 duffuse  *= intensity;
     specular *= intensity;
	 vec3 res=ambient+duffuse+specular;
	 FragColor=vec4(res,1.0);
	 
}













