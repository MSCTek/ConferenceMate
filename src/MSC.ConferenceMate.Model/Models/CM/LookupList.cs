// <auto-generated> - Template:ModelsBackedByDto, Version:1.1, Id:f1539c0d-024f-4b1f-b346-132cdd9dd31f
using CodeGenHero.Logging;
using CodeGenHero.DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using MSC.ConferenceMate.API.Client.Interface;
using MSC.ConferenceMate.Model.CM.Interface;
using xDTO = MSC.ConferenceMate.DTO.CM;

namespace MSC.ConferenceMate.Model.CM
{

	public class LoadRequestLookupList : EventArgs
	{
		public LoadRequestLookupList(string propertyNameRequestingLoad)
		{
			PropertyNameRequestingLoad = propertyNameRequestingLoad;
		}

		public string PropertyNameRequestingLoad { get; set; }
	}


	public partial class LookupList : BaseModel<IWebApiDataServiceCM>, ILookupList
	{
		public event EventHandler<LoadRequestLookupList> OnLazyLoadRequest = delegate { }; // Empty delegate. Thus we are sure that value is always != null because no one outside of the class can change it.
		private xDTO.LookupList _dto = null;

		public LookupList(ILoggingService log, IDataService<IWebApiDataServiceCM> dataService) : base(log, dataService)
		{
			_dto = new xDTO.LookupList();
			OnLazyLoadRequest += HandleLazyLoadRequest;
		}

		public LookupList(ILoggingService log, IDataService<IWebApiDataServiceCM> dataService, xDTO.LookupList dto) : this(log, dataService)
		{
			_dto = dto;
		}


		public virtual string CreatedBy { get { return _dto.CreatedBy; } }
		public virtual System.DateTime CreatedUtcDate { get { return _dto.CreatedUtcDate; } }
		public virtual string CustomJson { get { return _dto.CustomJson; } }
		public virtual int DataVersion { get { return _dto.DataVersion; } }
		public virtual string Description { get { return _dto.Description; } }
		public virtual int DisplayPriority { get { return _dto.DisplayPriority; } }
		public virtual string DisplayText { get { return _dto.DisplayText; } }
		public virtual string ForeignKeyTableName { get { return _dto.ForeignKeyTableName; } }
		public virtual int ForeignKeyTablePkId { get { return _dto.ForeignKeyTablePkId; } }
		public virtual bool IsDeleted { get { return _dto.IsDeleted; } }
		public virtual int LanguageTypeId { get { return _dto.LanguageTypeId; } }
		public virtual int LookupListId { get { return _dto.LookupListId; } }
		public virtual string ModifiedBy { get { return _dto.ModifiedBy; } }
		public virtual System.DateTime ModifiedUtcDate { get { return _dto.ModifiedUtcDate; } }

		private ILanguageType _languageType = null; // Foreign Key


		public virtual ILanguageType LanguageType
		{
			get
			{
				if (_languageType == null && _dto != null && _dto.LanguageType != null)
				{
					_languageType = new LanguageType(Log, DataService, _dto.LanguageType);
				}

				return _languageType;
			}
		}



	}
}
