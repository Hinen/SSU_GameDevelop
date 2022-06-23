using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Popup_HowToPlay : MonoBehaviour {
	[SerializeField]
	private GameObject[] _depthArr;
	
	[SerializeField]
	private Text _closeButtonText;

	private int _nowDepth;

	public void Init() {
		gameObject.transform.localScale = new Vector3(0f, 0f, 1f);
		gameObject.transform.DOScale(new Vector3(1f, 1f, 1f), 0.3f);
		
		_nowDepth = 0;
		
		Refresh();
	}

	private void Refresh() {
		for (int i = 0; i < _depthArr.Length; i++)
			_depthArr[i].SetActive(i == _nowDepth);
		
		_closeButtonText.text = _nowDepth == _depthArr.Length - 1 ? "CLOSE" : "NEXT";
	}
	
	public void OnClickNextButton() {
		SoundManager.Get().PlayFX(Constants.Sound.FX.TOUCH);
		
		_nowDepth++;
		
		if (_nowDepth >= _depthArr.Length)
			gameObject.SetActive(false);
		else
			Refresh();
	}
}
