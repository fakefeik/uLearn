﻿using uLearn;

namespace OOP.Slides.U05_UI2
{
	[Slide("Паттерн Observable", "0EF94FEAC1B84D69B809495DC7621F82")]
	public class S050_Observable
	{
		/*
		Контроллер должен вовремя обновлять соответствующее представление.
		Это приводит к довольно рутинному, однообразному коду обновления представлений, сопровождающему все места, модифицирующие модели.

		В случаях, когда одну Модель отображают несколько Представлений или просто в случаях сложных Представлений и Моделей 
		удобнее не писать этот код вручную, а использовать шаблон Observable.

		Шаблон [Observer](http://martinfowler.com/eaaDev/MediatedSynchronization.html) позволяет избавится от этого рутинного кода.
		Согласно этому шаблону, Модель предоставляет любым желающим способ подписаться на уведомления о своем изменении.
		Подписываться на модель может Контроллер, а в простых случаях даже само Представление.
		В такой ситуации кто бы не менял модель, все Представления автоматически будут обновлены.

		Этот шаблон особенно удобен, когда одну Модель отображают несколько Представлений — вы меняете модель в одном месте, 
		а все Представления обновляются автоматически благодаря оповещениям.

		![Observable](observable.png)

		Возможно, вам покажется, что это идеальный, правильный способ, который стоит применять везде. 
		Это не совсем так. Как у любого подхода, у него есть свои недостатки.

		Во-первых, сложная система, построенная на этом шаблоне, из-за неявности оповещения может вызывать сложности при отладке.

		Во-вторых, в простых случаях рутинный код по ручному контролю за изменением модели просто превратится в рутинный код подписывания на оповещения, 
		не дав существенного выигрыша в красоте, компактности и понятности кода.
		*/
	}
}