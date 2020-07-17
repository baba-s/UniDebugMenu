using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Kogane.Internal
{
	/// <summary>
	/// 入力欄付きのリストの要素の UI を管理するクラス
	/// </summary>
	[AddComponentMenu( "" )]
	[DisallowMultipleComponent]
	internal sealed class CommandListElemUI : MonoBehaviour, IScrollItemUI<CommandData>
	{
		//==============================================================================
		// 変数(SerializeField)
		//==============================================================================
		[SerializeField] private Text               m_leftTextUI         = default;
		[SerializeField] private Text               m_rightTextUI        = default;
		[SerializeField] private GameObject         m_borderUI           = default;
		[SerializeField] private InputFieldButtonUI m_inputFieldButtonUI = default;
		[SerializeField] private ToggleButtonUI     m_toggleButtonUI     = default;
		[SerializeField] private TextButtonUI[]     m_buttonUIList       = default;

		//==============================================================================
		// 変数
		//==============================================================================
		private CommandData m_data;

		//==============================================================================
		// デリゲート
		//==============================================================================
		public Action<int> mOnComplete { private get; set; }

		//==============================================================================
		// 関数
		//==============================================================================
		/// <summary>
		/// 表示を設定します
		/// </summary>
		public void SetDisp( CommandData data )
		{
			var isChange         = m_data != data;
			var text             = data.GetText();
			var inputActionData  = data.InputActionData;
			var toggleActionData = data.ToggleActionData;
			var actionDataList   = data.ActionDataList;
			var isBorder         = data.IsBorder;
			var isToggle         = toggleActionData != null;
			var isInput          = inputActionData != null;
			var isLeft           = data.IsLeft;

			m_data = data;

			m_leftTextUI.gameObject.SetActive( isLeft );
			m_rightTextUI.gameObject.SetActive( !isLeft );

			m_leftTextUI.text  = text;
			m_rightTextUI.text = text;

			m_borderUI.SetActive( isBorder );

			m_inputFieldButtonUI.SetActive( isInput );
			m_inputFieldButtonUI.SetDisp( isChange, inputActionData );
			m_inputFieldButtonUI.mOnComplete = () => mOnComplete?.Invoke( 0 );

			m_toggleButtonUI.SetActive( isToggle );
			m_toggleButtonUI.SetDisp( toggleActionData );
			m_toggleButtonUI.mOnComplete = () => mOnComplete?.Invoke( 1 );

			for ( int i = 0; i < m_buttonUIList.Length; i++ )
			{
				var index      = i;
				var buttonUI   = m_buttonUIList[ i ];
				var actionData = actionDataList.ElementAtOrDefault( i );
				var isActive   = actionData != null;

				buttonUI.SetActive( isActive );

				if ( !isActive ) continue;

				buttonUI.mOnComplete = _ => mOnComplete?.Invoke( index + 2 );
				buttonUI.SetDisp( actionData );
			}
		}
	}
}