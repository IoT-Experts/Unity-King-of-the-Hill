using UnityEngine;
using System.Collections;
using DG.Tweening;
public class Fluffy_Weapon : Enemy_Weapon  {
	public float power_of_jump;
	public override void TurnOn (Vector3 target, int dmg)
	{
		transform.DOJump(target,power_of_jump,1,time).OnComplete(base.DoDmg).SetEase(Ease.Linear);
		my_dmg = dmg;
	}

}
