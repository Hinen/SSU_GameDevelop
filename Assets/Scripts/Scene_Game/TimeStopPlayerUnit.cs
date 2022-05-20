using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeStopPlayerUnit : CoolTimeSkillPlayerUnit {
    public void Awake() {
        _playerSkillHandler = new TimeStopSkillHandler(this);
    }
}
