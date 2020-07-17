using System;

namespace Kogane
{
	/// <summary>
	/// 入力欄付きのリストの要素の UI のデータを管理するクラス
	/// </summary>
	public sealed class CommandData
	{
		//==============================================================================
		// プロパティ(readonly)
		//==============================================================================
		public Func<string>     GetText          { get; }
		public InputActionData  InputActionData  { get; }
		public ToggleActionData ToggleActionData { get; }
		public ActionData[]     ActionDataList   { get; }
		public bool             IsBorder         { get; }

		//==============================================================================
		// プロパティ
		//==============================================================================
		public bool IsLeft { get; set; }

		//==============================================================================
		// 関数
		//==============================================================================
		/// <summary>
		/// 入力欄と複数の実行ボタンを指定するコンストラクタ
		/// </summary>
		public CommandData
		(
			Func<string>        getText,
			InputActionData     inputActionData,
			params ActionData[] actionDataList
		)
		{
			GetText         = getText;
			InputActionData = inputActionData;
			ActionDataList  = actionDataList;
		}

		/// <summary>
		/// 複数の実行ボタンを指定するコンストラクタ
		/// </summary>
		public CommandData
		(
			Func<string>        getText,
			params ActionData[] actionDataList
		) : this( getText, null, actionDataList )
		{
		}

		/// <summary>
		/// 区切り線を指定するコンストラクタ
		/// </summary>
		public CommandData
		(
			Func<string> getText
		) : this( getText, null, new ActionData[0] )
		{
			IsBorder = true;
		}

		/// <summary>
		/// チェックボックスを指定するコンストラクタ
		/// </summary>
		public CommandData
		(
			Func<string>     getText,
			ToggleActionData toggleActionData
		)
		{
			GetText          = getText;
			ToggleActionData = toggleActionData;
			ActionDataList   = new ActionData[0];
		}
	}
}