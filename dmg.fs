uniform sampler2D tex;
uniform vec2 texSize;
varying vec2 texCoord;


uniform float gridStrength;
uniform float gridSharpness;
uniform float gridNoise;
uniform float gridBoxiness;
uniform vec2 gridBias;
uniform vec3 gridColor;

float rand(vec2 co){
    return fract(sin(dot(co, vec2(12.9898, 78.233))) * 43758.5453);
}

vec4 getNeighbor(int sx, int sy) {
	return texture2D(tex, texCoord - vec2(min(float(sy),1.0) / texSize.x, min(float(sx),1.0) / texSize.y));
}

vec3 avgColor(vec3 c1, vec3 c2, float bias) {
	return (c1*bias + c2) / (bias+1.0);
}

void main() {
	vec4 color = texture2D(tex, texCoord);
	if (gridStrength > 0) {
		int sx = int(mod(texCoord.s * texSize.x * 4.0, 4.0));
		int sy = int(mod(texCoord.t * texSize.y * 4.0, 4.0));
		
		if (sx == 0 || sy == 0) {
			if (sx == sy) {
				color.rgb = (color.rgb + getNeighbor(1,0).rgb + getNeighbor(1,1).rgb + getNeighbor(0,1).rgb)/4;
				vec3 maxColor = max(max(max(color.rgb, getNeighbor(1,0).rgb), getNeighbor(1,1).rgb), getNeighbor(0,1).rgb);
				color.rgb = mix(color.rgb, maxColor, gridSharpness);
			} else {
				vec3 minColor = getNeighbor(sx,sy).rgb;
				vec3 maxColor = color.rgb;
				if (max(minColor,color.rgb) == minColor) {
					maxColor = minColor;
					minColor = color.rgb;
				}
				color.rgb = mix(minColor, maxColor, 0.5+gridSharpness/2.0);
			}
			
			float dist = abs(2.0-max(sx,sy));
			dist = gridStrength*gridBoxiness+pow(dist,gridSharpness*2.0+0.2)/(2.1-(gridStrength-0.75)*8.0+2.0*length(color.rgb)) / 2.0;
			if (gridNoise > 0) {
				dist += gridNoise * 0.8 * (0.5 - rand(texCoord));
			}
			if (gridBias.y != 0) {
				dist *= mix(1.0, -1.0 * sign(gridBias.y) * texCoord.t + (sign(gridBias.y)+1)/2.0, abs(gridBias.y));
			}
			if (gridBias.x != 0) {
				dist *= mix(1.0, -1.0 * sign(gridBias.x) * texCoord.s + (sign(gridBias.x)+1)/2.0, abs(gridBias.x));
			}
			
			color.rgb = avgColor(gridColor, color.rgb, dist/2.0);
		}
	}
	gl_FragColor = color;
}
