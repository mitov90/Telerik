#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the ClassGenerator.ttinclude code generation file.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Data.Common;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.OpenAccess.Metadata.Fluent.Advanced;
using OpenAccessModels;

namespace OpenAccessModels	
{
	public partial class WorkReport
	{
		private int _workReportID;
		public virtual int WorkReportID
		{
			get
			{
				return this._workReportID;
			}
			set
			{
				this._workReportID = value;
			}
		}
		
		private int _employeeID;
		public virtual int EmployeeID
		{
			get
			{
				return this._employeeID;
			}
			set
			{
				this._employeeID = value;
			}
		}
		
		private DateTime _date;
		public virtual DateTime Date
		{
			get
			{
				return this._date;
			}
			set
			{
				this._date = value;
			}
		}
		
		private string _task;
		public virtual string Task
		{
			get
			{
				return this._task;
			}
			set
			{
				this._task = value;
			}
		}
		
		private int _hours;
		public virtual int Hours
		{
			get
			{
				return this._hours;
			}
			set
			{
				this._hours = value;
			}
		}
		
		private string _comments;
		public virtual string Comments
		{
			get
			{
				return this._comments;
			}
			set
			{
				this._comments = value;
			}
		}
		
		private Employee _employee;
		public virtual Employee Employee
		{
			get
			{
				return this._employee;
			}
			set
			{
				this._employee = value;
			}
		}
		
	}
}
#pragma warning restore 1591
