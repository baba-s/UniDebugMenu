﻿using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Kogane.Internal
{
	/// <summary>
	/// ドラッグ可能なボタンを管理するコンポーネント
	/// </summary>
	[AddComponentMenu( "" )]
	internal sealed class DraggableButtonUI :
		MonoBehaviour,
		IBeginDragHandler,
		IDragHandler,
		IEndDragHandler,
		IPointerClickHandler
	{
		//==============================================================================
		// 変数(SerializeField)
		//==============================================================================
		[SerializeField][HideInInspector] private RectTransform m_rectTransform = default;

		//==============================================================================
		// 変数
		//==============================================================================
		private bool m_isDrag;

		//==============================================================================
		// イベント
		//==============================================================================
		public Action OnClick { get; set; }

		//==============================================================================
		// 関数
		//==============================================================================
		/// <summary>
		/// リセットされる時に呼び出されます
		/// </summary>
		private void Reset()
		{
			m_rectTransform = GetComponent<RectTransform>();
		}

		/// <summary>
		/// ドラッグを開始した時に呼び出されます
		/// </summary>
		public void OnBeginDrag( PointerEventData e )
		{
			m_isDrag = true;
		}

		/// <summary>
		/// ドラッグ中に呼び出されます
		/// </summary>
		public void OnDrag( PointerEventData e )
		{
			m_rectTransform.position += new Vector3( e.delta.x, e.delta.y, 0f );
		}

		/// <summary>
		/// ドラッグを終了した時に呼び出されます
		/// </summary>
		public void OnEndDrag( PointerEventData e )
		{
			m_isDrag = false;
		}

		/// <summary>
		/// クリックされた時に呼び出されます
		/// </summary>
		public void OnPointerClick( PointerEventData e )
		{
			if ( m_isDrag ) return;
			OnClick?.Invoke();
		}
	}
}