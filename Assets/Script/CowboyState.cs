using UnityEngine;
using System.Collections;

public class CowboyState : MonoBehaviour {

	/*stateNum为状态代码
	 * 1=放松             0%-30%
	 * 2=普通战斗         31%-65%
	 * 3=不耐烦战斗       66%-90%
	 * 4=生气脸红冒星战斗  91%-99% 这段动画除非迅速被切走,否则不建议循环播放.
	 * 5=开枪             100%
	 * 11=烟头掉下来      11%-50%
	 */
	public int stateNum=1;
	public Transform cowboy;//
	public string cowboyAniNum="01";//此处必须填写01到06,不能省略数字0.
	//public float animationSpeed=0.5f;
	void Update () {
		Animator ani=cowboy.GetComponent<Animator>();
		if (stateNum == 1) {
			//本状态不支持Screen06,因为6号场景没有relax状态.强制赋值不影响游戏,但控制台会报错.
			ani.Play("relax"+cowboyAniNum);
		}
		if (stateNum == 2) {
			ani.Play("fightNormal"+cowboyAniNum);
		}
		if (stateNum == 3) {
			ani.Play("fightImpatient"+cowboyAniNum);
		}
		if (stateNum == 4) {
			ani.Play("fightAngry"+cowboyAniNum);
		}
		if (stateNum == 5) {
			ani.Play("Fire"+cowboyAniNum);
		}
		if (stateNum == 11) {
			//本状态不支持Screen02到Screen06
			ani.Play("drop");
		}
	}
}
