﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelPriceChecker
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="TTGDB")]
	public partial class DatabaseAPIConnectorDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertAPIActivation(APIActivation instance);
    partial void UpdateAPIActivation(APIActivation instance);
    partial void DeleteAPIActivation(APIActivation instance);
    partial void InsertSpecialDay(SpecialDay instance);
    partial void UpdateSpecialDay(SpecialDay instance);
    partial void DeleteSpecialDay(SpecialDay instance);
    partial void InsertHotel(Hotel instance);
    partial void UpdateHotel(Hotel instance);
    partial void DeleteHotel(Hotel instance);
    #endregion
		
		public DatabaseAPIConnectorDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["TTGDBConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DatabaseAPIConnectorDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DatabaseAPIConnectorDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DatabaseAPIConnectorDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DatabaseAPIConnectorDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<APIActivation> APIActivations
		{
			get
			{
				return this.GetTable<APIActivation>();
			}
		}
		
		public System.Data.Linq.Table<SpecialDay> SpecialDays
		{
			get
			{
				return this.GetTable<SpecialDay>();
			}
		}
		
		public System.Data.Linq.Table<Hotel> Hotels
		{
			get
			{
				return this.GetTable<Hotel>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.APIActivation")]
	public partial class APIActivation : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.DateTime _TimeToSwitch;
		
		private bool _SwitchTo;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnTimeToSwitchChanging(System.DateTime value);
    partial void OnTimeToSwitchChanged();
    partial void OnSwitchToChanging(bool value);
    partial void OnSwitchToChanged();
    #endregion
		
		public APIActivation()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TimeToSwitch", DbType="DateTime NOT NULL", IsPrimaryKey=true)]
		public System.DateTime TimeToSwitch
		{
			get
			{
				return this._TimeToSwitch;
			}
			set
			{
				if ((this._TimeToSwitch != value))
				{
					this.OnTimeToSwitchChanging(value);
					this.SendPropertyChanging();
					this._TimeToSwitch = value;
					this.SendPropertyChanged("TimeToSwitch");
					this.OnTimeToSwitchChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SwitchTo", DbType="Bit NOT NULL")]
		public bool SwitchTo
		{
			get
			{
				return this._SwitchTo;
			}
			set
			{
				if ((this._SwitchTo != value))
				{
					this.OnSwitchToChanging(value);
					this.SendPropertyChanging();
					this._SwitchTo = value;
					this.SendPropertyChanged("SwitchTo");
					this.OnSwitchToChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.SpecialDays")]
	public partial class SpecialDay : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.DateTime _Date;
		
		private bool _Status;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnDateChanging(System.DateTime value);
    partial void OnDateChanged();
    partial void OnStatusChanging(bool value);
    partial void OnStatusChanged();
    #endregion
		
		public SpecialDay()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Date", DbType="DateTime NOT NULL", IsPrimaryKey=true)]
		public System.DateTime Date
		{
			get
			{
				return this._Date;
			}
			set
			{
				if ((this._Date != value))
				{
					this.OnDateChanging(value);
					this.SendPropertyChanging();
					this._Date = value;
					this.SendPropertyChanged("Date");
					this.OnDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="Bit NOT NULL")]
		public bool Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				if ((this._Status != value))
				{
					this.OnStatusChanging(value);
					this.SendPropertyChanging();
					this._Status = value;
					this.SendPropertyChanged("Status");
					this.OnStatusChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Hotel")]
	public partial class Hotel : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _HotelKey;
		
		private string _HotelName;
		
		private string _City;
		
		private bool _IsActive;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnHotelKeyChanging(string value);
    partial void OnHotelKeyChanged();
    partial void OnHotelNameChanging(string value);
    partial void OnHotelNameChanged();
    partial void OnCityChanging(string value);
    partial void OnCityChanged();
    partial void OnIsActiveChanging(bool value);
    partial void OnIsActiveChanged();
    #endregion
		
		public Hotel()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HotelKey", DbType="NVarChar(1) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string HotelKey
		{
			get
			{
				return this._HotelKey;
			}
			set
			{
				if ((this._HotelKey != value))
				{
					this.OnHotelKeyChanging(value);
					this.SendPropertyChanging();
					this._HotelKey = value;
					this.SendPropertyChanged("HotelKey");
					this.OnHotelKeyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HotelName", DbType="NVarChar(1) NOT NULL", CanBeNull=false)]
		public string HotelName
		{
			get
			{
				return this._HotelName;
			}
			set
			{
				if ((this._HotelName != value))
				{
					this.OnHotelNameChanging(value);
					this.SendPropertyChanging();
					this._HotelName = value;
					this.SendPropertyChanged("HotelName");
					this.OnHotelNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_City", DbType="NVarChar(1) NOT NULL", CanBeNull=false)]
		public string City
		{
			get
			{
				return this._City;
			}
			set
			{
				if ((this._City != value))
				{
					this.OnCityChanging(value);
					this.SendPropertyChanging();
					this._City = value;
					this.SendPropertyChanged("City");
					this.OnCityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsActive", DbType="Bit NOT NULL")]
		public bool IsActive
		{
			get
			{
				return this._IsActive;
			}
			set
			{
				if ((this._IsActive != value))
				{
					this.OnIsActiveChanging(value);
					this.SendPropertyChanging();
					this._IsActive = value;
					this.SendPropertyChanged("IsActive");
					this.OnIsActiveChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
