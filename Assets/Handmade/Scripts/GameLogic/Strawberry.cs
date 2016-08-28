﻿using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Strawberry : ITrophy
{
	public AudioClip collectedSound;
	public AudioClip collectedEvilSound;
	public SpaceTrigger trigger;
	public ETrophy trophyName;

	private DCallback onCollected = () => {};

	void Start()
	{
		trigger.callback = OnGrab;
	}

	void OnGrab(Collider collider)
	{
		foreach (var hero in collider.gameObject.GetComponents<HeroControl>()) {
			var snd = Random.Range (0, 10) == 0
				? collectedEvilSound
				: collectedSound;

			AudioSource.PlayClipAtPoint(snd, transform.position);
			onCollected ();
			Destroy (transform.parent.gameObject);
		}
	}

	override public void SetOnCollected(DCallback cb)
	{
		onCollected = cb;
	}

	override public ETrophy GetName()
	{
		return trophyName;
	}
}
