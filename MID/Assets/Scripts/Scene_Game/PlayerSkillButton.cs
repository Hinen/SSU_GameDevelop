using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerSkillButton : MonoBehaviour, IPointerDownHandler {
	public void OnPointerDown(PointerEventData pointerEventData) {
		Scene_Game.Get().PlayerUnit.UseSkill();
	}
}
