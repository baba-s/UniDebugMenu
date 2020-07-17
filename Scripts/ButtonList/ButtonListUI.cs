using System;
using UnityEngine;
using UnityEngine.UI;

namespace Kogane.Internal
{
	/// <summary>
	/// デバッグメニュー画面を管理するクラス
	/// </summary>
	[AddComponentMenu( "" )]
	[DisallowMultipleComponent]
	internal sealed class ButtonListUI : DebugMenuUIBase
	{
		//==============================================================================
		// クラス
		//==============================================================================
		[Serializable]
		public sealed class LoopListViewUI : LoopListViewUI<ActionData, TextButtonUI>
		{
		}

		//==============================================================================
		// 変数(SerializeField)
		//==============================================================================
		[SerializeField] private Button             m_updateButtonUI     = default;
		[SerializeField] private SortButtonUI       m_sortButtonUI       = default;
		[SerializeField] private SearchFieldUI      m_searchFieldUI      = default;
		[SerializeField] private TabButtonUIList    m_tabButtonUIList    = default;
		[SerializeField] private OptionButtonUIList m_optionButtonUIList = default;
		[SerializeField] private LoopListViewUI     m_view               = default;
		[SerializeField] private GameObject         m_emptyTextUI        = default;

		//==============================================================================
		// 変数(readonly)
		//==============================================================================
		private readonly Selectable<int> m_selectedTabIndex = new Selectable<int>(); // 選択中のタブのインデックス
		private readonly SelectableBool  m_isSort           = new SelectableBool();  // 並び替えする場合 true

		//==============================================================================
		// 変数
		//==============================================================================
		private IListCreator<ActionData> m_creator;
		private bool                     m_isInit;

		//==============================================================================
		// プロパティ
		//==============================================================================
		protected override object Creator => m_creator;

		//==============================================================================
		// 関数
		//==============================================================================
		/// <summary>
		/// 初期化される時に呼び出されます
		/// </summary>
		protected override void DoAwake()
		{
			m_updateButtonUI.onClick.SetListener( UpdateDisp );

			m_sortButtonUI.mOnClick    = m_isSort.Not;
			m_tabButtonUIList.mOnClick = m_selectedTabIndex.SetValueIfNotEqual;

			m_searchFieldUI.mOnClick    = UpdateDisp;
			m_selectedTabIndex.mChanged = UpdateDisp;
			m_isSort.mChanged           = UpdateDisp;
		}

		/// <summary>
		/// 表示を設定します
		/// </summary>
		protected override void DoSetDisp( object creator )
		{
			var tabIndex  = m_selectedTabIndex.Value;
			var isReverse = m_isSort.Value;

			var data = new ListCreateData
			(
				debugMenuScene: DebugMenuScene,
				gameObject: gameObject,
				target: this,
				searchFieldUI: m_searchFieldUI,
				tabIndex: tabIndex,
				isReverse: isReverse
			);

			m_creator = creator as IListCreator<ActionData>;
			m_creator.Create( data );

			m_sortButtonUI.SetDisp( isReverse );
			m_tabButtonUIList.SetDisp( tabIndex, m_creator.TabNameList );
			m_optionButtonUIList.SetDisp( m_creator.OptionActionList );
			m_view.SetDisp( m_creator );
			m_emptyTextUI.SetActive( m_creator.IsEmpty );

			m_optionButtonUIList.mOnComplete = optionData => OpenToastUI( $"{optionData.Text} 完了" );

			m_view.mOnComplete = ( elemData, elemIndex ) => OpenToastUI( $"{elemData.Text} 完了" );
		}

		/// <summary>
		/// トーストを表示します
		/// </summary>
		private void OpenToastUI( string message )
		{
			if ( m_creator.IsNotShowToast ) return;

			DebugToastUI.Open( message );
			DebugMenuScene.OnChange();
		}

		/// <summary>
		/// 表示を更新します
		/// </summary>
		protected override void DoRefresh()
		{
			m_view.Refresh();
		}
	}
}