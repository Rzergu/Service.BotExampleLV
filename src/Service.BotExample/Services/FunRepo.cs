using Service.BotExample.Interfaces;

namespace Service.BotExample.Services
{
	public class FunRepo : IFunRepo
	{

		private long _funCounter = 0;
		private object _counterLock = new object();
		public long FunCounter { get {

				lock (_counterLock)
				{
					return _funCounter++;
				}
		} }
	}
}
