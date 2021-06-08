#version 330 core
out vec4 FragColor;

in vec2 TexCoord;

uniform sampler2D screenTexture;

const float offset = 1.0 / 300.0; 
void main()
{
   //不处理
     //FragColor=texture(screenTexture,TexCoord);
   //反相
   //FragColor = vec4(vec3(1.0 - texture(screenTexture, TexCoord)), 1.0);
   /*
     //灰度
     FragColor = texture(screenTexture, TexCoord);
     //float average = (FragColor.r + FragColor.g + FragColor.b) / 3.0;
	 //加权
	 float average = 0.2126 * FragColor.r + 0.7152 * FragColor.g + 0.0722 * FragColor.b;
     FragColor = vec4(average, average, average, 1.0);*/
   //核
   vec2 offsets[9] = vec2[](
        vec2(-offset,  offset), // 左上
        vec2( 0.0f,    offset), // 正上
        vec2( offset,  offset), // 右上
        vec2(-offset,  0.0f),   // 左
        vec2( 0.0f,    0.0f),   // 中
        vec2( offset,  0.0f),   // 右
        vec2(-offset, -offset), // 左下
        vec2( 0.0f,   -offset), // 正下
        vec2( offset, -offset)  // 右下
    );

    float kernel[9] = float[](
        -1, -1, -1,
        -1,  9, -1,
        -1, -1, -1
    );
	//模糊
	/*float kernel[9] = float[](
    1.0 / 16, 2.0 / 16, 1.0 / 16,
    2.0 / 16, 4.0 / 16, 2.0 / 16,
    1.0 / 16, 2.0 / 16, 1.0 / 16  
    );*/
	//边缘检测
	/*float kernel[9] = float[](
        1,  1, 1,
        1, -8, 1,
        1,  1, 1
    );*/

    vec3 sampleTex[9];
    for(int i = 0; i < 9; i++)
    {
        sampleTex[i] = vec3(texture(screenTexture, TexCoord.st + offsets[i]));
    }
    vec3 col = vec3(0.0);
    for(int i = 0; i < 9; i++)
        col += sampleTex[i] * kernel[i];

    FragColor = vec4(col, 1.0);
	
}

