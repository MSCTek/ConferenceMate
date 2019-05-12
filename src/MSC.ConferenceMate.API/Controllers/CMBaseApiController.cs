// <auto-generated> - Template:APIBaseController, Version:1.1, Id:4cb75f55-706b-4b42-835b-dd823d4afc91
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Runtime.CompilerServices;
using System.Web.Http.Routing;
using MSC.ConferenceMate.Repository;
using MSC.ConferenceMate.Repository.Interface;
using CodeGenHero.DataService;
using CodeGenHero.Logging;
using CodeGenHero.Logging.Log4net;
using CodeGenHero.WebApi;

namespace MSC.ConferenceMate.API.Controllers.CM
{
	// 	[AutoInvalidateCacheOutput]
	[RoutePrefix("api/CM")]
	public abstract partial class CMBaseApiController : ApiController, ILoggingService
	{
		private ILoggingService _log;
		private ICMRepository _repository;

		public CMBaseApiController()
		{
			try
			{
				_log = new Log4NetLoggingService();

				_repository = new CMRepository(
					new MSC.ConferenceMate.Repository.Entities.CM.CMDataContext());

				RunCustomLogicAfterCtor();
			}
			catch (Exception ex)
			{
				if (_log != null)
				{
					_log.Error(message: $"Failure to initialize repository in controller constructor.",
						logMessageType: LogMessageType.Instance.Exception_WebApi, ex: ex);
				}
				else
				{
					throw;
				}
			}
		}

		public CMBaseApiController(ILoggingService log, ICMRepository repository)
		{
			_repository = repository;
			_log = log;
			RunCustomLogicAfterCtor();
		}

