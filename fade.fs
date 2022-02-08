uniform sampler2D tex;
varying vec2 texCoord;

uniform float fadeSpeed;
uniform float brightnessScaling;

void main() {
	vec4 color = texture2D(tex, texCoord);
	float brightness = pow(length(color.rgb),2.0);
	color.a = min(1.0, (0.03 + fadeSpeed)*0.8/(1.0-brightness*brightnessScaling));
	gl_FragColor = color;
}
