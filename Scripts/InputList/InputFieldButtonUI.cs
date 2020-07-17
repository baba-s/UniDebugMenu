using System;
using UnityEngine;
using UnityEngine.UI;

namespace Kogane.Internal
{
	/// <summary>
	/// 入力欄付きの送信ボタンを管理するクラス
	/// </summary>
	[AddComponentMenu( "" )]
	[DisallowMultipleComponent]
	internal sealed class InputFieldButtonUI : MonoBehaviour
	{
		//==============================================================================
		// 変数(SerializeField)
		//==============================================================================
		[SerializeField] private InputField m_inputFieldUI = default;
		[SerializeField] private Button     m_buttonUI     = default;

		//==============================================================================
		// デリゲート
		//==============================================================================
		public Action mOnComplete { private get; set; }

		//==============================================================================
		// 関数
		//==============================================================================
		/// <summary>
		/// 表示を設定します
		/// </summary>
		public void SetDisp( bool isChange, InputActionData data )
		{
			if ( data == null ) return;

			var validation = data.ValidateType == InputValidateType.INTEGER
					? InputField.ContentType.IntegerNumber
					: InputField.ContentType.Standard
				;

			// 他のデータを表示する場合は入力欄に入力されている文字を消去する
			// 同じデータの表示を更新する場合は入力欄に入力されている文字をそのままにする
			if ( isChange )
			{
				m_inputFieldUI.text = string.Empty;
			}

			m_inputFieldUI.contentType = validation;
			m_buttonUI.onClick.SetListener
			(
				() =>
				{
					// ボタンが押されたら指定されたアクションを実行します
					// 指定されたアクションが完了までに時間がかかる場合は
					// そのアクションが完了してから完了通知を投げます
					data.OnClick?.Invoke( m_inputFieldUI.text, () => mOnComplete?.Invoke() );
				}
			);
		}

		/// <summary>
		/// アクティブかどうかを設定します
		/// </summary>
		public void SetActive( bool isActive )
		{
			gameObject.SetActive( isActive );
		}
	}
}