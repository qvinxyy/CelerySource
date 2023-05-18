using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace CeleryApp
{
	internal class Animation
	{
		[DebuggerStepThrough]
		public void MoveAnimation(DependencyObject Object, Thickness Get, Thickness Set)
		{
			Animation.<MoveAnimation>d__1 <MoveAnimation>d__ = new Animation.<MoveAnimation>d__1();
			<MoveAnimation>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<MoveAnimation>d__.<>4__this = this;
			<MoveAnimation>d__.Object = Object;
			<MoveAnimation>d__.Get = Get;
			<MoveAnimation>d__.Set = Set;
			<MoveAnimation>d__.<>1__state = -1;
			<MoveAnimation>d__.<>t__builder.Start<Animation.<MoveAnimation>d__1>(ref <MoveAnimation>d__);
		}

		[DebuggerStepThrough]
		public void TimedMoveAnimation(DependencyObject Object, Thickness Get, Thickness Set, double Time)
		{
			Animation.<TimedMoveAnimation>d__2 <TimedMoveAnimation>d__ = new Animation.<TimedMoveAnimation>d__2();
			<TimedMoveAnimation>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<TimedMoveAnimation>d__.<>4__this = this;
			<TimedMoveAnimation>d__.Object = Object;
			<TimedMoveAnimation>d__.Get = Get;
			<TimedMoveAnimation>d__.Set = Set;
			<TimedMoveAnimation>d__.Time = Time;
			<TimedMoveAnimation>d__.<>1__state = -1;
			<TimedMoveAnimation>d__.<>t__builder.Start<Animation.<TimedMoveAnimation>d__2>(ref <TimedMoveAnimation>d__);
		}

		[DebuggerStepThrough]
		public void WidthAnimation(DependencyObject Object, double Set)
		{
			Animation.<WidthAnimation>d__3 <WidthAnimation>d__ = new Animation.<WidthAnimation>d__3();
			<WidthAnimation>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<WidthAnimation>d__.<>4__this = this;
			<WidthAnimation>d__.Object = Object;
			<WidthAnimation>d__.Set = Set;
			<WidthAnimation>d__.<>1__state = -1;
			<WidthAnimation>d__.<>t__builder.Start<Animation.<WidthAnimation>d__3>(ref <WidthAnimation>d__);
		}

		[DebuggerStepThrough]
		public void HeightAnimation(DependencyObject Object, double Set)
		{
			Animation.<HeightAnimation>d__4 <HeightAnimation>d__ = new Animation.<HeightAnimation>d__4();
			<HeightAnimation>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<HeightAnimation>d__.<>4__this = this;
			<HeightAnimation>d__.Object = Object;
			<HeightAnimation>d__.Set = Set;
			<HeightAnimation>d__.<>1__state = -1;
			<HeightAnimation>d__.<>t__builder.Start<Animation.<HeightAnimation>d__4>(ref <HeightAnimation>d__);
		}

		[DebuggerStepThrough]
		public void OpacityAnimation(DependencyObject Object, double Get, double Set, double Duration)
		{
			Animation.<OpacityAnimation>d__5 <OpacityAnimation>d__ = new Animation.<OpacityAnimation>d__5();
			<OpacityAnimation>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OpacityAnimation>d__.<>4__this = this;
			<OpacityAnimation>d__.Object = Object;
			<OpacityAnimation>d__.Get = Get;
			<OpacityAnimation>d__.Set = Set;
			<OpacityAnimation>d__.Duration = Duration;
			<OpacityAnimation>d__.<>1__state = -1;
			<OpacityAnimation>d__.<>t__builder.Start<Animation.<OpacityAnimation>d__5>(ref <OpacityAnimation>d__);
		}

		[DebuggerStepThrough]
		public void WidthAnimation(DependencyObject Object, double Get, double Set, double Duration)
		{
			Animation.<WidthAnimation>d__6 <WidthAnimation>d__ = new Animation.<WidthAnimation>d__6();
			<WidthAnimation>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<WidthAnimation>d__.<>4__this = this;
			<WidthAnimation>d__.Object = Object;
			<WidthAnimation>d__.Get = Get;
			<WidthAnimation>d__.Set = Set;
			<WidthAnimation>d__.Duration = Duration;
			<WidthAnimation>d__.<>1__state = -1;
			<WidthAnimation>d__.<>t__builder.Start<Animation.<WidthAnimation>d__6>(ref <WidthAnimation>d__);
		}

		[DebuggerStepThrough]
		public void HeightAnimation(DependencyObject Object, double Get, double Set, double Duration)
		{
			Animation.<HeightAnimation>d__7 <HeightAnimation>d__ = new Animation.<HeightAnimation>d__7();
			<HeightAnimation>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<HeightAnimation>d__.<>4__this = this;
			<HeightAnimation>d__.Object = Object;
			<HeightAnimation>d__.Get = Get;
			<HeightAnimation>d__.Set = Set;
			<HeightAnimation>d__.Duration = Duration;
			<HeightAnimation>d__.<>1__state = -1;
			<HeightAnimation>d__.<>t__builder.Start<Animation.<HeightAnimation>d__7>(ref <HeightAnimation>d__);
		}

		public void Rotate(RotateTransform Object, double Get, double Set, double Duration)
		{
			DoubleAnimation animation = new DoubleAnimation
			{
				From = new double?(Get),
				To = new double?(Set),
				Duration = TimeSpan.FromMilliseconds(Duration),
				EasingFunction = this.Easing
			};
			Object.BeginAnimation(RotateTransform.AngleProperty, animation, HandoffBehavior.SnapshotAndReplace);
		}

		private IEasingFunction Easing { get; set; } = new QuadraticEase
		{
			EasingMode = EasingMode.EaseInOut
		};

		private Storyboard Storyboard = new Storyboard();
	}
}
