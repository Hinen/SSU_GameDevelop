using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlayerUnit : PlayerUnit {
    public void Awake() {
        _playerSkillHandler = new JumpSkillHandler(this);
    }
}
