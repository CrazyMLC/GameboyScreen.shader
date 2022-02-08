uniform sampler2D tex;
uniform vec2 texSize;
varying vec2 texCoord;

uniform vec2 shadowOffset;
uniform vec3 shadowColor;
uniform vec3 shadowTint;
uniform float shadowTintStrength;
uniform float shadowThreshold;
uniform float shadowSharpness;
uniform float shadowStrength;

uniform float sampleRadius = 1;

vec3 getNeighbor(vec2 offset) {
	return texture2D(tex, texCoord + offset / texSize).rgb;
}

vec3 sampleShadow() {
	vec3 sample = vec3(0.0);
	for (float x = -sampleRadius; x <= sampleRadius+0.1; x += 1.0) {
		for (float y = -sampleRadius; y <= sampleRadius+0.1; y += 1.0) {
			sample += getNeighbor(shadowOffset + vec2(x, y));
		}
	}
	return mix(sample/max(pow((sampleRadius*2.0)+1,2.0),1.0), getNeighbor(shadowOffset), shadowSharpness);
}

void main() {
	vec4 color = texture2D(tex, texCoord);
	//float brightness = pow(length(color.rgb),2.0)*(1-highlightCutting);
	
	vec3 blockingColor = sampleShadow();
	float blockBrightness = sqrt(1-min(length(blockingColor)/shadowThreshold, 1.0));
	
	color.rgb = mix(color.rgb, shadowTint, blockBrightness*shadowTintStrength) * mix(vec3(1.0,1.0,1.0), shadowColor, blockBrightness * shadowStrength);
	gl_FragColor = color;
}
