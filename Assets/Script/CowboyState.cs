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
	int stateNum = 1;
	
	public Transform cowboy;
	public Transform died;

	public bool isScreen06 = false;//此项固定
	public bool isScreen01 = false;//此项固定
	public string cowboyAniNum="01";//此处必须填写01到06,不能省略数字0.

	float angryNum = 0f;

	//以下为可调项, 游戏逻辑相关
	public float mAngryPointIncrementPerSec = 10f;
	public float mAngryPointDiscrementPerSec = 8f;
	public float mFirstTimeIncrement = 20f;
	public float mStartAngryPoint = 0;

	public float relaxMin=0;
	public float relaxMax=30;
	public float drop=38;
	public float normalMax=65;
	public float impatientMax=90;
	public float angryMax=100;

	// 非游戏逻辑
	public float diedMenuShowDelay=1.8f;
	public float animationSpeed=0.5f;



	bool isActive = false;//此项可调

	void Start() {
		angryNum = mStartAngryPoint;
	}

	void Update () {
		Animator ani=cowboy.GetComponent<Animator>();
		ani.speed = animationSpeed;

		if (isActive) {
			angryNum += mAngryPointIncrementPerSec * Time.deltaTime;
		} else {
			angryNum -= mAngryPointDiscrementPerSec * Time.deltaTime;
		}

		AngryStateMapping ();
		//print (angryNum);
		if (stateNum == 1) {
			//本状态不支持Screen06,因为6号场景没有relax状态.强制赋值不影响游戏,但控制台会报错.
			ani.Play("relax"+cowboyAniNum);
		} else if (stateNum == 2) {
			ani.Play("fightNormal"+cowboyAniNum); 
		} else if (stateNum == 3) {
			ani.Play("fightImpatient"+cowboyAniNum);
		} else if (stateNum == 4) {
			ani.Play("fightAngry"+cowboyAniNum);
		} else if (stateNum == 5) {
			ani.Play("Fire"+cowboyAniNum);
			Game.state = 2;
			Invoke("WhenDied",diedMenuShowDelay);
			
		} else if (stateNum == 11) {
			//本状态不支持Screen02到Screen06
			ani.Play("drop");
		}
	}

	void AngryStateMapping(){
		if (angryNum < relaxMin) {
			angryNum=relaxMin;
		}
		if (angryNum < relaxMax) {
			if (isScreen06) {
				stateNum = 2;
				angryNum = relaxMax;
			} else {
				stateNum = 1;
			}
		} else if (angryNum < drop) {
			if (isScreen01) {
				stateNum = 11;
			}
		} else if (angryNum < normalMax) {
			stateNum = 2;
		} else if (angryNum < impatientMax) {
			stateNum = 3;
		} else if (angryNum <angryMax) {
			stateNum = 4;
		} else if(angryNum >=angryMax){
			stateNum = 5;
		}
	}

	void WhenDied(){

		died.gameObject.SetActive(true);
		Animator die=died.GetComponent<Animator>();
		die.Play("died");
	}

	Transform GetParentScreen() {
		return transform.parent;
	}

	public void SetActive(bool active) {
		if (active != isActive) {
			isActive = active;
			if (isActive) {
				angryNum += mFirstTimeIncrement;
			}
		}
	}
}
