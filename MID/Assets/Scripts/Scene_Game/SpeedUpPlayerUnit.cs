using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpPlayerUnit : CoolTimeSkillPlayerUnit {
    public void Awake() {
        _playerSkillHandler = new SpeedUpSkillHandler(this);
    }
}
