using System;
using UnityEngine;

/* Potential ways to improve tool:
 * - Animation Curve as ease option
 * - Specific duration and offset for disable animations (though already possible to make)
 * - Non-absolute movement, scaling and fading
 */

public enum UIAnimationTypes
{
	Move,
	Scale,
	Fade
}

public class UITweener : MonoBehaviour
{
	public UIAnimationTypes animationType;
	public LeanTweenType easeType;

	public bool useScaleOffset;
	public bool useFadeOffset;

	public Vector3 start;
	public Vector3 end;

	public float duration;
	public float delay;

	public bool loop;
	public bool pingpong;

	public bool animateOnEnable;
	public bool animateOnDisable;

	private LTDescr tweenObject = null;


	private void OnEnable()
	{
		Enable();
	}


	public void Enable()
	{
		gameObject.SetActive(true);
		if (animateOnEnable)
		{
			Animate();
		}
	}


	public void Disable()
	{
		SwapDirection();
		Animate();
		tweenObject.setOnComplete(SwapDirectionAndDisable);
	}


	public void Disable(Action onCompleteAction)
	{
		SwapDirection();
		Animate();
		tweenObject.setOnComplete(onCompleteAction).setOnComplete(SwapDirectionAndDisable);
	}

	private void Animate()
	{
		switch (animationType)
		{
			case UIAnimationTypes.Fade:
				tweenObject = Fade();
				break;

			case UIAnimationTypes.Move:
				tweenObject = Move();
				break;

			case UIAnimationTypes.Scale:
				tweenObject = Scale();
				break;
		}

		tweenObject.setDelay(delay);
		tweenObject.setEase(easeType);

		if (loop)
		{
			tweenObject.setLoopClamp();
		}
		if(pingpong)
		{
			tweenObject.setLoopPingPong();
		}
	}


	private LTDescr Fade()
	{
		CanvasGroup canvasGroup = gameObject.GetComponent<CanvasGroup>();

		if (canvasGroup == null)
		{
			canvasGroup = gameObject.AddComponent<CanvasGroup>();
		}

		if (useFadeOffset)
		{
			canvasGroup.alpha = start.x;
		}

		return LeanTween.alphaCanvas(canvasGroup, end.x, duration);
	}


	private LTDescr Move()
	{
		RectTransform rectTransform = gameObject.GetComponent<RectTransform>();

		return LeanTween.move(rectTransform, end, duration);
	}


	private LTDescr Scale()
	{
		if (useScaleOffset)
		{
			gameObject.GetComponent<RectTransform>().localScale = start;
		}

		return LeanTween.scale(gameObject, end, duration);
	}


	private void SwapDirection()
	{
		Vector3 temp = start;
		start = end;
		end = temp;
	}


	private void SwapDirectionAndDisable()
	{
		SwapDirection();
		gameObject.SetActive(false);
	}
}
