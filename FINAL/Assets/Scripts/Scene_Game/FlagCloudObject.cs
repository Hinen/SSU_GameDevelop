using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagCloudObject : CloudObject {
    protected override void InitScoreFlag() {
        SetScoreFlag(CloudScoreFlag.CAN_GET_SCORE_5);   
    }
}
