using System;

namespace Kogane
{
	/// <summary>
	/// コマンドのリストの UI のデータを管理するクラス
	/// </summary>
	public sealed class CommandDataWithTabType<T>
	{
		//==============================================================================
		// プロパティ(readonly)
		//==============================================================================
		public T           TabType { get; }
		public CommandData Data    { get; }

		//==============================================================================
		// 関数
		//==============================================================================
		/// <summary>
		/// 入力欄と複数の実行ボタンを指定するコンストラクタ
		/// </summary>
		public CommandDataWithTabType
		(
			T                   tabType,
			Func<string>        getText,
			InputActionData     inputActionData,
			params ActionData[] actionDataList
		)
		{
			TabType = tabType;
			Data    = new CommandData( getText, inputActionData, actionDataList );
		}

		/// <summary>
		/// 複数の実行ボタンを指定するコンストラクタ
		/// </summary>
		public CommandDataWithTabType
		(
			T                   tabType,
			Func<string>        getText,
			params ActionData[] actionDataList
		)
		{
			TabType = tabType;
			Data    = new CommandData( getText, actionDataList );
		}

		/// <summary>
		/// 区切り線を指定するコンストラクタ
		/// </summary>
		public CommandDataWithTabType
		(
			T            tabType,
			Func<string> getText
		)
		{
			TabType = tabType;
			Data    = new CommandData( getText );
		}

		/// <summary>
		/// チェックボックスを指定するコンストラクタ
		/// </summary>
		public CommandDataWithTabType
		(
			T                tabType,
			Func<string>     getText,
			ToggleActionData toggleActionData
		)
		{
			TabType = tabType;
			Data    = new CommandData( getText, toggleActionData );
		}
	}
}