		public CodeGenHero.Logging.Enums.LogLevel CurrentLogLevel
		{
			get
			{
				return Log.CurrentLogLevel;
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		protected ICMRepository Repo { get { return _repository; } }

		/// <summary>
		///
		/// </summary>
		/// <remarks>
		/// This is private for a reason - using ILoggingService here in place of Log4NetLoggingService would be preferable.
		/// However, doing so causes the CallerMemberName and CallerFilePath attributes to return null.
		/// This is because those attributes are used by the compiler (not at runtime) to do their magic.
		/// Thus, by abstracting them in an interface the compiler cannot tell which methods are calling.
		/// </remarks>
		protected ILoggingService Log
		{
			get
			{
				return _log;
			}
		}

		protected PageData BuildPaginationHeader(UrlHelper urlHelper, string routeName, int page, int totalCount, int pageSize, string sort)
		{   // calculate data for metadata
			var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
			var prevLink = page > 1 ? urlHelper.Link(routeName,
				new
				{
					page = page - 1,
					pageSize = pageSize,
					sort = sort
				}) : "";
			var nextLink = page < totalPages ? urlHelper.Link(routeName,
				new
				{
					page = page + 1,
					pageSize = pageSize,
					sort = sort
				}) : "";

			return new PageData(currentPage: page, isSuccessStatusCode: true, nextPageLink: nextLink, pageSize: pageSize, previousPageLink: prevLink, totalCount: totalCount, totalPages: totalPages);
		}

		protected string GetClientIpAddress(HttpRequestMessage request = null)
		{
			request = request ?? base.Request;
			return request.GetClientIpAddress();
		}

		protected List<string> GetListByDelimiter(string fields, char delimiter = ',')
		{
			List<string> retVal = new List<string>();

			if (!string.IsNullOrEmpty(fields))
			{
				retVal = fields.ToLower().Split(delimiter).ToList();
			}

			return retVal;
		}

		protected string GetUrl(HttpRequestMessage request = null)
		{
			request = request ?? base.Request;
			return request?.RequestUri?.PathAndQuery;
		}

		protected bool OnActionExecuting(out HttpStatusCode httpStatusCode, out string message, [CallerMemberName] string methodName = null)
		{
			httpStatusCode = HttpStatusCode.OK;
			message = null;
			RunCustomLogicOnActionExecuting(ref httpStatusCode, ref message, methodName);
			return (httpStatusCode == HttpStatusCode.OK);
		}

		partial void RunCustomLogicAfterCtor();

		partial void RunCustomLogicOnActionExecuting(ref HttpStatusCode httpStatusCode, ref string message, string methodName);

		#region ILoggingService

		/*
		* This interface is implemented as a facade to ensure the CallerMemberName, CallerFilePath, and CallerLineNumber attributes work.
		*/

		public Guid Debug(string message, int logMessageType, Exception ex, string userName = null, string clientIPAddress = null,
			[CallerMemberName] string methodName = null, [CallerFilePath] string sourceFile = null, [CallerLineNumber] int lineNumber = 0,
			Decimal? executionTimeInMilliseconds = null, int? httpResponseStatusCode = null, string url = null)
		{
			url = url ?? GetUrl();
			clientIPAddress = clientIPAddress ?? GetClientIpAddress();

			return Log.Debug(message: message, logMessageType: logMessageType, ex: ex, userName: userName,
				clientIPAddress: clientIPAddress ?? GetClientIpAddress(), methodName: methodName, sourceFile: sourceFile,
				lineNumber: lineNumber, executionTimeInMilliseconds: executionTimeInMilliseconds, httpResponseStatusCode: httpResponseStatusCode, url: url ?? GetUrl());
		}

		public Guid Error(string message, int logMessageType, Exception ex, string userName = null, string clientIPAddress = null,
			[CallerMemberName] string methodName = null, [CallerFilePath] string sourceFile = null, [CallerLineNumber] int lineNumber = 0,
			Decimal? executionTimeInMilliseconds = null, int? httpResponseStatusCode = null, string url = null)
		{
			url = url ?? GetUrl();
			clientIPAddress = clientIPAddress ?? GetClientIpAddress();

			return Log.Error(message: message, logMessageType: logMessageType, ex: ex, userName: userName,
				clientIPAddress: clientIPAddress ?? GetClientIpAddress(), methodName: methodName, sourceFile: sourceFile,
				lineNumber: lineNumber, executionTimeInMilliseconds: executionTimeInMilliseconds, httpResponseStatusCode: httpResponseStatusCode, url: url ?? GetUrl());
		}

		public Guid Fatal(string message, int logMessageType, Exception ex, string userName = null, string clientIPAddress = null,
			[CallerMemberName] string methodName = null, [CallerFilePath] string sourceFile = null, [CallerLineNumber] int lineNumber = 0,
			Decimal? executionTimeInMilliseconds = null, int? httpResponseStatusCode = null, string url = null)
		{
			url = url ?? GetUrl();
			clientIPAddress = clientIPAddress ?? GetClientIpAddress();

			return Log.Fatal(message: message, logMessageType: logMessageType, ex: ex, userName: userName,
				clientIPAddress: clientIPAddress ?? GetClientIpAddress(), methodName: methodName, sourceFile: sourceFile,
				lineNumber: lineNumber, executionTimeInMilliseconds: executionTimeInMilliseconds, httpResponseStatusCode: httpResponseStatusCode, url: url ?? GetUrl());
		}

		public Guid Info(string message, int logMessageType, Exception ex = null, string userName = null, string clientIPAddress = null,
			[CallerMemberName] string methodName = null, [CallerFilePath] string sourceFile = null, [CallerLineNumber] int lineNumber = 0,
			Decimal? executionTimeInMilliseconds = null, int? httpResponseStatusCode = null, string url = null)
		{
			url = url ?? GetUrl();
			clientIPAddress = clientIPAddress ?? GetClientIpAddress();

			return Log.Info(message: message, logMessageType: logMessageType, ex: ex, userName: userName,
				clientIPAddress: clientIPAddress ?? GetClientIpAddress(), methodName: methodName, sourceFile: sourceFile,
				lineNumber: lineNumber, executionTimeInMilliseconds: executionTimeInMilliseconds, httpResponseStatusCode: httpResponseStatusCode, url: url ?? GetUrl());
		}

		public Guid Warn(string message, int logMessageType, Exception ex = null, string userName = null, string clientIPAddress = null,
			[CallerMemberName] string methodName = null, [CallerFilePath] string sourceFile = null, [CallerLineNumber] int lineNumber = 0,
			Decimal? executionTimeInMilliseconds = null, int? httpResponseStatusCode = null, string url = null)
		{
			url = url ?? GetUrl();
			clientIPAddress = clientIPAddress ?? GetClientIpAddress();

			return Log.Warn(message: message, logMessageType: logMessageType, ex: ex, userName: userName,
				clientIPAddress: clientIPAddress ?? GetClientIpAddress(), methodName: methodName, sourceFile: sourceFile,
				lineNumber: lineNumber, executionTimeInMilliseconds: executionTimeInMilliseconds, httpResponseStatusCode: httpResponseStatusCode, url: url ?? GetUrl());
		}

		#endregion ILoggingService
	}
}