// <auto-generated> - Template:APIStatusController, Version:1.1, Id:a5d78309-5a18-4a09-9225-03e602b52187
using System;
using System.Threading.Tasks;
using System.Web.Http;
using CodeGenHero.WebApi;
using CodeGenHero.Logging;
using MSC.ConferenceMate.Repository.Interface;

namespace MSC.ConferenceMate.API.Controllers.CM
{
	public partial class CMAPIStatusController : CMBaseApiController
	{
		public CMAPIStatusController() : base()
		{
		}

		public CMAPIStatusController(ILoggingService log, ICMRepository repository)
			: base(log, repository)
		{
		}

		[HttpGet]
		[VersionedRoute(template: "APIStatus", allowedVersion: 1, Name = "CMAPIStatus")]
		public async Task<IHttpActionResult> Get()
		{
			try
			{
				var version = this.GetType().Assembly.GetName().Version;
				return Ok(version);
			}
			catch (Exception ex)
			{
				Error(message: ex.Message, logMessageType: LogMessageType.Instance.Exception_WebApi, ex: ex);

				if (System.Diagnostics.Debugger.IsAttached)
					System.Diagnostics.Debugger.Break();

				return InternalServerError();
			}
		}
	}
}
