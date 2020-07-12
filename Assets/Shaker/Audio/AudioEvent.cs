using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Audio;

public abstract class AudioEvent : ScriptableObject
{
	public abstract float Play(AudioSource source);

	public AudioSource Play2D(AudioMixerGroup audioMixerGroup = null)
	{
		AudioSource source = CreateAudioSource(audioMixerGroup, 0f);
		Destroy(source.gameObject, this.Play(source));
		return source;
	}

	public AudioSource Play3D(Vector3 position, AudioMixerGroup audioMixerGroup = null, float spatialBlend = 1f)
	{
		AudioSource source = CreateAudioSource(audioMixerGroup, spatialBlend);
		source.transform.position = position;
		Destroy(source.gameObject, this.Play(source));
		return source;
	}

	private AudioSource CreateAudioSource(AudioMixerGroup audioMixerGroup, float spatialBlend)
	{
		AudioSource source = new GameObject().AddComponent<AudioSource>();
		source.gameObject.name = "AudioEvent";
		source.outputAudioMixerGroup = audioMixerGroup;
		source.spatialBlend = Mathf.Clamp01(spatialBlend);
		return source;
	}

}