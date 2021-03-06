﻿using System;
using UnityEngine;
using UnityEngine.UI;

namespace Kogane.Internal
{
	/// <summary>
	/// 並べ替えボタンの UI を管理するクラス
	/// </summary>
	[AddComponentMenu( "" )]
	[DisallowMultipleComponent]
	internal sealed class SortButtonUI : MonoBehaviour
	{
		//==============================================================================
		// 変数(SerializeField)
		//==============================================================================
		[SerializeField] private Button m_buttonUI = default;
		[SerializeField] private Image  m_imageUI  = default;

		//==============================================================================
		// イベント
		//==============================================================================
		public Action mOnClick
		{
			set => m_buttonUI.onClick.SetListener( value );
		}

		//==============================================================================
		// 関数
		//==============================================================================
		/// <summary>
		/// リセットされる時に呼び出されます
		/// </summary>
		private void Reset()
		{
			m_buttonUI = GetComponent<Button>();
			m_imageUI  = GetComponent<Image>();
		}

		/// <summary>
		/// 表示を設定します
		/// </summary>
		public void SetDisp( bool isSelected )
		{
			var color = isSelected ? Color.yellow : Color.white;

			m_imageUI.color = color;
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