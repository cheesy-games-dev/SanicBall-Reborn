using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sanicball.Gameplay;

public class SomeGravDirTest : EntityBehaviour
{
    public Ball ball;

    public override void OnUpdate(){
        var gravityAngleY = Vector3.Angle(ball.gravDir, Vector3.up);
        var gravityAngleX = Vector3.Angle(ball.gravDir, Vector3.right) - 90;
        var gravityAngleZ = Vector3.Angle(ball.gravDir, Vector3.forward) - 90;
        transform.rotation = Quaternion.Euler(-gravityAngleZ, -gravityAngleX, -gravityAngleY);
    }
}
