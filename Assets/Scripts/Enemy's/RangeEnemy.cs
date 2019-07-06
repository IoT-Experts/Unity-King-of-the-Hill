using UnityEngine;
using System.Collections;
using DG.Tweening;
public class RangeEnemy : Enemy {
	public EnemyWeaponPoolManager weapon_system;
	public Transform shoot_pos;
	public Vector3 target_to_shoot;
	// Use this for initialization

	public void LaunchWeapon ()
	{
		weapon_system.LaunchWeapon(gameObject,shoot_pos,target_to_shoot,dmg);
	}
	public override void DoDmg ()
	{
	//	PlayAttackMusic();
		LaunchWeapon();
	}
		
}
