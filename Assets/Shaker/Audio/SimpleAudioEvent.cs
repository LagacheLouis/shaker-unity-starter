using UnityEngine;
using Shaker;

[CreateAssetMenu(menuName = "Audio Events/Simple")]
public class SimpleAudioEvent : AudioEvent
{
	public AudioClip[] clips;

	public RangedFloat volume;

	[MinMaxRange(0, 2)]
	public RangedFloat pitch;

	public override float Play(AudioSource source)
	{
		if (clips.Length == 0) return 0;

		source.clip = clips.RandomItem();
		source.volume = volume.Random();
		source.pitch = pitch.Random();
		source.Play();
		return source.clip.length;
	}
} 