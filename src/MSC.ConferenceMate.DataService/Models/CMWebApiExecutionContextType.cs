using CodeGenHero.DataService;
using System;
using static MSC.ConferenceMate.DataService.Constants.Enums;

namespace MSC.ConferenceMate.DataService.Models
{
	public class CMWebApiExecutionContextType : WebApiExecutionContextType
	{
		public override int Current
		{
			get
			{
				return _current;
			}
			set
			{
				switch (value)
				{
					case (int)ExecutionContextTypes.Base:
						_current = value;
						break;

					default:
						throw new ArgumentOutOfRangeException($"The value provided, {value}, for the current WebApiExecutionContextType is invalid.");
				}
			}
		}
	}
}