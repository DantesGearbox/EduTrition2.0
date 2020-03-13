using UnityEngine;

public class BounceUpAndDown : MonoBehaviour
{
	public LeanTweenType easeType;
	public float distance = 5;
	public float duration = 2;

	private LTDescr tweenObject = null;

	private void Start()
	{
		tweenObject = LeanTween.move(gameObject, transform.position + (Vector3.up * distance), duration);
		tweenObject.setLoopPingPong();
		tweenObject.setEase(easeType);
	}
}
