using System;

namespace Kogane
{
	/// <summary>
	/// ボタンの表示名とクリックイベントを管理するクラス
	/// </summary>
	public sealed class ActionData
	{
		//==============================================================================
		// プロパティ
		//==============================================================================
		public string         Text    { get; } = string.Empty;
		public Action<Action> OnClick { get; } = null;

		//==============================================================================
		// 関数
		//==============================================================================
		public ActionData()
		{
		}

		public ActionData
		(
			string         text,
			Action<Action> onClick
		)
		{
			Text    = text;
			OnClick = onClick;
		}

		public ActionData
		(
			string text,
			Action onClick
		)
		{
			Text = text;
			OnClick = onEnded =>
			{
				onClick?.Invoke();
				onEnded?.Invoke();
			};
		}

		public ActionData
		(
			string text
		)
		{
			Text    = text;
			OnClick = null;
		}
	}
}