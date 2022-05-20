using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TimeStopSkillHandler : PlayerSkillHandler {
    public TimeStopSkillHandler(PlayerUnit playerUnit) : base(playerUnit) {
		
    }

    public override void UseSkill() {
        SoundManager.Get().PlayFX(Constants.Sound.FX.TIME_STOP);

        var timeStopImage = Scene_Game.Get().TimeStopScreenImage;
        timeStopImage.rectTransform.DOSizeDelta(new Vector2(Constants.RESOLUTION_X * 2.5f, Constants.RESOLUTION_X * 2.5f), 1.5f);
        
        Timer.Get().RegistTimer(5f, () => {
            timeStopImage.rectTransform.DOSizeDelta(Vector2.zero, 0.5f);
        });
    }
}
