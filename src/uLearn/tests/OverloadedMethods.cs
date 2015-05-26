﻿namespace uLearn.tests
{
	class OverloadedMethods : IRunnable
	{
		public string Method()
		{
			return "a";
		}

		public string Method(int a)
		{
			return a.ToString("0");
		}

		private string Method(string a)
		{
			return a;
		}

		public void Main()
		{
			return;
		}
	}
}
