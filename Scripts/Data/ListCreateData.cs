using UnityEngine;

namespace Kogane
{
	/// <summary>
	/// リストを作成する時に使用するデータ
	/// </summary>
	public sealed class ListCreateData
	{
		//==============================================================================
		// 変数(readonly)
		//==============================================================================
		private readonly ISearchFieldUI m_searchFieldUI;

		//==============================================================================
		// プロパティ
		//==============================================================================
		public UniDebugMenuScene DebugMenuScene { get; }
		public GameObject        GameObject     { get; }
		public DebugMenuUIBase   Target         { get; }
		public int               TabIndex       { get; }
		public bool              IsReverse      { get; }

		//==============================================================================
		// 関数
		//==============================================================================
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ListCreateData
		(
			UniDebugMenuScene debugMenuScene,
			GameObject        gameObject,
			DebugMenuUIBase   target,
			ISearchFieldUI    searchFieldUI,
			int               tabIndex,
			bool              isReverse
		)
		{
			DebugMenuScene  = debugMenuScene;
			GameObject      = gameObject;
			Target          = target;
			m_searchFieldUI = searchFieldUI;
			TabIndex        = tabIndex;
			IsReverse       = isReverse;
		}

		/// <summary>
		/// 指定された文字列が入力された文字列にマッチする場合 true を返します
		/// </summary>
		public bool IsMatch( string text ) => m_searchFieldUI.IsMatch( text );

		/// <summary>
		/// 指定されたいずれかの文字列が入力された文字列にマッチする場合 true を返します
		/// </summary>
		public bool IsMatch( params string[] texts ) => m_searchFieldUI.IsMatch( texts );
	}
}