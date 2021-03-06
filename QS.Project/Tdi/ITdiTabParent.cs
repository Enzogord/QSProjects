﻿using System;

namespace QS.Tdi
{
	public interface ITdiTabParent
	{
        /// <summary>
        /// Добавить подчинённую вкладку.
        /// </summary>
        /// <param name="masterTab">Вкладка, для которой надо открыть подчинённую.</param>
        /// <param name="slaveTab">Подчинённая вкладка.</param>
        void AddSlaveTab(ITdiTab masterTab, ITdiTab slaveTab);

        /// <summary>
        /// Добавить вкладку.
        /// </summary>
        /// <param name="tab">Вкладка, которую надо открыть.</param>
        /// <param name="afterTab">После какой вкладки добавлять. Обычно после выбранной - в этом случае аргумент "this".</param>
        /// <param name="CanSlided">Может ли вкладка открыться рядом с журналом. "True" и открывается из журнала - появляется справа, "false" - открывается в отдельной вкладке.</param>
		void AddTab(ITdiTab tab, ITdiTab afterTab, bool CanSlided = true);

		/// <summary>
		/// Выполняем проверку есть ли у вкладки подчиненные, если есть выводится сообщение пользователю с переключение на незакрытую подчинённую вкладку.
		/// </summary>
		/// <returns><c>true</c>, если подчиненных вкладки есть, если все готово для закрытия текущей <c>false</c>.</returns>
		/// <param name="tab">Вкладка для проверки.</param>
		bool CheckClosingSlaveTabs(ITdiTab tab);

		ITdiTab FindTab(string hashName, string masterHashName = null);

		void SwitchOnTab(ITdiTab tab);

		ITdiTab OpenTab(string hashName, Func<ITdiTab> newTabFunc, ITdiTab afterTab = null);

		/// <summary>
		/// Открываем вкладку с автоматическим вызовом конструктора в кладки с переданными функции аргументами.
		/// </summary>
		ITdiTab OpenTab<TTab>(ITdiTab afterTab = null) where TTab : ITdiTab;
		ITdiTab OpenTab<TTab, TArg1>(TArg1 arg1, ITdiTab afterTab = null) where TTab : ITdiTab;
		ITdiTab OpenTab<TTab, TArg1, TArg2>(TArg1 arg1, TArg2 arg2, ITdiTab afterTab = null) where TTab : ITdiTab;
		ITdiTab OpenTab<TTab, TArg1, TArg2, TArg3>(TArg1 arg1, TArg2 arg2, TArg3 arg3, ITdiTab afterTab = null) where TTab : ITdiTab;
	}
}

