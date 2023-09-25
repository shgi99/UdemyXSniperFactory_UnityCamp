using UnityEngine;
using System.Collections;




/*
 *	汎用の時間で消えるオブジェクト用スクリプト
 *	Maruchu
 */
public		class		Timer				: MonoBehaviour {




public							float		fTimeLimit				= 1f;						//各プレハブの生存時間

private							float		m_fTimeLeft				= 0f;						//残り生存時間



/*
 *	起動時に呼び出される関数
 */
private		void	Awake() {
	//制限時間を指定
	m_fTimeLeft		= fTimeLimit;
}


/*
 *	毎フレーム呼び出される関数
 */
private		void	Update() {

	//指定された時間 待つ
	m_fTimeLeft		-= Time.deltaTime;
	if( m_fTimeLeft < 0f) {
		//時間切れ

		//この GameObject をヒエラルキーから削除
		Destroy( gameObject);
	}
}




}
